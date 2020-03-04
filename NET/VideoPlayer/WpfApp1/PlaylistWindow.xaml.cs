using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WMPLib;

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
        
        TimeSpan totalDurationTime1;
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
            foreach (Association s in pl)
            {
                Duration(s.Path);
                ls.Add(new Items() { Name = s.Name, Time = totalDurationTime1.Hours +
                    ":" + totalDurationTime1.Minutes + ":" 
                    + totalDurationTime1.Seconds,
                    Size = Math.Round((float)new System.IO.FileInfo(s.Path).Length / 1048576F, 2) + " MB" });
                
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

        private void TrackUp_button_Click(object sender, RoutedEventArgs e)
        {
            if(PlayList.SelectedItems.Count==1)
            {
                Items item = (Items)PlayList.SelectedItems[0];
                
                    int index=pl.IndexOf(FindObject(item.Name));

                if (index != 0)
                {
                    var tempup = pl[index];
                    var tempdown = pl[index - 1];
                    pl[index] = tempdown;
                    pl[index - 1] = tempup;
                    RefreshPlayList();
                    PlayList.SelectedIndex = index - 1;
                }
                else
                {
                    RefreshPlayList();
                    PlayList.SelectedIndex = pl.IndexOf(FindObject(item.Name));
                }
            }
        }

        private void TrackDown_button_Click(object sender, RoutedEventArgs e)
        {
            if (PlayList.SelectedItems.Count == 1)
            {
                Items item = (Items)PlayList.SelectedItems[0];
                int index = pl.IndexOf(FindObject(item.Name));

                if (index != pl.Count - 1)
                {
                    var tempup = pl[index + 1];
                    var tempdown = pl[index];
                    pl[index] = tempup;
                    pl[index + 1] = tempdown;
                    RefreshPlayList();
                    PlayList.SelectedIndex = index + 1;
                }
                else
                {
                    RefreshPlayList();
                    PlayList.SelectedIndex = pl.IndexOf(FindObject(item.Name));
                }
            }
        }

        private void me_MediaOpened(object sender, RoutedEventArgs e)
        {
            totalDurationTime1 = TimeSpan.FromSeconds(me.NaturalDuration.TimeSpan.TotalSeconds);
        }

        private void Duration(String file)
        {
            WindowsMediaPlayer wmp = new WindowsMediaPlayer();
            IWMPMedia mediainfo = wmp.newMedia(file);
            totalDurationTime1 = TimeSpan.FromSeconds(mediainfo.duration); 
        }
    }
    public class Items
    {
        public String Name { get; set; }
        public String Time { get; set; }
        public String Size { get; set; }
    }
 
}
    

