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
            var itemsFromDatabase = dataProvider.GetItems();
      
            var sortedItems = itemsFromDatabase.OrderByDescending(item => item.ordered);
     
            Items = new ObservableCollection<Item>(sortedItems);
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

        

       

        public void AddToCart(Item item)
        {
            Item exitem = CartItems.FirstOrDefault(u => u.Id == item.Id);
            if (exitem != null)
            {
                // Mục đã tồn tại trong CartItems, cập nhật tên của nó
                
                exitem.Number++;
                MessageBox.Show(exitem.Number.ToString());
            }
            else
            {
                // Mục không tồn tại trong CartItems, thêm mới vào
                item.Number = 1;
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
           
            MessageBox.Show("Quý khách đã gọi món thành công");

            double total = 0;
            foreach (var item in CartItems)
            {
                total = total + item.Cost.GetValueOrDefault()*item.Number.GetValueOrDefault();
            }

            

            DataProvider.Ins.OrderItem(total, UserAccount.Instance.LoggedInUser.Id, "0");
           
        }






    }
}
