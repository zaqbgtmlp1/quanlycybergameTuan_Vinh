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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {

        public OrderWindow()
        {
            InitializeComponent();

            

           
        }
        
        private void OnBorderClicked(object sender, MouseButtonEventArgs e)
        {
            Item selectedItem = (sender as FrameworkElement)?.DataContext as Item;
            OrderViewModel viewModel = DataContext as OrderViewModel;

            viewModel.AddToCart(selectedItem);

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
