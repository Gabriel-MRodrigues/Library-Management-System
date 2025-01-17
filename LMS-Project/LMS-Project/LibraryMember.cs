using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Project
{
    internal class LibraryMember
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public List<string> BooksBorrowed { get; set; }

        public LibraryMember() { }
        public LibraryMember(int MemberID, string Name)
        {
            this.MemberID = MemberID;
            this.Name = Name;
            BooksBorrowed = new List<string>();
        }
    }
}
