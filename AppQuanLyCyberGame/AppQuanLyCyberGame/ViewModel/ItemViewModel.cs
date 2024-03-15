using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private RelayCommand<object> _addItemCommand;

        public ICommand AddItemCommand
        {
            get
            {
                if (_addItemCommand == null)
                {
                    _addItemCommand = new RelayCommand<object>(
                        p => true,
                        p => NavigateToAddItemView()
                    );
                }
                return _addItemCommand;
            }
        }

        private void NavigateToAddItemView()
        {
            var AddItemView = new AddItemView();
            
            AddItemView.ShowDialog();

        }




       



    }
}
