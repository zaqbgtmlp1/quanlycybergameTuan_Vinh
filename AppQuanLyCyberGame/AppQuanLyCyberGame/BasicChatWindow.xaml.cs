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
    /// Interaction logic for BasicChatWindow.xaml
    /// </summary>
    public partial class BasicChatWindow : Window
    {
        public BasicChatWindow()
        {
            InitializeComponent();
        }



        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null && listBox.Items.Count > 0)
            {
                listBox.ScrollIntoView(listBox.Items[listBox.Items.Count - 1]);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Cuộn xuống cuối của ListBox
            ListBox.ScrollIntoView(ListBox.Items[ListBox.Items.Count - 1]);
        }

        private void ScrollListBoxToBottom()
        {
            ListBox.ScrollIntoView(ListBox.Items[ListBox.Items.Count - 1]);
        }
    }




}
