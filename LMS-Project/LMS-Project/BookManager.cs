using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Project
{
    internal class BookManager
    {
        public static string filePath = "books.txt";

        public static List<Book> LoadBooks()
        {
            List<Book> books = new List<Book>();
            try
            {
                StreamReader sr = new StreamReader(filePath);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    books.Add(Book.FromString(line));
                }
                sr.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Books file not found. Creating a new one...");
                StreamWriter sw = new StreamWriter(filePath);

                sw.WriteLine("C# Programming Guide|John Doe|978-1234567890||True");
                sw.WriteLine("Introduction to Algorithms|Thomas Cormen|978-0262033848||True");

                sw.Close();

                books = LoadBooks();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading books: {ex.Message}");
            }
            return books;
        }

        public static void SaveBooks(List<Book> books)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, false);

                foreach (Book book in books)
                {
                    sw.WriteLine(book.ToString());
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving books: {ex.Message}");
            }
        }

        public static void SearchBook(List<Book> books)
        {
            Console.Clear();
            Console.WriteLine("Enter book Title or Author or ISBN to search:");
            string query = Console.ReadLine().ToLower();

            var foundBooks = books.Where(b => query.Contains(b.Title.ToLower()) || query.Contains(b.Author.ToLower()) || query.Contains(b.ISBN.ToLower()));

            if(foundBooks.Count() == 0)
            {
                Console.WriteLine($"No matching books found for {query}.");
            }
            else
            {
                Console.WriteLine("Search Results: ");
                foreach (Book book in foundBooks)
                {
                    book.DisplayBookDetails();
                }
            }
        }

        public static void AddBook(List<Book> books)
        {
            Console.Clear();
            Console.WriteLine("Enter book title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Enter ISBN: ");
            string ISBN = Console.ReadLine();

            Console.WriteLine("Enter Description: ");
            Console.WriteLine("**if there is no description leave it blank**");
            string description = Console.ReadLine();

            books.Add(new Book(title, author, ISBN, description, true));

            SaveBooks(books);
            Console.WriteLine($"'{title}' has succesfully been added to the library!");
        }

        public static void RemoveBook(List<Book> books) 
        {
            Console.Clear();
            Console.WriteLine("Enter Book title or ISBN to remove: ");
            string bookToRemove = Console.ReadLine().ToLower();

            var foundBook = books.FirstOrDefault(b => b.Title.ToLower() ==  bookToRemove || b.ISBN.ToLower() == bookToRemove);

            if(foundBook == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            books.Remove(foundBook);
            SaveBooks(books);
            Console.WriteLine($"'{foundBook.Title}' has succesfully been removed from the Library");
        }
    }
}
