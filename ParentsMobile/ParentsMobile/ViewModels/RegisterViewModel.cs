using ParentsMobile.Helpers;
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
    public class RegisterViewModel
    {
        ApiServices apiServices = new ApiServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () => {
                    var isSuccess = await apiServices.RegisterUserAsync(Email, Password, ConfirmPassword);

                    Settings.Username = Email;
                    Settings.Password = Password;

                    if (isSuccess)
                    {
                        Message = "User successfully added";
                    }
                    else
                    {
                        Message = "Error on registration";
                    }
                });
            }
        }
    }
}
