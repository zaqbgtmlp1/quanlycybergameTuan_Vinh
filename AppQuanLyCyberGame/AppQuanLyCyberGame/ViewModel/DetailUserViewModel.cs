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
    public class DetailUserViewModel : BaseViewModel
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


        public DetailUserViewModel(User selectedUser)
        {
            SelectedUser = selectedUser;

        }


        private RelayCommand<object> _updateCommand;



        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => UpdateUser()
                    ); ;

                }
                return _updateCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private void UpdateUser()
        {
            DataProvider.Ins.UpdateUserbyId(SelectedUser.Id, SelectedUser.DisplayName, SelectedUser.Password, SelectedUser.Phonenumber, SelectedUser.Useraddress, SelectedUser.avatar);
            OnPropertyChanged(nameof(_selectedUser));
        }



        private RelayCommand<object> _changeImageCommand;

        public ICommand ChangeImageCommand
        {
            get
            {
                if (_changeImageCommand == null)
                {
                    _changeImageCommand = new RelayCommand<object>(
                        p => true,
                        p => ChangeImage()
                    );
                }
                return _changeImageCommand;
            }
        }


        private void ChangeImage()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Chắc chắn rằng SelectedItem không null
                if (SelectedUser != null)
                {
                    SelectedUser.avatar = selectedImagePath;
                    OnPropertyChanged(nameof(SelectedUser));
                }

            }
        }


        private RelayCommand<object> _chatCommand;
        public ICommand ChatCommand
        {
            get
            {
                if (_chatCommand == null)
                {
                    _chatCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => Chat()
                    ); ;

                }
                return _chatCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private void Chat()
        {
            MessageBox.Show("OK");
            var chatWindow = new BasicChatWindow();

            chatWindow.Show();


        }


    }
}
