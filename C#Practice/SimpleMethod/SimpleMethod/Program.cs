using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReverseString("Bob");
            Console.ReadLine();
        }

        private static void ReverseString(string message)
        {
            char[] messageArray = message.ToCharArray();
            Array.Reverse(messageArray);
            foreach (char item in messageArray)
            {
                Console.WriteLine(item);
            }
        }
            
    }
}
