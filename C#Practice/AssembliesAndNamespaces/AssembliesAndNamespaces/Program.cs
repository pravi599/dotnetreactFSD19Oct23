using System;
using System.IO;
using System.Net;
using System.Xml.Linq;


namespace AssembliesAndNamespaces
{
    internal class Program
    {
        static void Main(string[] args)
        {

            WebClient client = new WebClient();
            string reply = client.DownloadString("http://msdn.microsoft.com");

            Console.WriteLine(reply);
            File.WriteAllText(@"C:\Users\valle\OneDrive\Desktop\stream training\C#Practice\AssembliesAndNamespaces\WriteText.txt", reply);
       
            Console.ReadLine();
        }
    }
}
