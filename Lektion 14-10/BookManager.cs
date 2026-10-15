using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_14_10
{
    internal class BookManager
    {
        private List<Book> books;
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void ShowUsers()
        {
            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Author} {book.Title} {book.ISBN} {book.Available}");
            }

        }
    }
}