using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Project
{
    internal class Faculty : LibraryMember
    {
        public string Department { get; set; }
        public Faculty() { }
        public Faculty(int MemberID, string Name, string Department)
            : base(MemberID, Name)
        {
            this.Department = Department;
        }
        public override void BorrowBook(string bookTitle)
        {
            if (BooksBorrowed.Count <= 5)
            {
                base.BorrowBook(bookTitle);
            }
            else
            {
                Console.WriteLine($"{Name} as a Faculty Member can only borrow up to 5 books.");
            }
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Department: {Department}");
            base.DisplayDetails();
        }
        public void AssignBook(Student student, string bookTitle)
        {
            if (student == null)
            {
                Console.WriteLine("Invalid Student");
                return;
            }
            if (!string.IsNullOrEmpty(bookTitle))
            {
                if (!student.BooksBorrowed.Contains(bookTitle))
                {
                    if (student.BooksBorrowed.Count <= 3)
                    {
                        student.BorrowBook(bookTitle);
                        Console.WriteLine($"{Name} (Faculty) from deparment {Department} assigned the book '{bookTitle}' to {student.Name} (Student)");
                    }
                    else
                    {
                        Console.WriteLine($"{student.Name} cannot borrow more books. Limit reached..");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine($"{student.Name} already has the book: {bookTitle}");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Book title cannot be empty");
                return;
            }
        }
    }
}
