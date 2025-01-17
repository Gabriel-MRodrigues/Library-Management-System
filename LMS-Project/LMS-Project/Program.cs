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
            List<LibraryMember> libraryMembers = new List<LibraryMember>();

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
                        AddNewMember(libraryMembers);
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
        static void AddNewMember(List<LibraryMember> libraryMembers)
        {
            Console.WriteLine("1. Student Member");
            Console.WriteLine("2. Faculty Member");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddStudent(libraryMembers);
                    break;
                case "2":
                    AddFacultyMember(libraryMembers);
                    break;
                default:
                    Console.WriteLine("Invalid enter. Press enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
        static void AddStudent(List<LibraryMember> libraryMembers)
        {
            string name, gradeLevel;
            int id;

            Console.WriteLine("Enter Student Name: ");
            name = Console.ReadLine();

            id = ValidateMemberID(libraryMembers);

            Console.WriteLine("Enter Student Grade Level: ");
            gradeLevel = Console.ReadLine();

            Student student = new Student(id, name, gradeLevel);
            libraryMembers.Add(student);

            Console.WriteLine("Student added. Press enter to return.");
            Console.ReadLine();
        }

        static int ValidateMemberID(List<LibraryMember> libraryMembers)
        {
            int MemberID;
            bool isValid = false;
            while (!isValid)
            {
                Console.WriteLine("Enter Member ID:");
                if (int.TryParse(Console.ReadLine(), out MemberID))
                {
                    if (!libraryMembers.Any(member => member.MemberID == MemberID))
                    {
                        isValid = true;
                        return MemberID;
                    }
                    else
                    {
                        Console.WriteLine("Member ID already exists. Try again...");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Member ID. Member ID must be only numbers. Try again...");
                }
            }
            return -1;
        }

        static void AddFacultyMember(List<LibraryMember> libraryMembers)
        {
            string name, department;
            int id;

            Console.WriteLine("Enter Faculty Member Name: ");
            name = Console.ReadLine();

            id = ValidateMemberID(libraryMembers);

            Console.WriteLine("Enter Faculty Member Department: ");
            department = Console.ReadLine();

            Faculty facultyMember = new Faculty(id, name, department);
            libraryMembers.Add(facultyMember);

            Console.WriteLine("Faculty Member added. Press enter to return.");
            Console.ReadLine();
        }
    }
}
