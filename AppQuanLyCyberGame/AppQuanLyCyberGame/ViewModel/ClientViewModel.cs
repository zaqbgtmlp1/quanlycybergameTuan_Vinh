using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AppQuanLyCyberGame.ViewModel
{
    public class ClientViewModel : BaseViewModel
    {


        private readonly DispatcherTimer _timer;
        private TimeSpan _elapsedTime;
        private int _minuteCounter;
        private int _remainingTime = Convert.ToInt32((UserAccount.Instance.LoggedInUser.balance / 10000) * 60);

        public ClientViewModel()
        {
            _timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, TimerTick, Dispatcher.CurrentDispatcher);
            _timer.Start(); // Bắt đầu đồng hồ khi ViewModel được khởi tạo
            
            
            
            SelectedUser = UserAccount.Instance.LoggedInUser;


            

            int hours = _remainingTime / 60;
            int minutes = _remainingTime % 60;


            FormattedTime = $"{hours:00}:{minutes:00}";

            

        }

        private void TimerTick(object sender, EventArgs e)
        {
            ElapsedTime = ElapsedTime.Add(TimeSpan.FromSeconds(1));
            OnPropertyChanged(nameof(ElapsedTime));

            _minuteCounter++;
            if (_minuteCounter >= 60)
            {
                _minuteCounter = 0;
               
                
                updatebalance();

                SelectedUser = DataProvider.Ins.GetUserById(2);
                OnPropertyChanged(nameof(SelectedUser));

              

                _remainingTime = Convert.ToInt32((UserAccount.Instance.LoggedInUser.balance / 10000) * 60);
                int hours = _remainingTime / 60;
                int minutes = _remainingTime % 60;
                FormattedTime = $"{hours:00}:{minutes:00}";
                
            }
        }

        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            set
            {
                _elapsedTime = value;
                OnPropertyChanged(nameof(ElapsedTime));
            }
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private void updatebalance()

        {
            DataProvider.Ins.UpdateBalance(UserAccount.Instance.LoggedInUser.Id, 1, 1);
        }


        



        private string _formattedTime;
        public string FormattedTime
        {
            get { return _formattedTime; }
            set
            {
                _formattedTime = value;
                OnPropertyChanged(nameof(FormattedTime));
            }
        }



        private RelayCommand<object> _logoutCommand;



        public ICommand LogoutCommand
        {
            get
            {
                if (_logoutCommand == null)
                {
                    _logoutCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => Logout()
                    ); ;

                }
                return _logoutCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private void Logout()
        {

            Application.Current.Shutdown();


        }


        private RelayCommand<object> _chargeMoneyCommand;



        public ICommand ChargeMoneyCommand
        {
            get
            {
                if (_chargeMoneyCommand == null)
                {
                    _chargeMoneyCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => ChargeMoney()
                    ); ;

                }
                return _chargeMoneyCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private Process _browserProcess;
        private void ChargeMoney()
        {
            try
            {
                _browserProcess = Process.Start("http://localhost:8000");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở trình duyệt web: " + ex.Message);
            }
        }

        private void CheckBrowserStatus()
        {
            Task.Run(() =>
            {
                while (_browserProcess != null && !_browserProcess.HasExited)
                {
                    Thread.Sleep(1000); // Chờ 1 giây trước khi kiểm tra lại

                    if (_browserProcess.HasExited)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            MessageBox.Show("Trình duyệt web đã đóng.");
                        });
                    }
                }
            });
        }


        private RelayCommand<object> _chatCommand;
        public ICommand ChatCommand
        {
            get
            {
                if (_chatCommand == null)
                {
                    _chatCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => Chat()
                    ); ;

                }
                return _chatCommand;
            }
        }

        // Thêm các thuộc tính và logic khác tại đây

        private void Chat()
        {
            
            var chatWindow = new BasicChatWindow();

            chatWindow.Show();


        }



    }
    
}
