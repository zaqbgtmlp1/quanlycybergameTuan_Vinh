using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppQuanLyCyberGame.ViewModel
{
    public class StatisticsViewModel : BaseViewModel
    {
        private ObservableCollection<Bill> _bill;

        public ObservableCollection<Bill> Bills
        {
            get { return _bill; }
            set
            {
                _bill = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<Bill> _bills;

        public ObservableCollection<Bill> Billss
        {
            get { return _bills; }
            set 
            {
                _bills = value;
                OnPropertyChanged();

            }
        }
        private DateTime _startDate = DateTime.Now;
        private DateTime _endDate = DateTime.Now;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        public ICommand FilterCommand { get; }
        public ICommand ClearFilterCommand { get; }

        public StatisticsViewModel()
        {
            LoadData();
            FilterCommand = new RelayCommand<object>(param => true, param => FilterData());
            ClearFilterCommand = new RelayCommand<object>(param => true, param => ClearFilter());

        }

        private void FilterData()
        {
            // Thực hiện lọc dữ liệu dựa trên StartDate và EndDate
            LoadData();
            var filteredData = _bill.Where(b => b.orderat >= _startDate && b.orderat <= _endDate.AddDays(1)).ToList();

            // Gán dữ liệu đã lọc vào ObservableCollection
            Bills = new ObservableCollection<Bill>(filteredData);
            

        }
        private void LoadData()
        {

            var dataProvider = DataProvider.Ins;
            var billFromDatabase = dataProvider.GetBills();
            
            // Gán dữ liệu vào ObservableCollection
           
            Bills = new ObservableCollection<Bill>(billFromDatabase);
            TotalAmount = Convert.ToDecimal(Bills.Sum(b => b.Total));

        }
        private void ClearFilter()
        {
            // Đặt lại StartDate và EndDate để bỏ lọc
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;

            // Load lại dữ liệu gốc
            LoadData();
        }

        private RelayCommand<object> _navigateToDashboardCommand;

        public ICommand NavigateToDashboardCommand
        {
            get
            {
                if (_navigateToDashboardCommand == null)
                {
                    _navigateToDashboardCommand = new RelayCommand<object>(
                        p => true, // Bạn có thể thay đổi điều kiện kiểm tra có thể thực hiện lệnh hay không
                        p => NavigateToDashboard()
                    );
                }
                return _navigateToDashboardCommand;
            }
        }

        private void NavigateToDashboard()
        {
            var dashboardView = new DashboardWindow();
            dashboardView.Show();
            
        }
        private decimal _totalAmount;

        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set
            {
                if (_totalAmount != value)
                {
                    _totalAmount = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
