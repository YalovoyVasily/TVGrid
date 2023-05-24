using Microsoft.EntityFrameworkCore;
using System;
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


namespace TVGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginForm: Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            var dfsf = new PlayListController();


            //insert into [User] (FistName, LastName, PhoneNumber, RoleId, [Password], UserName) values ('Иванов', 'Иван', '+7912231', 1, 1, '1')
            //insert into [Role] (Title, Description) values ('Админ', 'Админ системы')
            MyDB db = new();

            //var dff =new DateTime(2023,5,19,00,00,00); //2023-05-19 00:00:00.000
            //var dff1 =new DateTime(2023,5,19,23,59,59); //2023-05-19 00:00:00.000

            //await dfsf.Get(dff, dff1);

            //var Schedule1 = new Schedule();

            //Schedule1.TimeStart= new DateTime(2023, 5, 19, 00, 00, 00);
            //Schedule1.TimeEnd= new DateTime(2023, 5, 19, 23, 59, 59);
            //Schedule1.ProgramID= 2;
            

            //var Schedule2 = new Schedule();

            //Schedule2.TimeStart = new DateTime(2024, 7, 19, 00, 00, 00);
            //Schedule2.TimeEnd = new DateTime(2024, 7, 19, 23, 59, 59);
            //Schedule2.ProgramID = 2;

            //var Schedulelist= new List<Schedule>() {Schedule1, Schedule2 };

            //await dfsf.Save(Schedulelist);

            //var Schedule3 = new Schedule();

            //Schedule3.TimeStart = new DateTime(2000, 7, 19, 00, 00, 00);
            //Schedule3.TimeEnd = new DateTime(2000, 7, 19, 23, 59, 59);
            //Schedule3.ProgramID = 1;
            //Schedule3.Id = 12;

            //var SchedulelistToUpdate = new List<Schedule>() { Schedule3 };

            //await dfsf.Update(SchedulelistToUpdate);


            var Schedule3 = new Schedule();

            Schedule3.TimeStart = new DateTime(2000, 7, 19, 00, 00, 00);
            Schedule3.TimeEnd = new DateTime(2000, 7, 19, 23, 59, 59);
            Schedule3.ProgramID = 1;
            Schedule3.Id = 12;

            var Schedule4 = new Schedule();

            Schedule4.TimeStart = new DateTime(2000, 7, 19, 00, 00, 00);
            Schedule4.TimeEnd = new DateTime(2000, 7, 19, 23, 59, 59);
            Schedule4.ProgramID = 1;
            Schedule4.Id = 14;

            var SchedulelistToDelete = new List<Schedule>() { Schedule3, Schedule4 };

            await dfsf.Delete(SchedulelistToDelete);


            User user = await db.User.Include(u => u.Role).FirstOrDefaultAsync(u =>  u.UserName == tbLogin.Text && u.Password.ToString() == tbPass.Password);
            if (user == null)
            {
                lbErr.Visibility = Visibility.Visible;
                return;
            }

            //Для получения параметров из любой части приложения App.getVar("UserName")
            App.setVar("UserName", user.LastName + " " + user.FistName);
            App.setVar("UserID", user.Id.ToString());
            App.setVar("RoleName", user.Role.Title);
            App.setVar("RoleID", user.Role.Id.ToString());
            MainWindow mw = new();
            mw.Show();
            Close(); 
        }
    }
}
