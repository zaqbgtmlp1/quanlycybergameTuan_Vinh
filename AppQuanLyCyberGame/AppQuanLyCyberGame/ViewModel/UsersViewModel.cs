﻿using AppQuanLyCyberGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AppQuanLyCyberGame.ViewModel
{
    public class UsersViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
     

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        

        public UsersViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            var dataProvider = DataProvider.Ins;
            var UsersFromDatabase = dataProvider.GetUsers();

            

            Users = new ObservableCollection<User>(UsersFromDatabase);
        }



        private RelayCommand<object> _addUserCommand;

        public ICommand AddUserCommand
        {
            get
            {
                if (_addUserCommand == null)
                {
                    _addUserCommand = new RelayCommand<object>(
                        p => true,
                        p => NavigateToAddUserView()
                    );
                }
                return _addUserCommand;
            }
        }

        private void NavigateToAddUserView()
        {
            MessageBox.Show("OK");

            var addUserView = new AddUserView();

            addUserView.ShowDialog();

        }

    }
}