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
    

    /// <summary>
    /// Логика взаимодействия для PornductionProgram.xaml
    /// </summary>
    public partial class PornductionProgram : Window
    {
        PlayListController playercontr = new PlayListController();
        public PornductionProgram()
        {
            LoudData();
            InitializeComponent();

         
          
        }
        List<Schedule> sschedule = new List<Schedule>();
        List<ProgramDTO> scu = new List<ProgramDTO>();
         private   async Task  LoudData()
         {
            scu = await  playercontr.GetAllPrograms();
            for(int i = 0; i < scu.Count; i++)
            {
                MailList.ItemsSource += scu[i].Name;//поля выводить вся работа с await
            }
           

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
            ListViewItem clickedItem = sender as ListViewItem;
            int var = MailList.SelectedIndex;
            // Проверка, что нажатие произошло на элементе
            if (clickedItem != null)
            {
                // Получить индекс элемента в коллекции Items ListView
                int index = MailList.SelectedIndex;
                Description.Text = scu[MailList.SelectedIndex].Description;
                Duration.Text = scu[MailList.SelectedIndex].Duration.ToString();
                // Выполнить нужные действия с индексом элемента
                // Например, обновить другие элементы управления с использованием индекса
            }
            //var item = sender as ListViewItem;
            //if (item != null && item.IsSelected)
            //{
            //    Description.Text =  scu[item.TabIndex].Description;
            //    Duration.Text =  scu[item.TabIndex].Duration.ToString();
            //}
        }

   
        private void MailList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Description.Text = scu[MailList.SelectedIndex].Description;
            Duration.Text = scu[MailList.SelectedIndex].Duration.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canv.IsEnabled = true;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime enteredDate = DateTime.Parse(Datapic.Text);
            DateTime endDate = enteredDate.Add(scu[MailList.SelectedIndex].Duration);

            if (!await playercontr.CanAddProgram(enteredDate, endDate))
            {
                sschedule.Add(new Schedule(enteredDate, endDate, scu[MailList.SelectedIndex]);
            }
           
        }
    }
}
