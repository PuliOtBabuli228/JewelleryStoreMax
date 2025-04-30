using ClickerApp.ViewModels.Base;
using DataMenegment.ViewModel;
using StoreDB.ContextDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataMenegment.ViewModelWindow
{
    public class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _role;
        private string _status;

        public event Action? OnLoginSuccess;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
            Roles = new ObservableCollection<string> { "admin", "manager", "seller" };
        }

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string Role
        {
            get => _role;
            set { _role = value; OnPropertyChanged(nameof(Role)); }
        }

        public ObservableCollection<string> Roles { get; }

        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(nameof(Status)); }
        }

        public RelayCommand LoginCommand { get; }

        private bool CanLogin(object obj)
        {
            return !string.IsNullOrWhiteSpace(Username) &&
                   !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLogin(object obj)
        {
            using (var db = new SQLServerDBContext())
            {
                var user = db.Users.FirstOrDefault(u =>
                    u.Username == Username &&
                    u.Password == Password);

                if (user != null)
                {
                    Status = "Вход выполнен успешно.";
                    OnLoginSuccess.Invoke();
                    // можно открыть главное окно и закрыть текущее
                }
                else
                {
                    Status = "Неверные данные.";
                }
            }
        }

    }
}
