using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static PlaylistWindow pl = null;
        public static BrowserWindow bw = null;
        public static Hashtable playlist = new Hashtable();
        public int CurrentFileIndex = 0;
        public string CurrentFileName = null;
        public bool status = false;
        bool zapetlajListe = false;
        public bool endofPlaylist = false;
        bool loopAll = false;
        bool loopOne = false;
        public NAudio.Wave.MediaFoundationReader a = null;
        public  NAudio.Wave.WaveOut w = null;
        DispatcherTimer d = null;


        public MainWindow()
        {
            InitializeComponent();
            d = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(1000)
            };
            d.Tick += new EventHandler(TickMethod);
            d.Start();
        
        }

        private void TickMethod(object sender, EventArgs e)
        {
            if (w != null && a != null)
            {
                TimeBlock.Text = a.CurrentTime.Minutes + ":" + a.CurrentTime.Seconds + "/" + a.TotalTime.Minutes + ":" + a.TotalTime.Seconds;
            }
            else
                TimeBlock.Text = "-";
        }

        public void addToPlaylist(string path)
        {
            String[] temp = path.ToString().Split('\\');
            playlist.Add(temp[temp.Length - 1], path);
            if ((pl = (PlaylistWindow)checkOpenedForms(pl)) != null)
                pl.RefreshPlayList();
        }
        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void open_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Multiselect = true;
            d.Filter = "AUDIO (*.mp3,*.wav)|*.mp3;*.wav";
            d.ShowDialog();
            if (d.CheckPathExists)
            {
                foreach (String path in d.FileNames)
                {
                    String[] temp = path.Split('\\');
                    PlaylistWindow.pl.Add(new Association() { Name = temp[temp.Length - 1], Path = path });
                }
                if (pl != null)
                {
                    pl.RefreshPlayList();
                }
            }
        }

        private void open_treeView_Click(object sender, EventArgs e)
        {
            if ((bw = (BrowserWindow)checkOpenedForms(bw)) == null)
                (bw = new BrowserWindow()).Show();
            else
                bw.Focus();
        }

        private void playList_button_Click(object sender, RoutedEventArgs e)
        {
            if ((pl = (PlaylistWindow)checkOpenedForms(pl)) == null)
                (pl = new PlaylistWindow(this)).Show();
            else
                pl.Focus();
        }

        private Window checkOpenedForms(Window w)
        {
            if (w != null)
            {
                foreach (Window openWin in System.Windows.Application.Current.Windows)
                {
                    if (openWin.GetType() == w.GetType())
                        return openWin;
                }
            }
            return null;
        }

        private void close_Click(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((System.Windows.MessageBox.Show("Czy chcesz zamknąć program?", "Uwaga", MessageBoxButton.YesNo)) != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                foreach (Window openWin in System.Windows.Application.Current.Windows)
                {
                    if (openWin.GetType() != this.GetType())
                        openWin.Close();
                    //zamykanie wszystkich okien
                }
            }
        }

        private void openFromURL_click(object sender, RoutedEventArgs e)
        {
            new URLWindow().Show();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (endofPlaylist)
                endofPlaylist = false;
            try
            {
                if (w!=null)
                {
                    if (w.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                    {
                        w.Resume();
                        Status_text.Text = "Status: Playing";
                    }
                }
                if(w==null)
                    PlayMethod();
                
                    
            }
            catch
            {
                System.Windows.MessageBox.Show("Nie można odtworzyć w tym stanie!");
            }
        }
        public void PlayMethod()
        {
            if(loopAll)
            {
                endofPlaylist = false;
            }
            try
            {
                CloseWaveOut();
                if (PlaylistWindow.pl.Count > 0&& CurrentFileIndex<PlaylistWindow.pl.Count&& CurrentFileIndex >=0&&endofPlaylist==false)
                {
                    if(PlaylistWindow.pl[CurrentFileIndex].Path=="Online")
                    {
                        a = new NAudio.Wave.MediaFoundationReader(PlaylistWindow.pl[CurrentFileIndex].Name);
                    }
                    else
                    {
                        try
                        {
                            a = new NAudio.Wave.MediaFoundationReader(PlaylistWindow.pl[CurrentFileIndex].Path);
                        }
                        catch
                        {
                            a = new NAudio.Wave.MediaFoundationReader(PlaylistWindow.pl[CurrentFileIndex].Path);
                        }
                    }
                    status = false;
                    //  String[] temp = PlaylistWindow.pl[CurrentFileIndex].Path.Split('\\');
                    CurrentFileName = PlaylistWindow.pl[CurrentFileIndex].Name;
                    w = new NAudio.Wave.WaveOut();
                    w.PlaybackStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(Ended);
                    w.Init(a);
                    if (CurrentFileName.Length > 30)
                    {
                        string temp = CurrentFileName.Remove(30);
                        NameOfFileText.Text = "Aktualny plik: " + temp+" [...]";
                    }
                    else
                        NameOfFileText.Text = "Aktualny plik: " + CurrentFileName;
                    Status_text.Text = "Status: Playing";
                    w.Play();

                    
                }
            }
            catch (Exception e)
            {
               System.Windows.MessageBox.Show(e.ToString());
            }
                
            
        }
        public void findIndex(bool status)
        {
            try
            {
                if (!status)
                {
                    String[] temp = CurrentFileName.Split('\\');
                    CurrentFileIndex = PlaylistWindow.pl.IndexOf(PlaylistWindow.FindObject(temp[temp.Length - 1])) + 1;
                    if (CurrentFileIndex < 0)
                        throw new Exception();
                }
                else
                {
                    String[] temp = CurrentFileName.Split('\\');
                    CurrentFileIndex = PlaylistWindow.pl.IndexOf(PlaylistWindow.FindObject(temp[temp.Length - 1]));
                    if (CurrentFileIndex < 0)
                        throw new Exception();
                }
            }
            catch
            {
                if (!status)
                {
                    
                    CurrentFileIndex = PlaylistWindow.pl.IndexOf(PlaylistWindow.FindObject(CurrentFileName)) + 1;
                }
                else
                {
                    
                    CurrentFileIndex = PlaylistWindow.pl.IndexOf(PlaylistWindow.FindObject(CurrentFileName));
                }
            }
            if (CurrentFileIndex == PlaylistWindow.pl.Count)
            {
                CurrentFileIndex = 0;
                endofPlaylist = true;
            }
        }
        private void Ended(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            NameOfFileText.Text = "Aktualny plik: - ";
            Status_text.Text = "Status: Stopped";
            if (loopOne)
            {
                if (!status)
                {
                    status = true;
                    
                    PlayMethod();
                }
            }
            else if(!status)
            {
                status = true;
                findIndex(false);
                PlayMethod();
            }
            
        }
        public void CloseWaveOut()
        {
            if (w != null)
            {
                w.Stop();
            }
            if (a != null)
            {
                a.Dispose();
                a = null;
            }

            if (w != null)
            {
                w.Dispose();
                w = null;
            }

        }

        private void Stopbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NameOfFileText.Text = "Aktualny plik: - ";
                Status_text.Text = "Status: Stopped";
                w.Stop();
                status = true;
                CloseWaveOut();
            }
            catch
            {
                System.Windows.MessageBox.Show("Nie można zatrzymać w tym stanie!");
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                w.Pause();
                status = false;
                Status_text.Text = "Status: Paused";
            }
            catch
            {
                System.Windows.MessageBox.Show("Nie można wstrzymać w tym stanie!");
            }
        }

        private void Next_button_Click(object sender, RoutedEventArgs e)
        {
            endofPlaylist = false;
            Ended(null, null);
            if(CurrentFileIndex==0)
            {
                PlayButton_Click(sender, e);
            }
        }

        private void Previous_button_Click(object sender, RoutedEventArgs e)
        {
            CloseWaveOut();
            findIndexPreviousButton();
            PlayButton_Click(sender, e);
        }
        public void findIndexPreviousButton()
        {
            try
            {
                
                    String[] temp = CurrentFileName.Split('\\');
                    CurrentFileIndex = PlaylistWindow.pl.IndexOf(PlaylistWindow.FindObject(temp[temp.Length - 1])) -1;
                    if (CurrentFileIndex < 0)
                        throw new Exception();
            }
            catch
            {            
                    CurrentFileIndex = PlaylistWindow.pl.IndexOf(PlaylistWindow.FindObject(CurrentFileName)) -1;       
            }
            if (CurrentFileIndex == -1)
            {
                CurrentFileIndex = PlaylistWindow.pl.Count-1;  
            }
        }

        private void LoopButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)LoopButton.Content == "Loop OFF")
            {
                LoopButton.Content = "Loop One";
                Loop_button1.Header = "Loop One";
                loopOne = true;
                loopAll = false;
            }
            else if ((string)LoopButton.Content == "Loop One")
            {
                LoopButton.Content = "Loop All";
                Loop_button1.Header = "Loop All";
                loopOne = false;
                loopAll = true;
            }
            else
            {
                loopAll = false;
                loopOne = false;
                LoopButton.Content = "Loop OFF";
                Loop_button1.Header = "Loop OFF";
            }
        }
    }
}
    
