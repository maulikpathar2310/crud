using Crudinterface.Models.Entity;
using Crudinterface.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Crudinterface.Infrastructure.DataProvider
{
    interface IServiceProvider
    {
        bool ValidUser(User_Login login);
        User_Reg_Viewmodel GetServiceProvider();
        string SaveServiceProvider(User_Reg_Viewmodel model);
        User_Reg GetUpdateId(int id);
        string EditServiceProvider(User_Reg model);
        string DeletServiceProvider(int id);
    }
    
        
       
}
