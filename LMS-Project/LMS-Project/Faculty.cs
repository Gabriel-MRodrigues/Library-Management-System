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
    }
}
