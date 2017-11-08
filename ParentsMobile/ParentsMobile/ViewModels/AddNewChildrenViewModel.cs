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
    public class AddNewChildrenViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();

        //CHILDREN IDENTIFICATION GENERAL
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CC { get; set; } //cartão do cidadão

        //CHILDREN HEALTH INFORMATION
        public string FamilyDoctor { get; set; }
        public string BloodType { get; set; }

        //RESPONSIBLE IDENTIFICATION
        //fields manipulated in webservice
        //public string ParentOneID { get; set; }
        //public string ParentTwoID { get; set; }

        public ICommand AddChildren
        {
            get
            {
                return new Command(async() =>
                {
                    var children = new Childrens
                    {
                        FirstName = FirstName,
                        MiddleName = MiddleName,
                        LastName = LastName,
                        CC = CC,
                        FamilyDoctor = FamilyDoctor,
                        BloodType = BloodType
                    };

                    await _apiServices.PostChildrenAsync(children, Settings.AccessToken);
                });
            }
        }
    }
}
