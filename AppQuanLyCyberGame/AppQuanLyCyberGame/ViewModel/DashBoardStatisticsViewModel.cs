using AppQuanLyCyberGame.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AppQuanLyCyberGame.ViewModel
{
    public class DashBoardStatisticsViewModel : BaseViewModel
    {
        private ObservableCollection<Bill> _bills;

        public ObservableCollection<Bill> Bills
        {
            get { return _bills; }
            set
            {
                _bills = value;
                OnPropertyChanged();
            }
        }

        private SeriesCollection _seriesCollection;
        private ObservableCollection<string> _labels;

        public SeriesCollection SeriesCollection
        {
            get { return _seriesCollection; }
            set
            {
                _seriesCollection = value;
                OnPropertyChanged(nameof(SeriesCollection));
            }
        }

        public ObservableCollection<string> Labels
        {
            get { return _labels; }
            set
            {
                _labels = value;
                OnPropertyChanged(nameof(Labels));
            }
        }

        private int _selectedMonth= DateTime.Now.Month;
        private int _selectedYear = DateTime.Now.Year;

        public ObservableCollection<int> Months { get; } = new ObservableCollection<int>(Enumerable.Range(1, 12));
        public ObservableCollection<int> Years { get; } = new ObservableCollection<int>(Enumerable.Range(2020, DateTime.Now.Year - 2020 + 1));

        public int SelectedMonth
        {
            get { return _selectedMonth; }
            set
            {
                _selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
                LoadData();
            }
        }

        public int SelectedYear
        {
            get { return _selectedYear; }
            set
            {
                _selectedYear = value;
                OnPropertyChanged(nameof(SelectedYear));
                LoadData();
            }
        }

        // Khai báo biến YFormatter ở đây
        public Func<double, string> YFormatter { get; set; }

        // Khai báo biến AxisMax ở đây
        public double AxisMax { get; set; }
        public DashBoardStatisticsViewModel()
        {
            LoadData();
        }


        private void LoadData()
        {
            var dataProvider = DataProvider.Ins;
            
            Bills = new ObservableCollection<Bill>(dataProvider.GetBills());

            // Kiểm tra giá trị hợp lệ cho tháng và năm
            if (SelectedMonth < 1 || SelectedMonth > 12 || SelectedYear < 1)
            {
                // Xử lý lỗi hoặc thông báo người dùng về giá trị không hợp lệ
                return;
            }

            var firstDayOfMonth = new DateTime(SelectedYear, SelectedMonth, 1);

            // Kiểm tra xem ngày tạo có hợp lệ hay không trước khi sử dụng
            if (firstDayOfMonth.Month != SelectedMonth || firstDayOfMonth.Year != SelectedYear)
            {
                // Xử lý lỗi hoặc thông báo người dùng về giá trị không hợp lệ
                return;
            }

            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            var allDaysInMonth = Enumerable.Range(1, 30).ToList();

            var filteredBills = Bills
                .Where(b => b.orderat.HasValue && b.orderat.Value >= firstDayOfMonth && b.orderat.Value <= lastDayOfMonth)
                .ToList();

            var dailyRevenue = allDaysInMonth
                .GroupJoin(filteredBills,
                    day => day,
                    bill => bill.orderat?.Day,
                    (day, bills) => new
                    {
                        Day = day,
                        TotalRevenue = bills.Sum(b => b.Total ?? 0)
                    })
                .OrderBy(d => d.Day)
                .ToList();

            SeriesCollection = new SeriesCollection
    {
        new ColumnSeries
        {
            Title = "Tổng doanh thu ",
            Values = new ChartValues<double>(dailyRevenue.Select(d => d.TotalRevenue))
        }
    };

            Labels = new ObservableCollection<string>(dailyRevenue.Select(d => d.Day.ToString()));

            // Tính toán giá trị cho trục Y chia thành 10 phần
            var maxYValue = dailyRevenue.Max(d => d.TotalRevenue);
            var yAxisStep = maxYValue / 10.0;

            YFormatter = value => (value * yAxisStep).ToString("N0");
            AxisMax = maxYValue;
        }
    }
}
