using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Project
{
    internal class Student : LibraryMember
    {
        public string GradeLevel { get; set; } //freshman, sophomore ...

        public Student() { }
        public Student(int MemberID, string Name, string GradeLevel)
            : base(MemberID, Name)
        {
            this.GradeLevel = GradeLevel;
        }
        public void CheckGradeLevel()
        {
            Console.WriteLine($"{Name} is a {GradeLevel}");
        }
        public override void BorrowBook(string bookTitle)
        {
            if (BooksBorrowed.Count <= 3)
            {
                base.BorrowBook(bookTitle);
            }
            else
            {
                Console.WriteLine($"{Name} as a Student cannot borrow more than 3 books.");
            }
        }
    }
}
