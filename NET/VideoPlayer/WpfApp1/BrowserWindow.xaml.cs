using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Collections;
using System.Drawing;
using Microsoft.WindowsAPICodePack.Shell;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        MainWindow mw = null;
        List<string> ext = new List<string>(); //rozszerzenia
        Hashtable ht = new Hashtable(); //powiazanie nazw folderow ze sciezkami
        Hashtable htf = new Hashtable();  //powiazanie plikow z ich nazwami
        DriveInfo[] d = null; //odczytanie dysku

        Stack<String> st = new Stack<string>(); //sciezka do cofania
        String currentPath = String.Empty; //temp do sciezki
        List<Items> ls = new List<Items>(); //lista plikow do wyswietlenia - lista na liste

        public BrowserWindow()
        {
            InitializeComponent();
            ListDirectories("\\");
            ////////lista z miniaturami
            var factory = new FrameworkElementFactory(typeof(System.Windows.Controls.Image));
            factory.SetValue(System.Windows.Controls.Image.SourceProperty, new System.Windows.Data.Binding(nameof(Items.Image)));
            factory.SetValue(System.Windows.Controls.Image.WidthProperty, 100.0);
            factory.SetValue(System.Windows.Controls.Image.HeightProperty, 100.0);
            var dataTemplate = new DataTemplate { VisualTree = factory };
            GridView grView = new GridView();
            grView.Columns.Add(new GridViewColumn { Header = "Thumb", Width = 100, CellTemplate = dataTemplate });
            grView.Columns.Add(new GridViewColumn { Header = "Name", Width = 550, DisplayMemberBinding = new System.Windows.Data.Binding(nameof(Items.Name)) });
            Thumbnails.View = grView;
            /////////
            PrepareExtList();

            foreach (Window openWin in System.Windows.Application.Current.Windows)
            {
                if (openWin.GetType() == typeof(MainWindow))
                    mw = (MainWindow)openWin;
            }

        }
        
        private void PrepareExtList()
        {
            ext.Add(".avi");
            ext.Add(".mp4");  
        }

        private void ListDrives()
        {
            st.Push("\\");
            ht.Clear();
            d = DriveInfo.GetDrives();
            foreach (DriveInfo dr in d)
            {
                DirectoryList.Items.Add(dr.ToString());
                ht.Add(dr.ToString(), dr.ToString());
            }
        }

        private void ListDirectories(string path)
        {
            currentPath = path;
            if (path == "\\")
            {
                DirectoryList.Items.Clear();
                Thumbnails.ItemsSource=null;
                ListDrives();
            }
            else
            {
                ListFiles();
                DirectoryList.Items.Clear();
                ht.Clear();
                DirectoryList.Items.Add("..");


                foreach (String dir in Directory.GetDirectories(path))
                {
                    String[] temp = dir.ToString().Split('\\');
                    DirectoryList.Items.Add(temp[temp.Length - 1]);
                    ht.Add(temp[temp.Length - 1], dir.ToString());
                }
            }
        }

        private void DirectoryList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (DirectoryList.SelectedItems.Count != 0)
                {
                    if (DirectoryList.SelectedItem.ToString() == "..")
                        ListDirectories(st.Pop());
                    else
                    {
                        st.Push(currentPath);
                        String temp = ht[DirectoryList.SelectedItem.ToString()].ToString();
                        ListDirectories(temp);

                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                currentPath = st.Pop();

            }
        }

        private void ListFiles()
        {
            Thumbnails.ItemsSource = null;

            ls.Clear(); //czyszenie listy do wyswietlenia
            htf.Clear();  //czyszenie powiazan

            foreach (String fl in Directory.GetFiles(currentPath))
            {
                if (ext.Contains(System.IO.Path.GetExtension(fl)))
                {
                    var ff = new NReco.VideoConverter.FFMpegConverter();
                    System.IO.Stream thum = new MemoryStream();
                    ff.GetVideoThumbnail(fl, thum, 1);
                    System.Drawing.Image th = Bitmap.FromStream(thum);

                    if (!System.IO.Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\temp\\"))
                        Directory.CreateDirectory(System.IO.Directory.GetCurrentDirectory() + "\\temp\\");
                    string temp = System.IO.Directory.GetCurrentDirectory() + "\\temp\\" + System.IO.Path.GetFileName(fl);
                    if(!System.IO.File.Exists(temp))
                        th.Save(temp, ImageFormat.Jpeg);

                    ls.Add(new Items() { Image = temp, Name = System.IO.Path.GetFileName(fl) });  // dodanie do listy
                    htf.Add(System.IO.Path.GetFileName(fl), fl);  //dodanie do listy asocjacyjnej
                }
            }
            Thumbnails.ItemsSource = ls;
        }

        private void Thumbnails_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            
            foreach (var s in Thumbnails.SelectedItems)
            {
                PlaylistWindow.pl.Add(new Association() { Name = System.IO.Path.
                    GetFileName((string)htf[((Thumbnails.SelectedItem as Items).Name)]),
                    Path = (string)htf[((Thumbnails.SelectedItem as Items).Name)] });
                

            }
            if (MainWindow.pl != null)
                MainWindow.pl.RefreshPlayList();
            Thumbnails.UnselectAll();
        }

        public class Items
        {
            public String Image { get; set; }
            public String Name { get; set; }
        }

    }
}
