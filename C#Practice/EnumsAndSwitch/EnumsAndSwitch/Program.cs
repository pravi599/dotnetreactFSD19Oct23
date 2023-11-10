using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsAndSwitch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Todo> todos = new List<Todo>()
            {
                new Todo {Description = "Task 1", EstimatedHours = 6,Status = Status.Completed},
                new Todo {Description= "Task 2", EstimatedHours = 2,Status = Status.InProgress},
                new Todo {Description= "Task 2", EstimatedHours = 2,Status = Status.NotStarted },
                new Todo {Description = "Task 3", EstimatedHours = 8,Status = Status.Deleted},
                new Todo {Description = "Task 4", EstimatedHours = 12,Status = Status.InProgress},
                new Todo {Description = "Task 5", EstimatedHours = 6,Status = Status.NotStarted},
                new Todo {Description= "Task 6", EstimatedHours = 2,Status = Status.Completed},
                new Todo {Description = "Task 7", EstimatedHours = 14,Status = Status.Completed},
                new Todo {Description = "Task 8", EstimatedHours = 8,Status = Status.Completed},
                new Todo {Description = "Task 9", EstimatedHours = 8,Status = Status.OnHold},
                new Todo {Description = "Task 10", EstimatedHours = 4,Status = Status.Completed}

            };
            Console.ForegroundColor = ConsoleColor.Red;
            PrintAssessment(todos);
            Console.ReadLine();
        }
        private static void PrintAssessment(List<Todo> todos)
        {
            foreach (var todo in todos)
            {
                switch (todo.Status)
                {
                    case Status.Deleted:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case Status.NotStarted:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case Status.InProgress:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case Status.Completed:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case Status.OnHold:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;



                    default:
                        break;



                }
                Console.WriteLine(todo.Description);
            }
        }
    }


    class Todo
    {
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public Status Status { get; set; }
    }
    enum Status
    {
        NotStarted,
        InProgress,
        OnHold,
        Completed,
        Deleted
    }
}
