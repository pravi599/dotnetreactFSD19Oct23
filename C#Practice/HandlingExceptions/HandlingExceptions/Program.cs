using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string content = File.ReadAllText(@"D:\Documents\Example.txt");
                Console.WriteLine(content);


            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("There was a problem");
                Console.WriteLine("Make sure the name of the file is named correctly.");

            }
            catch(DirectoryNotFoundException e)
            {
                Console.WriteLine("Make sure the directory exists.");

            }

            catch(Exception e)
            {
                Console.WriteLine("There was a problem!");
                Console.WriteLine(e.Message);

            }
            finally
            {
                Console.WriteLine("Closing application now...............");
            }
            Console.ReadLine();


        }
    }
}
