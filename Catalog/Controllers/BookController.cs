using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Catalog.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class BookController : ControllerBase
        {
        CatalogBussines.Domains.Book domain;

            public BookController(IConfiguration configuration)
            {
                this.domain = new CatalogBussines.Domains.Book(configuration);
            }

            [HttpGet]
            public IActionResult Get(int categoryId = 0)
            {
                var books = this.domain.Get(categoryId);
                return Ok(books);
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int bookId, int categoryId = 0)
            {
                var book = this.domain.GetById(bookId, categoryId);
                return Ok(book);
            }
  
            [HttpPost]
            public IActionResult Post([FromBody] CatalogBussines.ViewModels.Book book)
            {
                if (book == null)
                {
                    return BadRequest();
                }
                domain.Create(book);
                return Ok(book);
            }

            [HttpPut]
            public IActionResult Put(CatalogBussines.ViewModels.Book book)
            {
                if (book == null)
                {
                    return BadRequest();
                }
                domain.Edit(book);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                domain.Delete(id);
                return NoContent();
            }

        }
}
