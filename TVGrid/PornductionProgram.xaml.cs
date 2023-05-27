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
using TVGrid.Enums;

namespace TVGrid
{


    /// <summary>
    /// Логика взаимодействия для PornductionProgram.xaml
    /// </summary>
    public partial class PornductionProgram : Window
    {
        DateTime D1;
        PlayListController playercontr = new PlayListController();
        public PornductionProgram()
        {
            LoudData();
            LoudData2();
            InitializeComponent();
            Canv.Visibility = Visibility.Visible;
            basa.DisplayDate = DateTime.Now;


        }
        List<ListProgramsDTO> sschedule2 = new List<ListProgramsDTO>();
        List<Schedule> sschedule = new List<Schedule>();
       
        List<ProgramDTO> scu = new List<ProgramDTO>();
        List<ProgramDTO> adw = new List<ProgramDTO>();
        private   async Task  LoudData()
         {
           
               
            PlayListController PlayListController = new PlayListController();
          
           
            var ListProgrammsSorted = await PlayListController.Get(D1, D1.AddDays(1).Date);
            if (ListProgrammsSorted.Count >0)
            {


                TvProgram.ItemsSource = ListProgrammsSorted.Select(x => new ListProgramsDTO(x));

                TvProgram.Columns[0].Header = "Название передачи";
                TvProgram.Columns[1].Header = "Описание";
                TvProgram.Columns[2].Header = "Начало";
                TvProgram.Columns[3].Header = "Конец";
            }
        }
        private async Task LoudData2()
        {
            scu = await playercontr.GetAllPrograms();

            scu = scu.Concat( await playercontr.GetAllAdvertisement()).ToList();
            for (int i = 0; i < scu.Count; i++)
            {
                MailList.Items.Add(scu[i].Name);//поля выводить вся работа с await
            }
          


        }
      

        private void ListView_Loaded(object sender, RoutedEventArgs e)
        {

        }
     

   
        private void MailList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Description.Text = scu[MailList.SelectedIndex].Description;
            Duration.Text = scu[MailList.SelectedIndex].Duration.ToString();
        }
        private void MailList_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        {
            Description.Text = adw[MailList.SelectedIndex].Description;
            Duration.Text = adw[MailList.SelectedIndex].Duration.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canv.IsEnabled = true;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime enteredDate = DateTime.Parse(Datapic.Text);
            DateTime enteredDate2 = DateTime.Parse(datapicer.Text);
            DateTime dateTime = enteredDate2.Date.Add(enteredDate.TimeOfDay);
            DateTime endDate = dateTime.Add(scu[MailList.SelectedIndex].Duration);

            if (!await playercontr.CanAddProgram(dateTime, endDate))
            {
                sschedule.Add(new Schedule(dateTime, endDate, scu[MailList.SelectedIndex].Id));
                sschedule2.Add(new ListProgramsDTO(scu[MailList.SelectedIndex].Name , scu[MailList.SelectedIndex].Description, enteredDate.ToString(), enteredDate.ToString()));
                await playercontr.Save(sschedule);
                
            }
            await LoudData();
        }

        private async void basa_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            D1 =  basa.SelectedDate.Value.Date;
           await  LoudData();
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           


        }
    }
}
