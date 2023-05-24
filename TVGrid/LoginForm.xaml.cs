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
            //insert into [Role] (Title, Description, UserId) values ('Админ', 'Админ системы', 1)
            MyDB db = new();
            User user = await db.User.Include(u => u.Roles).FirstOrDefaultAsync(u =>  u.UserName == tbLogin.Text && u.Password.ToString() == tbPass.Password);
            if (user == null)
            {
                lbErr.Visibility = Visibility.Visible;
                return;
            }
            App.setVar("UserName", user.LastName + " " + user.FistName);
            App.setVar("UserID", user.Id.ToString());
            App.setVar("RoleName", user.Roles.FirstOrDefault().Title);
            App.setVar("RoleID", user.Roles.FirstOrDefault().Id.ToString());
            MessageBox.Show(App.getVar("UserName"));
            MainWondow mw = new();
            mw.Show();
            Close(); 
        }
    }
}
