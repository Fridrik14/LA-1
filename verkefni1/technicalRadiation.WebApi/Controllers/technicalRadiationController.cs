using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using techincalRadiation.Models.Dtos;
using technicalRadiation.Service;
using TechnicalRadiation.Models;

namespace technicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TRController : ControllerBase
    {
        private NewsItemService _newsItemService = new NewsItemService();
        private CategoryService _categoryService = new CategoryService();
        private AuthorService _authorService = new AuthorService();

        // [FromQuery] type name
        // http/{s}://localhost:5000/{1}/api
        [Route("")]
        [HttpGet]
        public IActionResult getAllNewsItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
        {
            var newsItems = _newsItemService.getAllNewsItems();
            var envelope = new Envelope<NewsItemDto>(pageSize, pageNumber, newsItems);
            return Ok(envelope);
        }

        // http/{s}://localhost:5000/{1}/api/1
        [Route("/{newsitemid:int}")]
        [HttpGet]
        public IActionResult getNewsItemById(int newsItemId)
        {
            return Ok(_newsItemService.getNewsItemById(newsItemId));
        }

        // http/{s}://localhost:5000/{1}/api/1
        [Route("{newsitemid:int}")]
        [HttpPut]
        public IActionResult updateNewsItemById(int newsItemId)
        {
            return Ok();
        }

        // http/{s}://localhost:5000/{1}/api/1
        // Required?
        [Route("{newsitemid:int}")]
        [HttpPatch]
        public IActionResult updateNewsItemPartiallyById(int newsItemId)
        {
            return Ok();
        }

        // http/{s}://localhost:5000/{1}/api/1
        [Route("{newsitemid:int}")]
        [HttpDelete]
        public IActionResult deleteNewsItemById(int newsItemId)
        {
            return Ok();
        }

        [Route("/categories")]
        [HttpGet]
        // Should work, but does this confine to the 3 layered system?
        public IActionResult getAllCategories([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
        {   
            var categories = _categoryService.getAllCategories();
            var envelope = new Envelope<CategoryDto>(pageSize, pageNumber, categories);
            return Ok(envelope);
        }

        [Route("/categories/{categoryId:int}")]
        [HttpGet]
        public IActionResult getCategoryById(int categoryId)
        {
            return Ok(_categoryService.getCategoryById(categoryId));
        }


        [Route("/categories/{categoryId:int}")]
        [HttpPut]
        public IActionResult updateCategoryById(int categoryId)
        {
            return Ok();
        }

        [Route("/categories/{categoryId:int}")]
        [HttpDelete]
        public IActionResult deleteCategoryById(int categoryId)
        {
            return Ok();
        }

        [Route("/authors")]
        [HttpGet]
        public IActionResult getAllAuthors([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25) 
        {
            var authors = _authorService.getAllAuthors();
            var envelope = new Envelope<AuthorDto>(pageSize, pageNumber, authors); 
            return Ok(authors);
        }

        [Route("/authors/{authorId:int}")]
        [HttpGet]
        public IActionResult getAuthorById(int authorId)
        {
            return Ok(_authorService.getAuthorById(authorId));
        }

        [Route("/authors/{authorId:int}/newsItems")]
        public IActionResult getNewsItemsOfAuthor(int authorId) 
        { 
            return Ok(); 
        }
    }
}
