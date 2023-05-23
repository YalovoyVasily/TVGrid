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
            this.Close();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            //insert into [User] (FistName, LastName, PhoneNumber, RoleId, [Password], UserName) values ('Иванов', 'Иван', '+7912231', 1, 1, '1')
            //insert into [Role] (Title, Description, UserId) values ('Админ', 'Админ системы', 1)
            MyDB db = new();
            int users = db.User.Where(u => u.UserName == this.tbLogin.Text && u.Password.ToString() == this.tbPass.Password).Count();
            if (users <= 0)
            {
                this.lbErr.Visibility = Visibility.Visible;
                return;
            }
            MainWondow mw = new();
            mw.Show();
            this.Close(); 
        }
    }
}
