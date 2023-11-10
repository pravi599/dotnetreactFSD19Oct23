using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MyCodeLibrary
{
    public class Scrap
    {
        public string ScrapWebpage(string url)
        {

            return GetWebpage(url);


        }
        public string ScrapWebpage(string url,string filepath)
        {
            string reply = GetWebpage(url);


            File.WriteAllText(filepath, reply);
            return reply;

        }
        private string GetWebpage(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);


        }
    }
}