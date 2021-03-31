using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogData.Repository
{
    public class Book
    {
        CatalogContext context;

        public Book(IConfiguration configuration)
        {
            this.context = new CatalogContext(configuration);
        }

        public IEnumerable<Entities.Book> Get(int categoryId = 0)
        {

            if (categoryId != 0)
            {
                return context.Books.Where(book => book.CategoryId == categoryId).ToList();
            }
            
            return context.Books.ToList();
        }

        public Entities.Book GetById(int bookId, int categoryId = 0)
        {
            if (categoryId != 0)
            {
                Entities.Book categoryBook = context.Books.First(book => book.BookId == bookId && book.CategoryId == categoryId);
                return categoryBook;
            }

            Entities.Book book = context.Books.Find(bookId);
            if (book != null)
            {
                return book;
            }
            return null;
        }

        public void Create(Entities.Book book)
        {
            context.Add(book);
        }

        public void Edit(Entities.Book book)
        {
            context.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Entities.Book book = context.Books.FirstOrDefault(x => x.BookId == id);
            if (book != null)
            {
                context.Books.Remove(book);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
