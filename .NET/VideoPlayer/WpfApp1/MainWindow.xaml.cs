using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
     
        public int CurrentFileIndex = -1;
        public string CurrentFileName = null;
        public bool status = false;
        public bool endofPlaylist = false;
        bool loopAll = false;
        bool loopOne = false;
        bool seeking = false;
        public NAudio.Wave.MediaFoundationReader a = null;
        public  NAudio.Wave.WaveOut w = null;
        DispatcherTimer d = null;
        double downTime = 0;
        double releaseTime = 0;
        TimeSpan totalDurationTime1;
        bool pausestate = false;

        public MainWindow()
        {
            InitializeComponent();
            
            d = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            d.Tick += new EventHandler(TickMethod);
            d.Start();
            Shuffle_button.Content = "Shuffle OFF";
            mediaelement.LoadedBehavior = MediaState.Manual;
            mediaelement.Volume = VolumeSlider.Value;
            
        
        }

        private void TickMethod(object sender, EventArgs e)
        {
            if (mediaelement.Source != null)
            {
                var ff = new NReco.VideoConverter.FFMpegConverter();
                System.IO.Stream thum = new MemoryStream();
                try
                {
                    ff.GetVideoThumbnail(PlaylistWindow.pl[CurrentFileIndex].Path, thum, 1);
                    System.Drawing.Image th = Bitmap.FromStream(thum);
                    TimeBlock.Text = mediaelement.Position.Hours + ":" +
                        mediaelement.Position.Minutes + ":" + mediaelement.Position.Seconds +
                        "/" + totalDurationTime1.Hours + ":" + totalDurationTime1.Minutes + ":" +
                        totalDurationTime1.Seconds + "Height: " + th.Size.Height +
                        " Width: " + th.Size.Width;
                }
                catch
                {
                    TimeBlock.Text = mediaelement.Position.Hours + ":" +
                                            mediaelement.Position.Minutes + ":" + mediaelement.Position.Seconds +
                                            "/" + totalDurationTime1.Hours + ":" + totalDurationTime1.Minutes + ":" +
                                            totalDurationTime1.Seconds + "Height: " + 0 +
                                            " Width: " + 0;
                }
                if (!seeking)
                {
                    SeekSlider.Value = mediaelement.Position.TotalSeconds;
                }
                    SizeBlock.Text = "File size: " + Math.Round((float)new System.IO.FileInfo(PlaylistWindow.pl[CurrentFileIndex].Path).Length / 1048576F, 2) + " MB";
                
            }
            else
            {
                TimeBlock.Text = "-";
                SizeBlock.Text = "File size: -";
            }

        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void open_button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Multiselect = true;
            d.Filter = "VIDEO (*.mp4,*.avi, *.mkv)|*.mp4;*.avi;*.mkv";
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

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (pausestate)
            {
                mediaelement.Play();
                pausestate = !pausestate;
            }
            else
            {
                if (CurrentFileIndex == -1)
                {
                    CurrentFileIndex = 0;
                }
                if (endofPlaylist)
                    endofPlaylist = false;
                if ((String)Shuffle_button.Content == "Shuffle ON")
                    CurrentFileIndex = new Random().Next(0, PlaylistWindow.pl.Count);

                try
                {
                    if (w != null)
                    {
                        if (w.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                        {
                            w.Resume();
                            Status_text.Text = "Status: Playing";
                        }
                    }
                    if (w == null)
                        PlayMethod();
                }
                catch
                {
                    System.Windows.MessageBox.Show("Nie można odtworzyć w tym stanie!");
                }
            }
        }

        public void PlayMethod()
        {
            pausestate = false;
            
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
                            mediaelement.Source= new Uri(PlaylistWindow.pl[CurrentFileIndex].Path);
                        }
                        catch
                        {
                            a = new NAudio.Wave.MediaFoundationReader(PlaylistWindow.pl[CurrentFileIndex].Path);
                        }
                    }
                    status = false;
                    //  String[] temp = PlaylistWindow.pl[CurrentFileIndex].Path.Split('\\');
                    CurrentFileName = PlaylistWindow.pl[CurrentFileIndex].Name;
                    
                    if (CurrentFileName.Length > 30)
                    {
                        string temp = CurrentFileName.Remove(30);
                        NameOfFileText.Text = "Aktualny plik: " + temp+" [...]";
                    }
                    else
                        NameOfFileText.Text = "Aktualny plik: " + CurrentFileName;
                    Status_text.Text = "Status: Playing";
                    mediaelement.Play();
                    SeekSlider.Minimum = 0;
                    
                    
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
                mediaelement.Stop();
                status = true;
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
                
                mediaelement.Pause();
                pausestate = true;
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
            Mediaelement_MediaEnded(null, null);
            if(CurrentFileIndex==0)
            {
                PlayButton_Click(sender, e);
            }

        }

        private void Previous_button_Click(object sender, RoutedEventArgs e)
        {
            CloseWaveOut();
            CurrentFileIndex = new Random().Next(0, PlaylistWindow.pl.Count);
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

        private void Shuffle_button_Click(object sender, RoutedEventArgs e)
        {
            if((String)Shuffle_button.Content == "Shuffle ON")
            Shuffle_button.Content = "Shuffle OFF";
            else
                Shuffle_button.Content = "Shuffle ON";
        }

        private void DragSeekSliderCompleted(object sender, DragCompletedEventArgs e)
        {
            mediaelement.Position = TimeSpan.FromSeconds(SeekSlider.Value);
            mediaelement.Play();
            seeking = false;
        }

        private void DragStarted(object sender, DragStartedEventArgs e)
        {
            seeking = true;
            mediaelement.Pause();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
          //// if (pl != null)
           // {
           //     pl.Top = this.Top + this.Height;
           //     pl.Left = this.Left;
           // }
        }

        private void mediaelement_MediaOpened(object sender, RoutedEventArgs e)
        {
            SeekSlider.Maximum = mediaelement.NaturalDuration.TimeSpan.TotalSeconds;
            totalDurationTime1 = TimeSpan.FromSeconds(mediaelement.NaturalDuration.TimeSpan.TotalSeconds);
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaelement.Volume = VolumeSlider.Value;
        }

        private void Mediaelement_MediaEnded(object sender, RoutedEventArgs e)
        {
            NameOfFileText.Text = "Aktualny plik: - ";
            Status_text.Text = "Status: Stopped";
            SeekSlider.Value = 0;
            if (loopOne)
            {
                if (!status)
                {
                    status = true;
                    PlayMethod();
                }
            }
            else if (!status && (String)Shuffle_button.Content == "Shuffle OFF")
            {
                status = true;
                findIndex(false);
                PlayMethod();
            }
            else
            {
                CurrentFileIndex = new Random().Next(0, PlaylistWindow.pl.Count);
                PlayMethod();
            }
        }
            
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (System.IO.Directory.Exists(System.IO.Directory.GetCurrentDirectory() + "\\temp\\"))
            {
                System.IO.Directory.Delete(System.IO.Directory.GetCurrentDirectory() + "\\temp\\", true);
            }
        }
    }
}
    
