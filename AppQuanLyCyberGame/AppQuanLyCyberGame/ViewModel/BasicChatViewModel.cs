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
    public class BasicChatViewModel : BaseViewModel
    {
        private ObservableCollection<BasicChat> _messages = new ObservableCollection<BasicChat>();
        public ObservableCollection<BasicChat> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged(nameof(Messages));
            }
        }

        private string _newMessage;
        public string NewMessage
        {
            get { return _newMessage; }
            set
            {
                _newMessage = value;
                OnPropertyChanged(nameof(NewMessage));
            }
        }

        private RelayCommand<object> _sendMessage;
        public ICommand SendMessageCommand
        {
            get
            {
                if (_sendMessage == null)
                {
                    _sendMessage = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => SendMessage()
                    ); ;

                }
                return _sendMessage;
            }
        }



        public BasicChatViewModel()
        {
            LoadData();
        }

        private void SendMessage()
        {

            

            DataProvider.Ins.AddChat1(UserAccount.Instance.LoggedInUser.Id, 1, NewMessage);

            LoadData();

            NewMessage = "";


        }


        

        private void LoadData()
        {
            var dataProvider = DataProvider.Ins;
            var chatFromDatabase = dataProvider.GetChat1(UserAccount.Instance.LoggedInUser.Id);


            chatFromDatabase.Sort((x, y) => DateTime.Compare(x.timestamp.GetValueOrDefault(), y.timestamp.GetValueOrDefault()));

           

            Messages = new ObservableCollection<BasicChat>(chatFromDatabase);
          

        }

        
    }
}

