using System;
using System.Collections.Generic;
using System.IO;
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
using TagLib;

namespace AudioMixerGawek
{
    /// <summary>
    /// Logika interakcji dla klasy TagWindow.xaml
    /// </summary>
    public partial class TagWindow : Window
    {
        public TagWindow(string path)
        {
            InitializeComponent();
            Refresh(path);
        }
        public void Refresh(string path)
        {
            TagLib.File file = TagLib.File.Create(path);
            Textbox1.Text = "Nazwa pliku:"+ Environment.NewLine+System.IO.Path.GetFileName(path)+ Environment.NewLine + "Bitrate: " + file.Properties.AudioBitrate + "kbps, " + Environment.NewLine
                + file.Tag.FirstPerformer + " " + Environment.NewLine
                + file.Tag.Album + " "
                + Environment.NewLine
                + file.Tag.Comment + " "
                + Environment.NewLine
                + file.Tag.Lyrics + " "
                + Environment.NewLine
                + file.Tag.Title + " "
                + Environment.NewLine
                + file.Tag.Year + " ";
            ;
            if (file.Tag.Pictures.Length >= 1)
            {
                var bin = (byte[])(file.Tag.Pictures[0].Data.Data);

                using (MemoryStream stream = new MemoryStream(bin))
                {
                    image.Source = BitmapFrame.Create(stream,
                                                      BitmapCreateOptions.None,
                                                      BitmapCacheOption.OnLoad);
                }
            }
            else
                image.Source = null;
        }

    }

}

