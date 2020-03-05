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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy BrowserWindow.xaml
    /// </summary>
    public partial class BrowserWindow : Window
    {
        Hashtable ht = new Hashtable(); //powiazanie nazw folderow ze sciezkami
        Hashtable htf = new Hashtable();
        DriveInfo[] d = null; //odczytanie dysku
        
        Stack<String> st = new Stack<string>(); //sciezka do cofania
        String currentPath = String.Empty; //temp do sciezki
        public BrowserWindow()
        {
            InitializeComponent();
            ListDirectories("\\");        
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
            if(path=="\\")
            { 
                DirectoryList.Items.Clear();
                FilesList.Items.Clear();
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
                    DirectoryList.Items.Add(temp[temp.Length-1]);
                    ht.Add(temp[temp.Length-1], dir.ToString());
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
                System.Windows.MessageBox.Show(ex.Message);
                currentPath=st.Pop();

            }
        }

        private void ListFiles()
        {
            FilesList.Items.Clear();
            htf.Clear();

            foreach (String fl in Directory.GetFiles(currentPath))
            {
                String[] temp = fl.Split('\\');
                if (System.IO.Path.GetExtension(fl) == ".wav" || System.IO.Path.GetExtension(fl) == ".mp3")
                {
                    FilesList.Items.Add(temp[temp.Length - 1]);
                    htf.Add(temp[temp.Length - 1], fl);
                }
                
            }
        }

        private void addtopl_click(object sender, RoutedEventArgs e)
        {
            foreach(String s in FilesList.SelectedItems)
            {
                    PlaylistWindow.pl.Add(new Association(){ Name = s.ToString(),Path= htf[s.ToString()].ToString() });
            }
            if (MainWindow.pl != null)
                MainWindow.pl.RefreshPlayList();
            FilesList.UnselectAll();
        }

       
    }
}
