using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace AppQuanLyCyberGame.ViewModel
{
    public class ItemViewModel: BaseViewModel
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

        

        public ItemViewModel()
        {
            LoadData();
           
        }
    }
}
