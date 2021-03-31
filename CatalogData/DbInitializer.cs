using CatalogData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogData
{
    class DbInitializer
    {
        public static void Initialize(CatalogContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new Entities.Category[] {
                    new Category() { CategoryName = "Action and Adventure" },
                    new Category() { CategoryName = "Classics"},
                    new Category() { CategoryName = "Comic Book or Graphic Novel" },
                    new Category() { CategoryName = "Detective and Mystery" }
                });
            }

            if (!context.Categories.Any())
            {
                context.Books.AddRange(new Entities.Book[] {
                    new Book (){
                     BookName = "To Kill a Mockingbird",
                     PublishDate = new DateTime(2002, 01, 01),
                     PublishingHouse = "Hachette Livre",
                     AuthorName = "Author",
                     CategoryId = 1
                    },
                    new Book (){
                     BookName = "To Kill a Mockingbird",
                     PublishDate = new DateTime(2002, 01, 01),
                     PublishingHouse = "Hachette Livre",
                     AuthorName = "Author",
                     CategoryId = 2
                    },
                    new Book (){
                     BookName = "The Walking Dead: Compendium One",
                     PublishDate = new DateTime(2009, 05, 19),
                     PublishingHouse = "HarperCollins",
                     AuthorName = "Author",
                     CategoryId = 3
                    },
                    new Book(){
                     BookName = "And Then There Were None",
                     PublishDate = new DateTime(2011, 03, 29),
                     PublishingHouse = "Macmillan Publishers",
                     AuthorName = "Author",
                     CategoryId = 4
                    },
                    new Book (){
                     BookName = "First",
                     PublishDate = new DateTime(2002, 01, 01),
                     PublishingHouse = "Hachette Livre",
                     AuthorName = "Author",
                     CategoryId = 1
                    },
                    new Book (){
                     BookName = "Second",
                     PublishDate = new DateTime(2002, 01, 01),
                     PublishingHouse = "Hachette Livre",
                     AuthorName = "Author",
                     CategoryId = 2
                    },
                    new Book (){
                     BookName = "Third",
                     PublishDate = new DateTime(2009, 05, 19),
                     PublishingHouse = "HarperCollins",
                     AuthorName = "Author",
                     CategoryId = 3
                    },
                    new Book(){
                     BookName = "Fourth",
                     PublishDate = new DateTime(2011, 03, 29),
                     PublishingHouse = "Macmillan Publishers",
                     AuthorName = "Author",
                     CategoryId = 4
                    }
                });
            }
            context.SaveChanges();
        }
    }
}
