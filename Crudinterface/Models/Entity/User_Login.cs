using PetaPoco;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Crudinterface.Models.Entity
{
   
    public class User_Login
    {
        public int id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string passWord { get; set; }
    }
}