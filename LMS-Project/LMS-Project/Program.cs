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
                        borrowOrReturnBook(libraryMembers);
                        break;
                    case "3":
                        viewMember(libraryMembers);
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

        static void borrowOrReturnBook(List<LibraryMember> libraryMembers)
        {
            Console.Clear();
            Console.WriteLine("Insert Member ID:");
            
            if(int.TryParse(Console.ReadLine(), out int memberID))
            {
                LibraryMember member = identifyMember(memberID, libraryMembers);
                if(member != null)
                {
                    Console.WriteLine("1.Borrow Book.");
                    Console.WriteLine("2.Return Book.");
                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            borrowBook(member);
                            break;
                        case "2":
                            break;
                        default:
                            Console.WriteLine("Invalid option. Press Enter to return...");
                            Console.ReadLine();
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Member ID. Member ID must be only numbers...");
                Console.ReadLine();
            }
        }

        static LibraryMember identifyMember(int memberID, List<LibraryMember> libraryMembers) 
        {
            Console.Clear();
            LibraryMember member = libraryMembers.Find(m => m.MemberID == memberID);
            if (member != null)
            {
                Console.WriteLine($"Member with ID of {memberID} succesfully found.");
                return member;
            }
            else
            {
                Console.WriteLine($"ID: {memberID} is not a member.");
                Console.ReadLine();
            }
            return null;
        }

        static void borrowBook(LibraryMember libraryMember)
        {
            Console.Clear();
            Console.WriteLine("Insert book name: ");
            string bookTitle = Console.ReadLine();

            libraryMember.BorrowBook(bookTitle);
            Console.ReadLine();
        }

        static void viewMember(List<LibraryMember> libraryMembers) 
        {
            Console.Clear();

            if (libraryMembers.Count != 0) 
            {
                Console.WriteLine("1. Faculty Members");
                Console.WriteLine("2. Student Members");
                Console.WriteLine("3. View all Members");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        showTypeMember<Faculty>(libraryMembers);
                        break;
                    case "2":
                        showTypeMember<Student>(libraryMembers);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Displaying all Library Members...");
                        Console.WriteLine();
                        foreach (LibraryMember member in libraryMembers)
                        {
                            member.DisplayDetails();
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid enter. Press enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Members not found...");
            }
            Console.WriteLine("Press enter to return to menu.");
            Console.ReadLine();
        }

        static void showTypeMember<option>(List<LibraryMember> libraryMembers) where option : LibraryMember
        {
            Console.Clear();
            Console.WriteLine($"Displaying {typeof(option).Name} Members...");
            Console.WriteLine();
            var members = libraryMembers.OfType<option>().ToList();
            if(members.Count != 0)
            {
                foreach (var member in members)
                {
                    member.DisplayDetails();
                }
            }
            else
            {
                Console.WriteLine($"{typeof(option).Name} Members not found...");
            }
            Console.ReadLine();
        }
    }
}
