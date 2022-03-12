using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace Crudinterface.Models.Entity
{
    [TableName("UserReg")]
    public class User_Reg
    {
        
        public int id { get; set; }

        [Required(ErrorMessage = "USer name required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Email name required")]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string Cpassword { get; set; }

            [Required]
            public string phone { get; set; }

        
        [Required]
        public string dropdown { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public string date { get; set; }

        [Required]
        public string image { get; set; }      
        
        [Required]
        public string description { get; set; }

    }
}