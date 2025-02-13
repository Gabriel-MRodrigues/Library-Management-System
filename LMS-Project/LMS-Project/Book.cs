using System;
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
        public string Description { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool isAvailable { get; set; }

        public Book() { }
        public Book(string title, string author, string isbn, bool isAvailable = true, string description) 
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            this.isAvailable = isAvailable;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Title},{Author},{ISBN},{isAvailable},{Description}";
        }

        public static Book FromString(string bookData)
        {
            string[] parts = bookData.Split(',');

            if (parts.Length != 5)
                throw new FormatException("Invalid book format in file.");

            return new Book(
                   parts[0], // Title
                   parts[1], // Author
                   parts[2], // ISBN
                   bool.Parse(parts[3]), // IsAvailable
                   parts[4] // Description
                );
        }

        public static List<Book> LoadBooks(string filePath)
        {
            List<Book> books = new List<Book>();

            StreamReader sr = new StreamReader(filePath);

            try
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    books.Add(Book.FromString(line));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Books file not found. Creating a new one...");
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Error loading books: {ex.Message}");
            }
            return books;
        }

        public static void SaveBooks(string filePath, List<Book> books)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath);

                foreach(Book book in books)
                {
                    sw.WriteLine(book.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving books: {ex.Message}");
            }
        }
    }
}
