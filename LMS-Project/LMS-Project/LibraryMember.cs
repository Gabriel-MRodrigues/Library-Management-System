﻿using System;
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

        public virtual void BorrowBook(string bookTitle)
        {
            if (string.IsNullOrEmpty(bookTitle))
            {
                Console.WriteLine("Book title cannot be empty");
                return;
            }
            if (!BooksBorrowed.Contains(bookTitle))
            {
                BooksBorrowed.Add(bookTitle);
                Console.WriteLine($"Adding {bookTitle} to {Name} collection.");
            }
            else
            {
                Console.WriteLine($"{Name} already has book: {bookTitle}");
            }
        }

        public void ReturnBook(string bookTitle)
        {
            if (BooksBorrowed.Contains(bookTitle))
            {
                BooksBorrowed.Remove(bookTitle);
                Console.WriteLine($"{Name} returned the book: {bookTitle}");
            }
            else
            {
                Console.WriteLine($"{Name} has not borrowed the book: {bookTitle}.");
            }
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Member ID: {MemberID}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine("Books Borrowed: ");
            if (BooksBorrowed.Count != 0)
            {
                foreach (string book in BooksBorrowed)
                {
                    Console.WriteLine($"- {book}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine(); //Breaking line
        }
    }
}
