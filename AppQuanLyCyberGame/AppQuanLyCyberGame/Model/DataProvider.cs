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



        public Item GetItemById(int itemId)
        {
            try
            {
                var item = DB.Items.FirstOrDefault(i => i.Id == itemId);
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving item: {ex.Message}");
                return null;
            }
        }

        public bool UpdateItembyId(int itemId, string newDisplayName, double? newCost, int? newNumber)
        {
            try
            {
                var itemToUpdate = GetItemById(itemId);

                if (itemToUpdate != null)
                {
                    // Cập nhật thông tin sản phẩm
                    itemToUpdate.DisplayName = newDisplayName;
                    itemToUpdate.Cost = newCost;
                    itemToUpdate.Number = newNumber;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    DB.SaveChanges();

                    Debug.WriteLine($"Item with ID {itemId} updated successfully.");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"Item with ID {itemId} not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating item: {ex.Message}");
                return false;
            }
        }


        public bool HideItembyId(int itemId)
        {
            try
            {
                var itemToUpdate = GetItemById(itemId);

                if (itemToUpdate != null)
                {   
                    if (itemToUpdate.Itemstatus == true)
                    // Cập nhật thông tin sản phẩm
                        itemToUpdate.Itemstatus = false;
                    
                    else
                        itemToUpdate.Itemstatus = true;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    DB.SaveChanges();

                    Debug.WriteLine($"Item with ID {itemId} updated successfully.");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"Item with ID {itemId} not found.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error updating item: {ex.Message}");
                return false;
            }
        }


        public bool AddItem(string displayName, double? cost, int? number)
        {
            try
            {
                // Kiểm tra thông tin có hợp lệ hay không
                if (string.IsNullOrEmpty(displayName) || cost == null || number == null)
                {
                    Debug.WriteLine("Invalid information for adding item.");
                    return false;
                }

                // Tạo đối tượng Item mới
                var newItem = new Item
                {
                    DisplayName = displayName,
                    Cost = cost,
                    Number = number,
                    Itemstatus = false // Mặc định cho trạng thái là true khi thêm mới
                };

                // Thêm vào cơ sở dữ liệu và lưu thay đổi
                DB.Items.Add(newItem);
                DB.SaveChanges();

                Debug.WriteLine($"Item '{displayName}' added successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error adding item: {ex.Message}");
                return false;
            }
        }



        public bool OrderItem(double total, int iduser, string status)
        {
         
                // Tạo đối tượng Item mới
                var newOrder = new Bill
                {
                    Total = total,
                    IdUser = iduser,
                    BillStatus = status,
                    orderat = DateTime.Now
                };

                // Thêm vào cơ sở dữ liệu và lưu thay đổi
                DB.Bills.Add(newOrder);
                DB.SaveChanges();
                

            return true;
            
        }

        

    }
}
