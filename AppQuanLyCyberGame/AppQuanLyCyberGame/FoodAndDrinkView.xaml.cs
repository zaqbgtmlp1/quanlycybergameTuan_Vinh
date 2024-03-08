using AppQuanLyCyberGame.Model;
using AppQuanLyCyberGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppQuanLyCyberGame
{
    /// <summary>
    /// Interaction logic for FoodAndDrinkView.xaml
    /// </summary>
    public partial class FoodAndDrinkView : Window
    {
        public FoodAndDrinkView()
        {
            InitializeComponent();
        }

        private void OnBorderClicked(object sender, MouseButtonEventArgs e)
        {
            // Lấy Item tương ứng từ DataContext của Border
            Item selectedItem = (sender as FrameworkElement)?.DataContext as Item;

            if (selectedItem != null)
            {
                // Tạo một instance mới của ItemDetailViewModel và chuyển nó vào DetailView
                ItemDetailViewModel itemDetailViewModel = new ItemDetailViewModel(selectedItem);
                ItemDetailView detailView = new ItemDetailView();
                detailView.DataContext = itemDetailViewModel;
                detailView.ShowDialog();
            }
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            // Đặt con trỏ chuột thành biểu tượng khác khi di chuột qua
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            // Đặt lại con trỏ chuột khi di chuột ra khỏi Border
            Mouse.OverrideCursor = null;
        }
    }
}
