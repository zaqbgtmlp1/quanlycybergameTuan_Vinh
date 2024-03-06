using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppQuanLyCyberGame.ViewModel
{
    public class MainViewModel : BaseViewModel
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

        private ObservableCollection<ClientComputer> _Client;

        public ObservableCollection<ClientComputer> Clients
        {
            get { return _Client; }
            set
            {
                _Client = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {

            var dataProvider = DataProvider.Ins;
            var ccFromDatabase = dataProvider.GetClientComputer();
            // Gán dữ liệu vào ObservableCollection
            Clients = new ObservableCollection<ClientComputer>(ccFromDatabase);


        }
    }

}
