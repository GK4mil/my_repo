using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy PlaylistWindow.xaml
    /// </summary>
    public partial class PlaylistWindow : Window
    {
        
        public static List<Association> pl = new List<Association>(); //lista asocjacyjna
        List<Items> ls = new List<Items>(); //lista do wyswietlenia
        MainWindow mw;
        public PlaylistWindow(MainWindow mw)
        {
            this.mw = mw;
            InitializeComponent();
            PlayList.MouseDoubleClick += AddListeners;
            RefreshPlayList();  
        }
        public void RefreshPlayList()
        {
            ls.Clear();

            foreach(Association s in pl)
            {

                NAudio.Wave.MediaFoundationReader a;
                try
                {
                    a = new NAudio.Wave.MediaFoundationReader(s.Path);
                }
                catch
                {
                     a = new NAudio.Wave.MediaFoundationReader(s.Path);
                }
                    ls.Add(new Items() { Name = s.Name, Time = a.TotalTime.Hours+":"+a.TotalTime.Minutes+":"+a.TotalTime.Seconds});
                    a.Dispose();
                
            }
            PlayList.ItemsSource = ls;
            PlayList.Items.Refresh();
        }
        private void AddListeners(object sender, MouseButtonEventArgs e)
        {
            if(mw.w!=null)
                mw.w.Dispose();
            if (mw.a != null)
                mw.a.Dispose();
            mw.CurrentFileName = FindObject((PlayList.SelectedItem as Items).Name).Path;
            mw.status = true;
            mw.findIndex(true);
            mw.endofPlaylist = false;
            mw.PlayMethod();
        }

        private void removebutton_Click(object sender, RoutedEventArgs e)
        {
            foreach(Items item in PlayList.SelectedItems)
            {
                pl.Remove(FindObject(item.Name));
            }
            RefreshPlayList();
        }

        public static Association FindObject(String Name)
        {
            return pl.Find(item => item.Name == Name);
        }

    }
    public class Items
    {
        public String Name { get; set; }
        public String Time { get; set; }
    }
 
}
    

