namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Please enter your name");
            name = Console.ReadLine();
            Console.WriteLine("Welcome " + name);
            Console.WriteLine($"Welcome {name}!!!");
            int num1;
            Console.WriteLine("Please enter a number");
            num1 = Convert.ToInt32(Console.ReadLine());
            if (num1 > 100)
                Console.WriteLine("Too big");
            else
                Console.WriteLine($"The number {num1} is Okay");

        }
    }
}