using Crudinterface.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crudinterface.Models.Viewmodel
{
    public class User_Reg_Viewmodel
    {
        public User_Reg_Viewmodel()
        {
            User_Regobj = new User_Reg();
            User_Reglist = new List<User_Reg>(); 
        }

        public User_Reg User_Regobj { get; set; }
        public List<User_Reg> User_Reglist { get; set; }
    }
}