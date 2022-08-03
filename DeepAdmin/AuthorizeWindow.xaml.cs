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
using DeepMovie.Common;
using DeepMovie.Common.RequestModels;
using DeepMovie.Common.ResponseModels;

namespace DeepAdmin
{
    public partial class AuthorizeWindow : Window
    {

        public AuthorizeWindow()
        {
            InitializeComponent();
        }

        private async void Authorize_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var request = new LoginRequest
            {
                Login = login.Text,
                Password = password.Text
            };

            var response = await HttpService<LoginRequest, LoginResponse>.Post(request,"api/user/login");
            if (response.IsSuccessful)
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();

            }
            else
            {
                alert.Opacity = 1;
                this.Show();
            }

        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            alert.Opacity = 0;
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {
            alert.Opacity = 0;
        }
    }
}
