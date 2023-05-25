using System;
using System.Collections.Generic;
using System.Globalization;
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
using TVGrid.DTOs;

namespace TVGrid
{
    public class TimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime time)
            {
                // Преобразовать значение времени в нужный формат
                return time.ToString("HH:mm:ss");
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    /// <summary>
    /// Логика взаимодействия для PornductionProgram.xaml
    /// </summary>
    public partial class PornductionProgram : Window
    {
        PlayListController playercontr = new PlayListController();
        public PornductionProgram()
        {

            InitializeComponent();

            LoudData();
            MailList.ItemsSource = scu;
        }

        List<ProgramDTO> scu = new List<ProgramDTO>();
        public  void LoudData()
        {
     //       scu =  playercontr.GetAllPrograms();
     
        }
        private async Task Page_Loaded(object sender, RoutedEventArgs e)
        {
            scu = await playercontr.GetAllPrograms();
        }

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                Description.Text =  scu[item.TabIndex].Description;
                Duration.Text =  scu[item.TabIndex].Duration.ToString();
            }
        }
    }
}
