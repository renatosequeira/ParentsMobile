using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParentsMobile.Models
{
    public class Childrens
    {
        //CHILDREN IDENTIFICATION GENERAL
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string CC { get; set; } //cartão do cidadão

        //CHILDREN HEALTH INFORMATION
        public string FamilyDoctor { get; set; }
        public string BloodType { get; set; }

        //RESPONSIBLE IDENTIFICATION
        public string ParentOneID { get; set; }
        public string ParentTwoID { get; set; }
    }
}
