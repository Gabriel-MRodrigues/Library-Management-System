﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LMS_Project
{
    internal class Book
    {
        public string Title {  get; set; }
        public string Description { get; set; } = "No description found";
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool isAvailable { get; set; }

        public Book() { }
        public Book(string title, string author, string isbn, string description, bool isAvailable = true) 
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Description = description;
            this.isAvailable = isAvailable;
        }

        public override string ToString()
        {
            return $"{Title}|{Author}|{ISBN}|{Description}|{isAvailable}";
        }

        public static Book FromString(string bookData)
        {
            string[] parts = bookData.Split('|');

            if (parts.Length != 5)
                throw new FormatException("Invalid book format in file.");

            return new Book(
                   parts[0], // Title
                   parts[1], // Author
                   parts[2], // ISBN
                   parts[3], // Description
                   bool.Parse(parts[4]) // IsAvailable
                );
        }

    }
}
