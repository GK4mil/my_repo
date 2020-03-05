using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace AudioMixerGawek
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WaveOut waveOutDevice1 = null;
        AudioFileReader audioFileReader1 = null;
        WaveOut waveOutDevice2 = null;
        AudioFileReader audioFileReader2 = null;
        List<Association> pl = new List<Association>(); //lista asocjacyjna sciezek z nazwa
        List<Items> ls = new List<Items>(); //lista do wyswietlenia
        bool seeking1 = false;
        bool seeking2 = false;
        String title1 = "";
        String title2 = "";
        DispatcherTimer d1 = null;
        DispatcherTimer d2 = null;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                Uri iconUri = new Uri("./logo.png", UriKind.RelativeOrAbsolute);
                this.Icon = BitmapFrame.Create(iconUri);
            }
            catch { }
            d1 = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            d1.Tick += new EventHandler(TickMethod1);
            d1.Start();
            d2 = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(200)
            };
            d2.Tick += new EventHandler(TickMethod2);
            d2.Start();
            LoadPlFromDB();

        }

        private void Ended1(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            audioFileReader1.CurrentTime = new TimeSpan(0, 0, 0);
        }

        private void Ended2(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            audioFileReader2.CurrentTime = new TimeSpan(0, 0, 0);
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
                SavePlToDB();
            }
        }

        private void PrepareAudioFile1(string fileName)
        {
            try
            {
                title1 = System.IO.Path.GetFileName(fileName);
                CloseWaveOut1(); //Na wszelki wypadek czyścimy zasoby po poprzednim odtwarzaniu
                waveOutDevice1 = new NAudio.Wave.WaveOut();
                waveOutDevice1.PlaybackStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(Ended1);
                audioFileReader1 = new NAudio.Wave.AudioFileReader(fileName);
                waveOutDevice1.Init(audioFileReader1);
                SeekSlider1.Minimum = 0;
                SeekSlider1.Maximum = audioFileReader1.TotalTime.TotalSeconds;
                Volume1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Wystąpił błąd: {0}", ex.Message));
            }
        }

        private void PrepareAudioFile2(string fileName)
        {
            try
            {
                title2 = System.IO.Path.GetFileName(fileName);
                CloseWaveOut2(); //Na wszelki wypadek czyścimy zasoby po poprzednim odtwarzaniu
                waveOutDevice2 = new NAudio.Wave.WaveOut();
                waveOutDevice2.PlaybackStopped += new EventHandler<NAudio.Wave.StoppedEventArgs>(Ended2);
                audioFileReader2 = new NAudio.Wave.AudioFileReader(fileName);
                waveOutDevice2.Init(audioFileReader2);
                SeekSlider2.Minimum = 0;
                SeekSlider2.Maximum = audioFileReader2.TotalTime.TotalSeconds;
                Volume2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Wystąpił błąd: {0}", ex.Message));
            }
        }

        private void CloseWaveOut1()
        {
            if (waveOutDevice1 != null)
            {
                waveOutDevice1.Stop();
            }
            if (audioFileReader1 != null)
            {
                audioFileReader1.Dispose();
                audioFileReader1 = null;
            }
            if (waveOutDevice1 != null)
            {
                waveOutDevice1.Dispose();
                waveOutDevice1 = null;
            }
        }

        private void CloseWaveOut2()
        {
            if (waveOutDevice2 != null)
            {
                waveOutDevice2.Stop();
            }
            if (audioFileReader2 != null)
            {
                audioFileReader2.Dispose();
                audioFileReader2 = null;
            }
            if (waveOutDevice2 != null)
            {
                waveOutDevice2.Dispose();
                waveOutDevice2 = null;
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RefreshPlayList()
        {  
            ls.Clear();
            List<Association> temp = new List<Association>(pl);
            foreach (Association s in temp)
            {
                try
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
                    ls.Add(new Items() { Name = s.Name, Time = FillWithZero(a.TotalTime.Minutes.ToString()) + ":" + FillWithZero(a.TotalTime.Seconds.ToString()) });
                    a.Dispose();
                }
                catch
                {
                    MessageBox.Show("Nie udało się załadować wszytkich plików muzycznych! Sprawdź lokalizację plików!");
                    pl.Remove(FindObject(s.Name));
                    continue;
                }
            }
                Playlist.ItemsSource = ls;
                Playlist.Items.Refresh();             
        }

        private void AddToPlaylistButton_Click(object sender, RoutedEventArgs e)
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
                    pl.Add(new Association() { Name = temp[temp.Length - 1], Path = path });
                }
                RefreshPlayList();
            }
        }

        private void DSIButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Items item in Playlist.SelectedItems)
            {
                pl.Remove(FindObject(item.Name));
            }
            RefreshPlayList();
        }

        private Association FindObject(String Name)
        {
            return pl.Find(item => item.Name == Name);
        }

        private void ATB1_Click(object sender, RoutedEventArgs e)
        {
            if (Playlist.SelectedItems.Count == 1)
            {
                foreach (Items item in Playlist.SelectedItems)
                {
                    PrepareAudioFile1((FindObject(item.Name)).Path);
                }
            }
            else
            {
                MessageBox.Show("Zaznacz jedna sciezke!");
            }
            Playlist.UnselectAll();
        }

        private void ATB2_Click(object sender, RoutedEventArgs e)
        {
            if (Playlist.SelectedItems.Count == 1)
            {
                foreach (Items item in Playlist.SelectedItems)
                {
                    PrepareAudioFile2((FindObject(item.Name)).Path);
                }
            }
            else
            {
                MessageBox.Show("Zaznacz jedna sciezke!");
                Playlist.UnselectAll();
            }
            Playlist.UnselectAll();
        }

        private void PB1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                waveOutDevice1.Play();
            }
            catch { }
        }

        private void PB2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                waveOutDevice2.Play();
            }
            catch { }
        }

        private void PauseB1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                waveOutDevice1.Pause();
            }
            catch { }
        }

        private void PauseB2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                waveOutDevice2.Pause();
            }
            catch { }
        }

        private void SB1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                waveOutDevice1.Stop();
            }
            catch { }
        }

        private void SB2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                waveOutDevice2.Stop();               
            }
            catch { }

        }

        private void TickMethod1(object sender, EventArgs e)
        {
            TitleBox1.Text = title1;
            if (waveOutDevice1 != null && audioFileReader1 != null)
            {
                if (!seeking1)
                {
                    TimeBlock1.Text = FillWithZero(audioFileReader1.CurrentTime.Minutes.ToString()) + ":"
                    + FillWithZero(audioFileReader1.CurrentTime.Seconds.ToString()) + "/" +
                    FillWithZero(audioFileReader1.TotalTime.Minutes.ToString()) + ":" +
                    FillWithZero(audioFileReader1.TotalTime.Seconds.ToString());
                    SeekSlider1.Value = audioFileReader1.CurrentTime.TotalSeconds;

                }
                
            }
            else
            {
                TimeBlock1.Text = "00:00/00:00";
            }

        }

        private void TickMethod2(object sender, EventArgs e)
        {
            TitleBox2.Text = title2;
            if (waveOutDevice2 != null && audioFileReader2 != null)
            {
                if (!seeking2)
                {
                    TimeBlock2.Text = FillWithZero(audioFileReader2.CurrentTime.Minutes.ToString()) + ":"
                    + FillWithZero(audioFileReader2.CurrentTime.Seconds.ToString()) + "/" +
                    FillWithZero(audioFileReader2.TotalTime.Minutes.ToString()) + ":" +
                    FillWithZero(audioFileReader2.TotalTime.Seconds.ToString());
                    
                    SeekSlider2.Value = audioFileReader2.CurrentTime.TotalSeconds;
                }
                
            }
            else
            {
                TimeBlock2.Text = "00:00/00:00";
            }
        }

        private void DragSeekSliderCompleted1(object sender, DragCompletedEventArgs e)
        {
            seeking1 = false;

            if (audioFileReader1 != null && waveOutDevice1 != null)
                audioFileReader1.CurrentTime = new TimeSpan(0, 0, (int)SeekSlider1.Value);


        }

        private void DragStarted1(object sender, DragStartedEventArgs e)
        {
            seeking1 = true;
        }

        private void DragSeekSliderCompleted2(object sender, DragCompletedEventArgs e)
        {
            seeking2 = false;
            if (audioFileReader2 != null && waveOutDevice2 != null)
                audioFileReader2.CurrentTime = new TimeSpan(0, 0, (int)SeekSlider2.Value);
        }

        private void DragStarted2(object sender, DragStartedEventArgs e)
        {
            seeking2 = true;
        }

        private void VolumeSlider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Volume1();
        }

        private void VolumeSlider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Volume2();
        }

        private String FillWithZero(string testValue)
        {
            if (testValue.Length == 1)
            {
                return "0" + testValue;
            }
            else
                return testValue;
        }

        private void SeekSlider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (audioFileReader1 != null && waveOutDevice1 != null)
            {
                TimeBlock1.Text = FillWithZero(new TimeSpan(0, 0, (int)SeekSlider1.Value).Minutes.ToString()) + ":"
                    + FillWithZero(new TimeSpan(0, 0, (int)SeekSlider1.Value).Seconds.ToString()) + "/" +
                    FillWithZero(audioFileReader1.TotalTime.Minutes.ToString()) + ":" +
                    FillWithZero(audioFileReader1.TotalTime.Seconds.ToString());
            }
        }

        private void SeekSlider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (audioFileReader2 != null && waveOutDevice2 != null)
            {
                TimeBlock2.Text = FillWithZero(new TimeSpan(0, 0, (int)SeekSlider2.Value).Minutes.ToString()) + ":"
                    + FillWithZero(new TimeSpan(0, 0, (int)SeekSlider2.Value).Seconds.ToString()) + "/" +
                    FillWithZero(audioFileReader2.TotalTime.Minutes.ToString()) + ":" +
                    FillWithZero(audioFileReader2.TotalTime.Seconds.ToString());
            }
        }

        private void Volume1()
        {
            if (audioFileReader1 != null)
            {
                if (FaderSlider.Value <= 0)
                    audioFileReader1.Volume = (float)VolumeSlider1.Value;
                else
                   audioFileReader1.Volume = (float)VolumeSlider1.Value * (1-(float)FaderSlider.Value);
            }
        }

        private void Volume2()
        {
            if (audioFileReader2 != null)
            {
                if (FaderSlider.Value >= 0)
                   audioFileReader2.Volume = (float)VolumeSlider2.Value;
                else
                   audioFileReader2.Volume = (float)VolumeSlider2.Value * (1- (-1)*(float)FaderSlider.Value);
            }
        }

        private void FaderSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Volume1();
            Volume2();
        }

        private void WavConverterB(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Multiselect = false;
            d.Filter = "AUDIO (*.mp3)|*.mp3";
            
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "AUDIO (*.wav)|*.wav";
            
            
            
            if (d.ShowDialog()==true)
            {
                s.FileName = System.IO.Path.GetFileNameWithoutExtension(d.FileName);
                if (s.ShowDialog()==true)
                {
                    foreach (String path in d.FileNames)
                    {
                        Mp3ToWav(path, s.FileName);
                    }
                }
            }
        }

        private void Mp3ToWav(string mp3File, string outputFile)
        {
            using (Mp3FileReader reader = new Mp3FileReader(mp3File))
            {
                using (WaveStream pcmStream = WaveFormatConversionStream.CreatePcmStream(reader))
                {
                    WaveFileWriter.CreateWaveFile(outputFile, pcmStream);
                }
            }
        }

        private void SavePlToDB()
        {
            if (!System.IO.File.Exists("pl.db"))
            {
                try
                {
                    SQLiteConnection connection = new SQLiteConnection("Data Source=pl.db;Version=3;");
                    SQLiteConnection.CreateFile("pl.db");
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("CREATE TABLE LIST (ID INTEGER NOT NULL" +
                        " PRIMARY KEY AUTOINCREMENT , PATH VARCHAR(255))", connection);
                    int k = cmd.ExecuteNonQuery();      //wywolanie komendy
                    cmd.CommandText = "INSERT INTO List (PATH) VALUES" +
                        " (@P)";

                    foreach (Association a in pl)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@P", DbType.String).Value = a.Path;
                        cmd.ExecuteNonQuery();
                    }
                    connection.Dispose();
                }
                catch(Exception e) {
                    
                }
            }

            else
            {
                try
                {
                    SQLiteConnection connection = new SQLiteConnection("Data Source=pl.db;Version=3;");
                    connection.Open();

                    SQLiteCommand cmd = new SQLiteCommand(connection);
                    cmd.CommandText = "delete from list";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO list (PATH) VALUES" +
                        " (@P)";

                    foreach (Association a in pl)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("@P", DbType.String).Value = a.Path;
                        cmd.ExecuteNonQuery();
                    }
                    connection.Dispose();
                }
                catch(Exception e)
                { }

            }
        }

        private void LoadPlFromDB()
        {
            if (System.IO.File.Exists("pl.db"))
            {
                pl.Clear();
                try
                {
                    SQLiteConnection connection = new SQLiteConnection("Data Source=pl.db;Version=3;");
                    connection.Open();
                    SQLiteCommand cmd = new SQLiteCommand("SELECT PATH FROM LIST", connection);
                    SQLiteDataReader rdr = null;
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        String path = (String)rdr[0]; //lub rdr[0];
                        String[] temp = path.Split('\\');
                        pl.Add(new Association() { Name = temp[temp.Length - 1], Path = path });
                    }
                    if (rdr != null)
                        rdr.Close();
                    connection.Dispose();
                }
                catch { }
                RefreshPlayList();
            }
        }

        private void ExportB_Click(object sender, RoutedEventArgs e)
        {
            SavePlToDB();
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "PLAYLIST (*.ini)|*.ini";

            if (s.ShowDialog() == true && System.IO.File.Exists("pl.db"))
            {
                System.IO.File.Copy("pl.db", s.FileName, true);
            }
        }

        private void ImportB_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Multiselect = false;
            d.Filter = "PLAYLIST (*.ini)|*.ini";

            if (d.ShowDialog() == true)
            {
                System.IO.File.Copy(d.FileName,"pl.db", true);
            }
            LoadPlFromDB();
        }

        private void TB_Click(object sender, RoutedEventArgs e)
        {
            if (Playlist.SelectedItems.Count != 0)
            {
                foreach (Items item in Playlist.SelectedItems)
                {
                    new TagWindow(FindObject(item.Name).Path).Show();
                }
            }
            else
            {
                MessageBox.Show("Zaznacz przynajmniej jedna sciezke!");
            }
            Playlist.UnselectAll();
        }
    }

    public class Items
    {
        public String Name { get; set; }
        public String Time { get; set; }
    }

}
