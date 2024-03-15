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
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
            InitializeComponent();
        }

        private void OnListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            if (listView.SelectedItem != null)
            {
                User selectedUser = listView.SelectedItem as User;
                if (selectedUser != null)
                {
                    DetailUserViewModel userDetailViewModel = new DetailUserViewModel(selectedUser);
                    ProfileUser detailView = new ProfileUser();
                    detailView.DataContext = userDetailViewModel;
                    detailView.ShowDialog();

                }
            }

        }
    }
}
