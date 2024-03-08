using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppQuanLyCyberGame.ViewModel
{
    public class UserControlViewModel : BaseViewModel
    {
        private RelayCommand<object> _itemCommand;

        public ICommand ItemCommand
        {
            get
            {
                if (_itemCommand == null)
                {
                    _itemCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => NavigateToItemWindow()
                    );
                }
                return _itemCommand;
            }
        }

        private void NavigateToItemWindow()
        {
            var itemWindow = new FoodAndDrinkView();
            CloseCurrentView();
            itemWindow.ShowDialog();

        }




        private RelayCommand<object> _mainCommand;

        public ICommand MainCommand
        {
            get
            {
                if (_mainCommand == null)
                {
                    _mainCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => NavigateToMainWindow()
                    );
                }
                return _mainCommand;
            }
        }

        private void NavigateToMainWindow()
        {
            var mainWindow = new MainWindow();
            CloseCurrentView();
            mainWindow.ShowDialog();

        }




        private RelayCommand<object> _employeeCommand;

        public ICommand EmployeeCommand
        {
            get
            {
                if (_employeeCommand == null)
                {
                    _employeeCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => NavigateToUserWindow()
                    );
                }
                return _employeeCommand;
            }
        }

        private void NavigateToEmployeeWindow()
        {
            var userWindow = new UsersWindow();
            CloseCurrentView();
            userWindow.ShowDialog();

        }

        private RelayCommand<object> _userCommand;

        public ICommand UserCommand
        {
            get
            {
                if (_userCommand == null)
                {
                    _userCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => NavigateToUserWindow()
                    );
                }
                return _userCommand;
            }
        }

        private void NavigateToUserWindow()
        {
            var userWindow = new UsersWindow();
            CloseCurrentView();
            userWindow.ShowDialog();

        }














        private void CloseCurrentView()
        {
            // Lấy window hiện tại và đóng nó
            Window currentWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            currentWindow?.Close();
        }


    }
}
