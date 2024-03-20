using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppQuanLyCyberGame.ViewModel
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        
        public ItemDetailViewModel(Item selectedItem)
        {
            SelectedItem = selectedItem;
            
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
                        p => UpdateItem()
                    );;

                }
                return _updateCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private void UpdateItem()
        {
            DataProvider.Ins.UpdateItembyId(SelectedItem.Id, SelectedItem?.DisplayName, SelectedItem.Cost, SelectedItem.Number, SelectedItem.imagepath);
            
            OnPropertyChanged(nameof(SelectedItem));
            MessageBox.Show("Update Thành Công");
        }
        


        private RelayCommand<object> _hideCommand;



        public ICommand HideCommand
        {
            get
            {
                if (_hideCommand == null)
                {
                    _hideCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => HideItem()
                    ); ;

                }
                return _hideCommand;
            }
        }
        private void HideItem()
        {
            DataProvider.Ins.HideItembyId(SelectedItem.Id);
            OnPropertyChanged(nameof(SelectedItem));
            MessageBox.Show("Update Thành Công");
            
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
                if (SelectedItem != null)
                {
                    SelectedItem.imagepath = selectedImagePath;
                    OnPropertyChanged(nameof(SelectedItem));
                }
                
            }
        }


        private RelayCommand<object> _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => DeleteItem()
                    ); ;

                }
                return _deleteCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private void DeleteItem()
        {
            DataProvider.Ins.DeleteItembyId(SelectedItem.Id);

            
            MessageBox.Show("Update Thành Công");
        }



    }
}
