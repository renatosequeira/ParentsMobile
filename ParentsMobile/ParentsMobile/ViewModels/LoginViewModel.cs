﻿using ParentsMobile.Helpers;
using ParentsMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParentsMobile.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices apiServices = new ApiServices();

        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var accessToken = await apiServices.LoginUserAsync(UserName, Password);
                    Settings.AccessToken = accessToken;
                });
            }
        }

        public LoginViewModel()
        {
            UserName = Settings.Username;
            Password = Settings.Password;
        }
    }
}
