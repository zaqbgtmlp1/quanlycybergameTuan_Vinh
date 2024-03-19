using AppQuanLyCyberGame.Model;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using NumSharp;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Diagnostics;
using Newtonsoft.Json;
using Python.Runtime;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json.Linq;

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

        private ObservableCollection<Item> _recommendItems = new ObservableCollection<Item>();
        public ObservableCollection<Item> RecommendItems
        {
            get { return _recommendItems; }
            set
            {
                _recommendItems = value;
                OnPropertyChanged(nameof(_recommendItems));
            }
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
                RecommendItems = filteredItems;


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
            if (item.Number > 0)
            {
                Item exitem = CartItems.FirstOrDefault(u => u.Id == item.Id);
                if (exitem != null)
                {
                    // Mục đã tồn tại trong CartItems, cập nhật tên của nó
                    exitem.Number++;

                }
                else
                {
                    // Mục không tồn tại trong CartItems, thêm mới vào
                    CartItems.Add(item);
                    string[] resultArray = null;
                    Task.Run(async () =>
                    {
                        string jsonResult = await CallFlaskServerAsync1(item.DisplayName);
                        if (!string.IsNullOrEmpty(jsonResult))
                        {
                            // Chuyển đổi chuỗi JSON thành mảng chuỗi
                            resultArray = JsonConvert.DeserializeObject<string[]>(jsonResult);

                            // Tạo chuỗi từ mảng chuỗi
                            string resultString = string.Join(", ", resultArray);

                            // Hiển thị chuỗi trong MessageBox       
                        }
                        else
                        {
                            MessageBox.Show("Empty response from server");
                        }
                    }).Wait();

                    foreach (var itemname in resultArray)
                    {
                        // Hiển thị từng thành phần trong mảng
                        Item rItem = DataProvider.Ins.GetItemByName(itemname);

                        if (rItem != null)
                        {

                            RecommendItems.Add(rItem);
                        }
                        else
                        {
                            MessageBox.Show("Item is null");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Sản phẩm hiện đã bạn hết");
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
                DataProvider.Ins.UpdateNumItem(item.Id, 1, 1);
            }

            DataProvider.Ins.OrderItem(total, UserAccount.Instance.LoggedInUser.Id, "0");

            CartItems.Clear();

            
           
        }

        private async Task CallFlaskServer(string item_name)
        {
            var client = new HttpClient();

            // Set the URL of your Flask server
            string url = "http://localhost:5000/predict";
            MessageBox.Show("Bat dau");
            // Prepare your data
            var data = new StringContent(JsonConvert.SerializeObject(new { product_name = item_name }), System.Text.Encoding.UTF8, "application/json");

          

            MessageBox.Show("Gui");
            // Gửi yêu cầu POST đến URL và nhận kết quả
            HttpResponseMessage response = await client.PostAsync(url, data);

            MessageBox.Show("Nhan");
            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Check");
                // Read the response and show predictions in a MessageBox
            
                var result = await response.Content.ReadAsStringAsync();
               
                

                MessageBox.Show(result);
            }
            else
            {
                // Show error message in a MessageBox
                MessageBox.Show("Error: " + response.ReasonPhrase, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("   2    ");
            }
        }


        static async Task<string> CallFlaskServerAsync1(string product_name)
        {
            // Tạo một HttpClient để gửi yêu cầu đến Flask server
            using (var client = new HttpClient())
            {
                // Đặt URL của Flask server
                string url = "http://localhost:5000/predict"; // Thay đổi URL nếu cần

                try
                {
                    // Gửi yêu cầu GET đến Flask server và nhận phản hồi
                    var data = new StringContent(JsonConvert.SerializeObject(new { product_name}), System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, data);

                    // Đọc phản hồi từ Flask server
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        return responseContent;
                    }
                    else
                    {
                        return "Error: " + response.ReasonPhrase;
                    }
                }
                catch (HttpRequestException e)
                {
                    return "Error: " + e.Message;
                }
            }
        }









    }
}
