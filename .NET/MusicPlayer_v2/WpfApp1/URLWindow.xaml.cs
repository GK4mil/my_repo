using System;
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
    /// Logika interakcji dla klasy URLWindow.xaml
    /// </summary>
    public partial class URLWindow : Window
    {
        public URLWindow()
        {
            InitializeComponent();
            URLAddress_field.Focus();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                WebRequest request = WebRequest.Create(URLAddress_field.Text);
                request.GetResponse();
                PlaylistWindow.pl.Add(new Association() { Name = URLAddress_field.Text, Path = URLAddress_field.Text });
                if (MainWindow.pl != null)
                    MainWindow.pl.RefreshPlayList();
                

                Close();
            }
            catch 
            {
                MessageBox.Show("Adres niepoprawny");
                URLAddress_field.Focus();
                URLAddress_field.SelectAll();
            }
            
        }
    }
}
