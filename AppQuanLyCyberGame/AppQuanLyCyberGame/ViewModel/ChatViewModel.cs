using AppQuanLyCyberGame.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppQuanLyCyberGame.ViewModel
{
    public class ChatViewModel : BaseViewModel
    {
        private string _currentMessage;
        public string CurrentMessage
        {
            get { return _currentMessage; }
            set
            {
                _currentMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendMessageCommand { get; }

        public ChatViewModel()
        {
            SendMessageCommand = new RelayCommand<object>(CanSendMessage, SendMessage);

            
        }
        private void ShowResult(string result)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                MessageBox.Show(result);
            });
        }

        private bool CanSendMessage(object parameter)
        {
            // Implement your logic here to determine if sending message is allowed
            return true;
        }

        private void SendMessage(object parameter)
        {
            // Logic to send message
            
            Chat newChat = new Chat
            {
                Mess = CurrentMessage // Assuming Mess is where the message content is stored in Chat class
            };
            Chat.Add(newChat);



            Task.Run(async () =>
            {
                string productName = "Product Name"; // Thay đổi tên sản phẩm tùy ý
                string result = await CallFlaskServerAsync(newChat.Mess);

                Chat newResp = new Chat
                {
                    Mess = result // Assuming Mess is where the message content is stored in Chat class
                };
                MessageBox.Show(newResp.Mess);
                ;
            });



            

            
            CurrentMessage = string.Empty; // Clear the text box after sending message
        }

        private ObservableCollection<Chat> _chat = new ObservableCollection<Chat>();
        public ObservableCollection<Chat> Chat
        {
            get { return _chat; }
            set
            {
                _chat = value;
                OnPropertyChanged(nameof(Chat));
            }
        }


        public static async Task<string> CallFlaskServerAsync(string product_name)
        {
            // Tạo một HttpClient để gửi yêu cầu đến máy chủ Flask
            using (var client = new HttpClient())
            {
                // Đặt URL của máy chủ Flask
                string url = "http://localhost:5000/chatbot"; // Thay đổi URL nếu cần

                try
                {
                    // Tạo dữ liệu JSON từ thông tin sản phẩm
                    var requestData = new { product_name };

                    // Chuyển đổi dữ liệu thành chuỗi JSON
                    var jsonContent = JsonConvert.SerializeObject(requestData);

                    // Tạo nội dung yêu cầu từ chuỗi JSON
                    var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                    // Gửi yêu cầu POST đến máy chủ Flask và nhận phản hồi
                    HttpResponseMessage response = await client.PostAsync(url, httpContent);

                    // Đọc nội dung phản hồi từ máy chủ Flask
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
