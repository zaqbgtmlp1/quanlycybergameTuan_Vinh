using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuanLyCyberGame.ViewModel
{
    public class UserAccount
    {
        private static UserAccount _instance;
        public static UserAccount Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserAccount();
                return _instance;
            }
        }

        public User LoggedInUser { get; set; }

        private UserAccount()
        {
            // Khởi tạo các giá trị mặc định hoặc thực hiện các công việc khởi tạo khác tại đây
        }
    }
}

