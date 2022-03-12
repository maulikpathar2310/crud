using Crudinterface.Models;
using Crudinterface.Models.Entity;
using Crudinterface.Models.Viewmodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Crudinterface.Infrastructure.DataProvider 
{
    public class ServiceProvider : BaseDataProvider, IServiceProvider
    {
        //For Login 
        public bool ValidUser(User_Login login)
        {
            bool Validate = false;
            var serchList = new List<SearchValueData>(); //SearchValueData e su chhe ??
            var serchvaluedata = new SearchValueData { Name = "username", Value = login.username.ToString() }; 
            var serchvaluedata1 = new SearchValueData { Name = "passWord", Value = login.passWord.ToString() };
            serchList.Add(serchvaluedata);
            serchList.Add(serchvaluedata1);

            User_Login usr_login = GetEntity<User_Login>("sp_login", serchList);
            FormsAuthentication.SetAuthCookie(login.username, true);
            if (usr_login != null)
               
               
            Validate = true;
            return Validate;
        }

        //User Reg List
        public User_Reg_Viewmodel GetServiceProvider()
        {
            User_Reg_Viewmodel list = new User_Reg_Viewmodel();
            DataSet ds = GetDataSet("sp_select", null);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                User_Reg_Viewmodel faqlist = new User_Reg_Viewmodel();
                faqlist.User_Regobj.id = int.Parse(Convert.ToString(ds.Tables[0].Rows[i]["id"]));
                faqlist.User_Regobj.name = Convert.ToString(ds.Tables[0].Rows[i]["name"]);
                faqlist.User_Regobj.email = Convert.ToString(ds.Tables[0].Rows[i]["email"]);
                faqlist.User_Regobj.password = Convert.ToString(ds.Tables[0].Rows[i]["password"]);
                faqlist.User_Regobj.phone = Convert.ToString(ds.Tables[0].Rows[i]["phone"]);
                faqlist.User_Regobj.dropdown = Convert.ToString(ds.Tables[0].Rows[i]["dropdown"]);
                faqlist.User_Regobj.gender = Convert.ToString(ds.Tables[0].Rows[i]["gender"]);
                faqlist.User_Regobj.date = Convert.ToString(ds.Tables[0].Rows[i]["date"]);
                faqlist.User_Regobj.image = Convert.ToString(ds.Tables[0].Rows[i]["image"]);
                faqlist.User_Regobj.description = Convert.ToString(ds.Tables[0].Rows[i]["description"]);
                list.User_Reglist.Add(faqlist.User_Regobj);
            }

            return list;
        }

        // User Register Create
        public string SaveServiceProvider(User_Reg_Viewmodel vModel)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ","");
            if (file != null && file.ContentLength > 0)
            {
                
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/image/"+ filename));
                vModel.User_Regobj.image = filename;
                file.SaveAs(imgpath);
            }
            try
            {
                var searchList = new List<SearchValueData>
             {
                 new SearchValueData { Name = "name", Value = vModel.User_Regobj.name },
                 new SearchValueData { Name = "email", Value = vModel.User_Regobj.email },
                 new SearchValueData { Name = "password", Value = vModel.User_Regobj.password },
                 new SearchValueData { Name = "phone", Value =  vModel.User_Regobj.phone},
                 new SearchValueData { Name = "dropdown", Value =  vModel.User_Regobj.dropdown},
                 new SearchValueData { Name = "gender", Value =  vModel.User_Regobj.gender},
                 new SearchValueData { Name = "date", Value =  vModel.User_Regobj.date},
                 new SearchValueData { Name = "image", Value =  vModel.User_Regobj.image},
                 new SearchValueData { Name = "description", Value =  vModel.User_Regobj.description}
             };               
               

                DataSet userList = GetDataSet("sp_insert", searchList);
                return "Successful Added";
            }
            catch (Exception)
            {
                return "not Successful";                  
            }           

       
        }
        
       

        // User Register Edit id

        public User_Reg GetUpdateId(int id)
        {

            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "id", Value = Convert.ToString(id) }
                    
                };
            User_Reg getinfo = GetEntity<User_Reg>("sp_update_id", searchList);
            return getinfo;
        }

        // User Register Edit id

        public string EditServiceProvider(User_Reg vModel)
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            string filename = Path.GetFileName(file.FileName).Replace(" ", "");
            if (file != null && file.ContentLength > 0)
            {
                string imgpath = Path.Combine(HttpContext.Current.Server.MapPath("~/image/" + filename));
                vModel.image = filename;
                file.SaveAs(imgpath);
            }
            var searchList = new List<SearchValueData>
             {
                 new SearchValueData { Name = "id", Value = vModel.id.ToString()},
                 new SearchValueData { Name = "name", Value = vModel.name },
                 new SearchValueData { Name = "email", Value = vModel.email },
                 new SearchValueData { Name = "password", Value = vModel.password },
                 new SearchValueData { Name = "phone", Value =  vModel.phone},
                 new SearchValueData { Name = "dropdown", Value =  vModel.dropdown},
                 new SearchValueData { Name = "gender", Value =  vModel.gender},
                 new SearchValueData { Name = "date", Value =  vModel.date},
                 new SearchValueData { Name = "image", Value =  vModel.image},
                 new SearchValueData { Name = "description", Value =  vModel.description}
             };

            DataSet userList = GetDataSet("sp_update", searchList);

            return "Successful Added";
        }


        // User reg delete

        public string DeletServiceProvider(int id)
        {
            var searchList = new List<SearchValueData>
                {
                    new SearchValueData { Name = "id", Value = id.ToString() }

                };

            DataSet userList = GetDataSet("sp_delete", searchList);
            return "Service Provider Delete SuccesFul";
        }

    }
}