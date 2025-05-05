using ClickerApp.ViewModels.Base;
using DataMenegment.ViewModel;
using StoreDB.ContextDB;
using StoreDB.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataMenegment.ViewModelWindow
{
    public class RegisterViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _role;
        private string _status;

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(ExecuteRegister);
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

        public RelayCommand RegisterCommand { get; }

        private bool CanRegister(object obj)
        {
            return !string.IsNullOrWhiteSpace(Username) &&
                   !string.IsNullOrWhiteSpace(Password) &&
                   !string.IsNullOrWhiteSpace(Role);
        }

        private void ExecuteRegister(object obj)
        {
            using (var db = new SQLServerDBContext())
            {
                if (db.Users.Any(u => u.Username == Username))
                {
                    Status = "Пользователь с таким логином уже существует.";
                    return;
                }

                var user = new User
                {
                    Username = Username,
                    Password = Password,
                    Role = Role
                };

                db.Users.Add(user);
                db.SaveChanges();

                Status = "Регистрация прошла успешно!";
            }
        }
    }
}
