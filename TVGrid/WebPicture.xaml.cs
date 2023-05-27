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

namespace TVGrid
{
    /// <summary>
    /// Логика взаимодействия для WebPicture.xaml
    /// </summary>
    public partial class WebPicture : Window
    {
        private string title;

        public WebPicture(string title)
        {
            InitializeComponent();
            this.title = title;

            lblTitle.Content = title;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            wbPictures.Navigate($"https://www.google.com/search?q={title}&tbm=isch&sa=X");
        }

    }
}
