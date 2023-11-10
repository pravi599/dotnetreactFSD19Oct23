using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> myCars = new List<Car>()
            {
                new Car() {VIN="A1",Make="B&W",Model="550i",StickerPrice=55000,Year=2001},
                new Car() {VIN="B2",Make="Toyoto",Model="4Runner",StickerPrice=35000,Year=2002},
                new Car() {VIN="C3",Make="BMW",Model="745li",StickerPrice=75000,Year=2003},
                new Car() {VIN="D4",Make="Ford",Model="Escape",StickerPrice=25000,Year=2004},
                new Car() {VIN="E5",Make="BMW",Model="55i",StickerPrice=57000,Year=2005}

            };
            //LINQ query
            /*
            var bmws = from car in myCars
                       where car.Make == "BMW"
                       && car.Year == 2003
                       select car;
            */
            //LINQ method
            /*
            var bmws = myCars.Where(p => p.Make == "BMW" && p.Year==2003);
            foreach (var car in bmws)
            {
                Console.WriteLine("{0} {1}",car.Model,car.VIN);
            }
            Console.ReadLine();
            */
            /*
            var orderedCars = from car in myCars
                             orderby car.Year descending
                             select car;
            */
            //
            //var orderedCars = myCars.OrderByDescending(p => p.Year);
            // var firstBMW = myCars.First(p => p.Make == "BMW");
            //Console.WriteLine(firstBMW.VIN);
            //Console.WriteLine(myCars.TrueForAll(p => p.Year > 2002));
            /* foreach (var car in OrderByDescending)
             {
                 Console.WriteLine("{0} {1}", car.Model, car.VIN);
             }
            */
            //myCars.ForEach(p => p.StickerPrice = 3000);
            //myCars.ForEach(p => Console.WriteLine("{0} {1:C}", p.VIN, p.StickerPrice));

            //Console.WriteLine(myCars.Sum(p => p.StickerPrice));

            //Console.WriteLine(myCars.GetType());

            var newCars = from car in myCars
                       where car.Make == "BMW"
                       && car.Year == 2003
                       select new {car.Make,car.Model};
            Console.WriteLine(newCars.GetType());

            Console.ReadLine();

        }
        
    }
    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int StickerPrice { get; set; }
    }
}
