using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Class1Add
    {
        public add()
        {
            Console.WriteLine("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int sum = num1 + num2;
            Console.WriteLine("The sum of {0} and {1} is {2}", num1, num2, sum);
        }
    }
    static void Main(string[] args)
    {
    class a = new Add();
    a.add();
}
    }
}
