using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppQuanLyCyberGame.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(_selectedUser));
            }
        }


        public LoginViewModel()
        {
            SelectedUser = new User();
        }


        private RelayCommand<object> _loginCommand;



        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand<object>(
                        p => true,
                        p => Login()
                    ); ;

                }
                return _loginCommand;
            }
        }
        private void Login()
        {

            var user = DataProvider.Ins.LoginApp(SelectedUser.UserName, SelectedUser.Password);

            if (user != null)
            {
                UserAccount.Instance.LoggedInUser = user;

                if ( user.IdRole == 3)
                {
                    var orderWindow = new OrderWindow();
                    CloseCurrentView();
                    orderWindow.ShowDialog();
                }
                else
                {
                    var mainWindow = new MainWindow();
                    CloseCurrentView();
                    mainWindow.ShowDialog();
                }
                

            }    
                
            else
                MessageBox.Show("Fail");
        }

        private void CloseCurrentView()
        {
            // Lấy window hiện tại và đóng nó
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            currentWindow?.Close();
        }
    }
}
