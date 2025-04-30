using DataMenegment.ViewModelWindow;
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
using System.Windows.Shapes;

namespace FrontendWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            LoginViewModel loginViewModel = new LoginViewModel();
            this.DataContext = loginViewModel;
            loginViewModel.OnLoginSuccess += OpenMainWindow;
        }

        private void OpenMainWindow()
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow
            {
                Owner = this, // Устанавливаем родителя (авторизацию)
                WindowStartupLocation = WindowStartupLocation.CenterOwner // Центрируем относительно окна авторизации
            };
            registerWindow.Show(); // Просто Show, чтобы не блокировать LoginWindow
        }


    }
}
