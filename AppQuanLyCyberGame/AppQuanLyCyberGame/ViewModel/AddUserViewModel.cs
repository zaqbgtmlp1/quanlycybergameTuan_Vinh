using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppQuanLyCyberGame.ViewModel
{
    public class AddUserViewModel : BaseViewModel
    {

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public AddUserViewModel()
        {
            SelectedUser = new User();
        }

        private RelayCommand<object> _addUserCommand;



        public ICommand AddUserCommand
        {
            get
            {
                if (_addUserCommand == null)
                {
                    _addUserCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => AddUser()
                    ); ;

                }
                return _addUserCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private void AddUser()
        {
            DataProvider.Ins.AddUser(SelectedUser);
            MessageBox.Show("Thêm thành công");
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

    }
}
