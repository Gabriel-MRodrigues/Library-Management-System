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
    }
}
