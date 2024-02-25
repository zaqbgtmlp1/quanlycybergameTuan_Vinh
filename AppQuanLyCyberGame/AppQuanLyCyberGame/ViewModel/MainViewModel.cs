using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppQuanLyCyberGame.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        // mọi thứ xử lý sẽ nằm trong này

        public bool Isloaded = false;
        public MainViewModel()
        {
            if(!Isloaded)
            {
                Isloaded = true;
                LoginWindow loginWindow = new LoginWindow();
                LoadClientComputer();
                loginWindow.ShowDialog();
            }

            ClientComputer cl1 = new ClientComputer()
            {
                Id = 3,
                CCStatus = false,
                CCType = 1,
            };





        }

        void LoadClientComputer()
        {
            var Client1 = DataProvider.Ins.DB.Users;

        }
    }
}
