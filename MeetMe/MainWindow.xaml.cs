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

namespace MeetMe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginService loginService = new LoginService();
            
           Response response =  await loginService.Login(email.Text,password.Text);
            if (response.Member != null)
            {
                MessageBox.Show($"{response.Member.FirstName},{response.AutoLoginToken},{response.MebmberId}");
                

            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }
    }
}
