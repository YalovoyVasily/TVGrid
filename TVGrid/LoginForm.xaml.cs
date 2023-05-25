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
    public partial class LoginForm : Window
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
            MyDB db = new();

            //var dfsf = new PlayListController();

            //var D1 = new DateTime(2023, 5, 19, 07, 00, 00); //19.05.2023 2:00:00
            //var D2 = new DateTime(2023, 5, 19, 08, 02, 00); //19.05.2023 4:00:00

            //await dfsf.CanAddProgram(D1, D2);

            //var D1 = new DateTime(2023, 5, 19, 04, 01, 00); //19.05.2023 2:00:00
            //var D2 = new DateTime(2023, 5, 19, 04, 02, 00); //19.05.2023 4:00:00

            //await dfsf.CanAddProgram(D1, D2);

            //await dfsf.GetAllPrograms();

            //insert into [User] (FistName, LastName, PhoneNumber, RoleId, [Password], UserName) values ('Иванов', 'Иван', '+7912231', 1, 1, '1')
            //insert into [Role] (Title, Description) values ('Админ', 'Админ системы')
           

            

            User user = await db.User.Include(u => u.Role).FirstOrDefaultAsync(u => u.UserName == tbLogin.Text && u.Password.ToString() == tbPass.Password);
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
