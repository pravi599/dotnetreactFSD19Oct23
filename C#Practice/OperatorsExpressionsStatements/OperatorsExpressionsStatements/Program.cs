using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsExpressionsStatements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable declaration
            int x, y, a, b;
            //Assignment Operation

            x = 3;
            y = 2;
            a = 1;
            b = 2;
            //Addition,Substraction,Multiplication,division
            x = 1 + 2;
            x = 5 - 1;
            x = 6 * 2;
            y = 3 / 2;
            //Order of operations using paranthesis
            x = (x + y) * (a - b);

            // Equality
            if(x==y)
            {

            }
            //GreaterThan
            if(x>y)
            {

            }
            //Less than
            if(x<y)
            {

            }
            //Conditional AND Operator
            if ((x > y) && (a > b))
            {

            }
            //Conditional OR Operator
            if ((x > y) || (a > b))
            {

            }
            string message = (x == 1) ? "Car" : "Boat";
            Console.WriteLine("Hi");


        }
    }
}
