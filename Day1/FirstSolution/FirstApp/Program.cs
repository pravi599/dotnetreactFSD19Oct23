namespace FirstApp
{
    internal class Program
    {

        static void Main(string[] args)
        {
            double sum = 0;

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter number {0}: ", i + 1);
                double input = Convert.ToDouble(Console.ReadLine());
                sum += input;
            }

            double average = sum / 10;
            Console.WriteLine("The average of the numbers is {0}", average);
        }
    }
}
            /*Console.WriteLine("Enter a number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int square = num * num;

            Console.WriteLine("The square of {0} is {1}", num, square);
        }
    }
}*/
/*Console.WriteLine("Enter a number: ");
int num = Convert.ToInt32(Console.ReadLine());
bool isPrime = true;

for (int i = 2; i <= num; i++)
{
    if (num % i == 0)
    {
        isPrime = false;
        break;
    }
}

if (isPrime && num > 1)
{
    Console.WriteLine("{0} is prime", num);
}
else
{
    Console.WriteLine("{0} is not prime", num);
}
}
}
}
*/

/*Console.WriteLine("Enter a number: ");
int num = Convert.ToInt32(Console.ReadLine());

if (num % 2 == 0)
{
    Console.WriteLine("{0} is even", num);
}
else
{
    Console.WriteLine("{0} is odd", num);
}
}
}
}*/


/*Console.WriteLine("Enter first number: ");
int num1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter second number: ");
int num2 = Convert.ToInt32(Console.ReadLine());

if (num1 > num2)
{
    Console.WriteLine("{0} is bigger than {1}", num1, num2);
}
else if (num2 > num1)
{
    Console.WriteLine("{0} is bigger than {1}", num2, num1);
}
else
{
    Console.WriteLine("{0} and {1} are equal", num1, num2);
}
}
}
}
Console.WriteLine("Enter first number: ");
int num1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter second number: ");
int num2 = Convert.ToInt32(Console.ReadLine());

int sum = num1 + num2;
Console.WriteLine("The sum of {0} and {1} is {2}", num1, num2, sum);
}
}
}*/

//static void Main(string[] args)
/*{
    int num1;
    Console.WriteLine("Please enter a number");
    //num1 = Convert.ToInt32(Console.ReadLine());
    num1 = GetARandomNumber();
    if (num1 > 100)
        Console.WriteLine("Too big. The number is "+num1);
    else
        Console.WriteLine($"The number {num1} is Okay");
}
static int GetARandomNumber()
{
    int num1 = new Random().Next(1, 200);
    return num1;
}
static void AddTwoNumbers()
{
    int number1, number2;
    number1 = GetARandomNumber();
    number2 = GetARandomNumber();
    int sum = number1 + number2;
    Console.WriteLine($"The sum of {number1} and {number2} is {sum}");
}
}
}*/



