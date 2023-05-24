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
            //insert into [User] (FistName, LastName, PhoneNumber, RoleId, [Password], UserName) values ('Иванов', 'Иван', '+7912231', 1, 1, '1')
            //insert into [Role] (Title, Description) values ('Админ', 'Админ системы')
            MyDB db = new();
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
