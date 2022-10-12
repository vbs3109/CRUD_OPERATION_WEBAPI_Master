using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CRUD_OPERATION_MVC.Helper
{
    public class CustomerAPI
    {
        
        public string Base_Url = "https://localhost:44398/";
        public HttpClient Initial()
            
            //Here HttpClient with the Initial method .HttpClient actually access the information from the web api,
                                   //so mandatory to use it here.
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Base_Url);
            return client;
        }
    }
}
