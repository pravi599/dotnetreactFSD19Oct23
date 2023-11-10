using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeLibrary;


namespace MyClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scrap myScrap = new Scrap();
            string value = myScrap.ScrapWebpage("http://msdn.microsoft.com");
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
