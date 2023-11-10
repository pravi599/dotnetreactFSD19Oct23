using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Car car1 = new Car();
            car1.Make = "Oldsmobile";
            car1.Model = "Cutlas Supreme";
            car1.VIN = "A1";

            Car car2 = new Car();
            car2.Make = "Geo";
            car2.Model = "Prism";
            car2.VIN = "B2";

            Book b1 = new Book();
            b1.Author = "Robert Tabor";
            b1.Title = "Microsoft .NET XML Web Services";
            b1.ISBN = "0-000-0000-0";
            */
            /*
            //ArrayLists are dynamically sized
            //cool features like sorting ,remove items
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(car1);
            myArrayList.Add(car2);
            myArrayList.Add(b1);
            myArrayList.Remove(b1);
            foreach(Car car in myArrayList) 
            { 
                Console.WriteLine(car.Make);
            
            }
            
            //List<T>
            List<Car> myList = new List<Car>();
            myList.Add(car1);
            myList.Add(car2);
            foreach (Car car in myList) {
                Console.WriteLine(car.Model);
            }
            */
            /*
            //Dictionary<TKey,TValue>

            Dictionary<string, Car> myDictionary = new Dictionary<string, Car>();
            myDictionary.Add(car1.VIN, car1);
            myDictionary.Add(car2.VIN, car2);

            Console.WriteLine(myDictionary["B2"].Make);
            */
            //No need for a Constructor
            //string[] Name = { "Bob", "Steve", "Baian", "Chunk" };
            //Car car1 = new Car() { Make = "B&W", Model = "750li", VIN = "C#" };
            //Car car2 = new Car() { Make = "Toyoto", Model = "4Runner", VIN = "D4"};
            //collection initializer
            List<Car> myList = new List<Car>()
            {
                new Car {Make = "Oldsmobile",Model = "Cutlas Supreme",VIN = "A1" },
                new Car {Make = "Geo",Model = "Prism",VIN = "B2" }
            };

            Console.ReadLine();
        }
    }
    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }

}
