using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicsBrowserByGawek
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> ext = new List<string>(); //rozszerzenia
        BrowserWindow bw = null;
        public String currPath = null;
        public String currentPathProperty
        {
            get
            {
                return currPath;
            }
            set
            {
                currPath = value;
                BuildAssociationList();
                degress = 0;
            }
        }
        BitmapImage bm = null;
        int degress = 0;
        double scale = 1;
        double x;
        double y;
        string currentFile = null;
        Thickness t = new Thickness();
        List<string> ls = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            PrepareExtList();
            ls.Clear(); 
            
        }

        private void BuildAssociationList()
        {
            ls.Clear();
            string[] list = System.IO.Directory.GetFiles(currPath);
            foreach(string i in list)
            {
                if (ext.Contains(System.IO.Path.GetExtension(i)))
                    ls.Add(i);
            }
        }

        private void PrepareExtList()
        {
            ext.Add(".png");
            ext.Add(".bmp");
            ext.Add(".jpg");
            ext.Add(".jpeg");
        }
        public void Show_Image(string path)
        {
            currentFile = path;
            bm = new BitmapImage();
            bm.BeginInit();
            bm.UriSource = new Uri(@path);
            if (degress == 0)
                bm.Rotation = Rotation.Rotate0;
            if (degress==90)
                bm.Rotation = Rotation.Rotate90;
            if (degress == 180)
                bm.Rotation = Rotation.Rotate180;
            if (degress == 270)
                bm.Rotation = Rotation.Rotate270;
            bm.EndInit();
            ImageBox.Source = bm;
            ImageBox.Margin = new Thickness(53, 53, 53, 53);
            Window_SizeChanged(null, null);


        }

        private void OpenButton_click(object sender, RoutedEventArgs e)
        {
            if ((bw = (BrowserWindow)checkOpenedForms(bw)) != null)
                bw.Focus();
            else
            {
                bw = new BrowserWindow();
                bw.Show();
            }
        }

        private void CloseButton_click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (ls.Count != 0)
            {
                degress = 0;
                int index = ls.IndexOf(currentFile);
                if (0 > --index)
                    index = ls.Count - 1;
                Show_Image(ls[index]);
            }
        }
        public void ShowFirst()
        {
            Show_Image(ls[0]);
            degress = 0;
        }
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (ls.Count != 0)
            {

                degress = 0;
                int index = ls.IndexOf(currentFile);
                if (ls.Count == ++index)
                    index = 0;
                Show_Image(ls[index]);
            }
        }

        private void ClockwiseButton_Click(object sender, RoutedEventArgs e)
        {
            
            if(ls.Count!=0)
            {
                degress += 90;
                if (degress == 360)
                    degress = 0;
                Show_Image(currentFile);
            }
        }

        private void CounterClockWiseButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (ls.Count != 0)
            {
                degress -= 90;
                if (degress == -90)
                    degress = 270;
                Show_Image(currentFile);
            }
            
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            if (scale > 0.4)
            {
                scale -= 0.1;
                ImageBox.Width = ImageBox.Width * 0.9;
                ImageBox.Height = ImageBox.Height * 0.9;
            }
        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            if (scale < 10)
            {
                scale += 0.1;
                ImageBox.Width = ImageBox.Width * 1.1;
                ImageBox.Height = ImageBox.Height * 1.1;
            }
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta != 0)
            {
                if (e.Delta > 0)
                {
                   ZoomIn_Click(sender, e);
                }
                if (e.Delta < 0)
                {
                    ZoomOut_Click(sender, e);
                }
            }
        }

 
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            x = p.X;
            y = p.Y;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            t.Left = e.GetPosition(this).X + ImageBox.Margin.Left - x;
            t.Top = e.GetPosition(this).Y + ImageBox.Margin.Top - y;
            ImageBox.Margin = t;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                ImageBox.Width = this.Width - 100;
                ImageBox.Height = this.Height - 150;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                ImageBox.Width = System.Windows.SystemParameters.PrimaryScreenWidth - 200;
                ImageBox.Height = System.Windows.SystemParameters.PrimaryScreenHeight - 200;
            }



        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                ImageBox.Width=System.Windows.SystemParameters.PrimaryScreenWidth-200;
                ImageBox.Height=System.Windows.SystemParameters.PrimaryScreenHeight-200;
            }
            else if(this.WindowState==WindowState.Normal)
                Window_SizeChanged(sender, null);
        }
        
    }
}
