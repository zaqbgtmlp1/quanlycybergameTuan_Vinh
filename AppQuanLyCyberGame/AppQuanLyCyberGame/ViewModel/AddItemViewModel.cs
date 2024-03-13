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
    public class AddItemViewModel : BaseViewModel
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

        public AddItemViewModel()
        {
            SelectedItem = new Item();
        }

        private RelayCommand<object> _addItemCommand;



        public ICommand AddItemCommand
        {
            get
            {
                if (_addItemCommand == null)
                {
                    _addItemCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => AddItem()
                    ); ;

                }
                return _addItemCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private void AddItem()
        {
            DataProvider.Ins.AddItem(SelectedItem.DisplayName, SelectedItem.Cost, SelectedItem.Number);
            MessageBox.Show("Thêm thành công");
        }
    }
}
