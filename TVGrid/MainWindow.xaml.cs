using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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
using TVGrid.DTOs;
using TVGrid.Enums;

namespace TVGrid
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PornductionProgram PrnProg = new();
            PrnProg.Show();
            Close();
        }



        //Получение данныз
        private async void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            lblUserName.Content = App.getVar("UserName");
            if (App.getVar("RoleName") == "Админ")
                btEdit.IsEnabled = true;

            PlayListController PlayListController = new PlayListController();


            var ListProgrammsSorted = await PlayListController.Get(DateTime.Now.Date, DateTime.Now.AddDays(1).Date);

            ListProgrammsSorted = ListProgrammsSorted.Where(x => x.Program.ProgramTypeDictionaryID == (int)ProgramEnum.Program);

            dgShedule.ItemsSource = ListProgrammsSorted.Select(x => new ListProgramsDTO(x));

            dgShedule.Columns[0].Header = "Название передачи";
            dgShedule.Columns[1].Header = "Описание";
            dgShedule.Columns[2].Header = "Начало";
            dgShedule.Columns[3].Header = "Конец";

        }
    }



}
