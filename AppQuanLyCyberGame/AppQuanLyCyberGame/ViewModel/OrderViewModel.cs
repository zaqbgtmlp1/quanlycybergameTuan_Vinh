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
    public class OrderViewModel : BaseViewModel
    {
        private ObservableCollection<Item> _items;



        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }





        private void LoadData()
        {
            var dataProvider = DataProvider.Ins;
            var itemFromDatabase = dataProvider.GetItems();
            Items = new ObservableCollection<Item>(itemFromDatabase);
        }



        public OrderViewModel()
        {
            LoadData();

        }


        private string _filterText;



        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (_filterText != value)
                {
                    _filterText = value;
                    OnPropertyChanged(nameof(FilterText));
                    FilterItems();
                }
            }
        }

        private void FilterItems()
        {
            if (!string.IsNullOrEmpty(FilterText))
            {
                LoadData();
                var normalizedFilterText = FilterText.Normalize(NormalizationForm.FormD);
                var filteredItems = new ObservableCollection<Item>(
                    Items.Where(item =>
                        item.DisplayName.Normalize(NormalizationForm.FormD).ToLower().Contains(normalizedFilterText.ToLower())
                    )
                );
                Items = filteredItems;
            }
            else
            {
                LoadData();
            }
        }

        private ObservableCollection<Item> _cartItems = new ObservableCollection<Item>();
        public ObservableCollection<Item> CartItems
        {
            get { return _cartItems; }
            set
            {
                _cartItems = value;
                OnPropertyChanged(nameof(CartItems));
            }
        }

        private RelayCommand<object> _addToCartCommand;

       

        public void AddToCart(Item item)
        {
            item.Number = 1;
            if (!CartItems.Contains(item))
            {
                CartItems.Add(item);
            }
        }

        private RelayCommand<object> _orderCommand;



        public ICommand OrderCommand
        {
            get
            {
                if (_orderCommand == null)
                {
                    _orderCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => OrderItem()
                    ); ;

                }
                return _orderCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private void OrderItem()
        {
           
            MessageBox.Show("Update Thành Công");

            double total = 0;
            foreach (var item in CartItems)
            {
                total = total + item.Cost.GetValueOrDefault()*item.Number.GetValueOrDefault();
            }

            int IDuser = 1;

            MessageBox.Show(total.ToString());
            DataProvider.Ins.OrderItem(total, 1, "0");
           
        }






    }
}
