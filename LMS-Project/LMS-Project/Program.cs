using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void askQuestions()
            {
                Console.WriteLine("\n1. Add New Member.");
                Console.WriteLine("2. Borrow or Return Book.");
                Console.WriteLine("3. View Details.");
                Console.WriteLine("4. Exit\n");
                Console.WriteLine("Press a number to take action.\n");
            }

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                askQuestions();
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        isRunning = false;
                        Console.WriteLine("Exiting the program... press enter.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid enter. Try again...");
                        break;
                }
            }
        }
    }
}
