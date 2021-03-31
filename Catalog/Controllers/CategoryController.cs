using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Controllers
{
     [ApiController]
    public class CategoryController : ControllerBase
    {
        CatalogBussines.Domains.Category CategoryRepository;
        CatalogBussines.Domains.Book BookRepository;

        public CategoryController(IConfiguration configuration)
        {
            this.CategoryRepository = new CatalogBussines.Domains.Category(configuration);
            this.BookRepository = new CatalogBussines.Domains.Book(configuration);
        }

        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult Get()
        {
            var categories = this.CategoryRepository.Get();
            return Ok(categories);
        }

        [Route("api/[controller]/{categoryid}")]
        [HttpGet]
        public IActionResult GetById(int categoryid)
        {
            var category = this.CategoryRepository.GetById(categoryid);
            return Ok(category);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Post([FromBody] CatalogBussines.ViewModels.Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            CategoryRepository.Create(category);
            return Ok(category);
        }

        [Route("api/[controller]")]
        [HttpPut]
        public IActionResult Put(CatalogBussines.ViewModels.Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            CategoryRepository.Edit(category);
            return NoContent();
        }

        [Route("api/[controller]/{categoryid}")]
        [HttpDelete]
        public IActionResult Delete(int categoryId)
        {
            CategoryRepository.Delete(categoryId);
            return NoContent();
        }

        [Route("{categoryId}/books")]
        [HttpGet]
        public IActionResult GetBooksByCategory(int categoryId)
        {
            var books = this.BookRepository.Get(categoryId);
            return Ok(books);
        }

        [Route("{categoryId}/books/{bookId}")]
        [HttpGet]
        public IActionResult GetBookByIdInCategory(int categoryId, int bookId)
        {
            var book = this.BookRepository.GetById(bookId, categoryId);
            if (book.CategoryId != categoryId)
            {
                return Ok();
            }
            return Ok(book);
        }

        [Route("{categoryId}/books/{bookId}")]
        [HttpDelete]
        public IActionResult DeleteBook(int bookId)
        {
            BookRepository.Delete(bookId);
            return NoContent();
        }
    }
}