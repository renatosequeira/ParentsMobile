using ParentsMobile.Helpers;
using ParentsMobile.Models;
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
    public class EditChildrenViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public Childrens Childrens { get; set; }

        public ICommand EditCommand
        {
            get
            {
                return new Command(async() => {
                    await _apiServices.EditChildrenAsync(Childrens, Settings.AccessToken);
                });
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async () => {
                    await _apiServices.DeleteChildrenAsync(Childrens.Id, Settings.AccessToken);
                });
            }
        }
    }
}
