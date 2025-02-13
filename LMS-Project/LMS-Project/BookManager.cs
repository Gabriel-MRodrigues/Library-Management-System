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
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Books file not found. Creating a new one...");
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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving books: {ex.Message}");
            }
        }
    }
}
