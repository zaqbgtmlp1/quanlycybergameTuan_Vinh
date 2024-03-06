using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyCyberGame.Model
{
    public class DataProvider
    {
        private static DataProvider _ins;
        public static DataProvider Ins


        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }

        public QuanLyCyberGameEntities DB { get; set; }

        private DataProvider()
        {
            DB = new QuanLyCyberGameEntities();
        }


        public List<User> GetUsers()
        {
            try
            {
                var users = DB.Users.ToList();
                Debug.WriteLine($"Number of users retrieved: {users.Count}");
                return users;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving users: {ex.Message}");
                return new List<User>(); // hoặc trả về null tùy vào cách bạn xử lý
            }
        }

        public List<Item> GetItems()
        {
            try
            {
                var item = DB.Items.ToList();
                Debug.WriteLine($"Number of users retrieved: {item.Count}");
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving users: {ex.Message}");
                return new List<Item>(); // hoặc trả về null tùy vào cách bạn xử lý
            }
        }

        public List<ClientComputer> GetClientComputer()
        {
            try
            {
                var cc = DB.ClientComputers.ToList();
                Debug.WriteLine($"Number of users retrieved: {cc.Count}");
                return cc;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving users: {ex.Message}");
                return new List<ClientComputer>(); // hoặc trả về null tùy vào cách bạn xử lý
            }
        }

        public List<Bill> GetBills()
        {
            try
            {
                var bill = DB.Bills.ToList();
                Debug.WriteLine($"Number of users retrieved: {bill.Count}");
                return bill;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving users: {ex.Message}");
                return new List<Bill>(); // hoặc trả về null tùy vào cách bạn xử lý
            }
        }


    }
}
