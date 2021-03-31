using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBussines.ViewModels
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public DateTime PublishDate { get; set; }
        public string PublishingHouse { get; set; }
        public string AuthorName { get; set; }

        public int CategoryId { get; set; }
        public Category Category;
    }
}
