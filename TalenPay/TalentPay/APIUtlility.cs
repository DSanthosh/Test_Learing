using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalenPay
{
    class APIUtlility
    {
        public string EmailAPIUtlility(string urls)
        {
            //api  call to email  
            var client = new RestClient(urls);
            var request = new RestRequest(Method.GET);
            var content = client.Execute(request).Content;
            return content;
        }
    }
}
