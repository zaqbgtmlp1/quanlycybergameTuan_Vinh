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
    public class UsersViewModel : BaseViewModel
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

        

        public UsersViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            var dataProvider = DataProvider.Ins;
            var UsersFromDatabase = dataProvider.GetUsers();

            var filteredUsers = UsersFromDatabase.Where(user => user.IdRole == 1).ToList();

            Users = new ObservableCollection<User>(filteredUsers);
        }
        public ICommand ShowProfileCommand { get; private set; }
        private void ShowProfile(object parameter)
        {
            MessageBox.Show("da goi");
            // Lấy Id từ parameter và thực hiện navigation tới ProfileUser
            if (parameter is int Id)
            {
                // Tạo một instance của ProfileUserViewModel, chuyển dữ liệu cần thiết (ví dụ: userId)
                DetailUserModel profileViewModel = new DetailUserModel(Id);

                // Tạo một instance mới của ProfileUserView và chuyển nó vào
                ProfileUser profileView = new ProfileUser();
                profileView.DataContext = profileViewModel;
                profileView.Show();
            }
        }
    }
}