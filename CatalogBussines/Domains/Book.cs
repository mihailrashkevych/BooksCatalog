using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBussines.Domains
{
    public class Book
    {
        CatalogData.Repository.Book repository;
        IMapper mapper;

        public Book(IConfiguration configuration)
        {
            this.repository = new CatalogData.Repository.Book(configuration);
            this.mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CatalogData.Entities.Book, ViewModels.Book>();
                cfg.CreateMap<ViewModels.Book, CatalogData.Entities.Book>();
                cfg.CreateMap<ViewModels.Category, CatalogData.Entities.Category>();
                cfg.CreateMap<CatalogData.Entities.Category, ViewModels.Category>();
            }).CreateMapper();
        }

        public IEnumerable<ViewModels.Book> Get(int categoryId)
        {
            var books = repository.Get(categoryId);
            return books.Select(book => mapper.Map<CatalogData.Entities.Book, ViewModels.Book>(book));
        }

        public ViewModels.Book GetById(int bookId, int categoryId)
        {
            var book = repository.GetById(bookId, categoryId);
            return mapper.Map<CatalogData.Entities.Book, ViewModels.Book>(book);
        }

        public void Create(ViewModels.Book book)
        {
            var repobook = mapper.Map<ViewModels.Book, CatalogData.Entities.Book>(book);
            repository.Create(repobook);
            repository.Save();
            book.BookId = repobook.BookId;
        }

        public void Edit(ViewModels.Book book)
        {
            var repoBook = mapper.Map<ViewModels.Book, CatalogData.Entities.Book>(book);
            repository.Edit(repoBook);
            repository.Save();
        }

        public void Delete(int id)
        {
            repository.Delete(id);
            repository.Save();
        }

    }
}
