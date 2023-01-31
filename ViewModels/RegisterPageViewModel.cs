using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProyectoFinalProgramacion.Models;
using ProyectoFinalProgramacion.Services;
using ProyectoFinalProgramacion.Views;

namespace ProyectoFinalProgramacion.ViewModels
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        public static List<User> UserListForSearch { get; private set; } = new List<User>();
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        private readonly IUserServices _userServices;
        public RegisterPageViewModel(IUserServices userServices)
        {
            _userServices = userServices;
        }



        [ICommand]
        public async void GetUsersList()
        {
            Users.Clear();
            var userList = await _userServices.GetUsersList();
            if (userList?.Count > 0)
            {
                userList = userList.OrderBy(f => f.UserName).ToList();
                foreach (var user in userList)
                {
                    Users.Add(user);
                }
                UserListForSearch.Clear();
                UserListForSearch.AddRange(userList);
            }
        }


        [ICommand]
        public async void AddUpdateUser()
        {
            await AppShell.Current.GoToAsync(nameof(RegisterPage));
        }


        [ICommand]
        public async void DisplayAction(User userModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>
                {
                    { "UserDetail", userModel }
                };
                await AppShell.Current.GoToAsync(nameof(RegisterPage), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _userServices.DeleteUser(userModel);
                if (delResponse > 0)
                {
                    GetUsersList();
                }
            }
        }
    }
}