using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
