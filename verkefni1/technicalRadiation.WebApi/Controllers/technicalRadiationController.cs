using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using techincalRadiation.Models.Dtos;
using techincalRadiation.Models.InputModels;
using technicalRadiation.Service;
using TechnicalRadiation.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace technicalRadiation.WebApi.Controllers
{

    public class MySampleActionFiler : IActionFilter
    {
        private string lykilord = "lykilord123";
        public override bool OnActionExecuting(ActionExecuting context)
        {
            var result = (actionContext.Request.Content as ObjectContent).Value.ToString();
            if(password == lykilord){
                return true;
            }
            else{
                return false;
            }
        }
    }
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
            // newsItems.ForEach(r => {
            //     r.Links.AddReference("self", $"/api/{r.Id}");
            //     r.Links.AddReference("edit", $"/api/{r.Id}");
            //     r.Links.AddReference("delete", $"/api/{r.Id}");
            //     int authorId = _newsItemService.getAuthorIdOfNewsItem(r.Id);
            //     if (authorId != -1)
            //     {
            //         r.Links.AddReference("Author", $"/api/authors/{authorId}");
            //     }                
            //     r.Links.AddListReference("Categories", _newsItemService.s(r.Id).Select(o => new { href = $"/api/category/{r.Id}/owners/{o.Id}" }));
            // });
            var envelope = new Envelope<NewsItemDto>(pageSize, pageNumber, newsItems);

            return Ok(envelope);
        }

        // http/{s}://localhost:5000/{1}/api/1
        [Route("/{newsitemid:int}", Name="getNewsItemById")]
        [HttpGet]
        public IActionResult getNewsItemById(int newsItemId)
        {
            return Ok(_newsItemService.getNewsItemById(newsItemId));
        }

        // http/{s}://localhost:5000/{1}/api/1
        [Route("{newsitemid:int}")]
        [HttpPut]
        public IActionResult UpdateNewsItemById([FromBody] NewsItemInputModel newsItem, int newsItemId, [FromHeader] string password)
        {
            if(MySampleActionFilter.OnActionExecuting(password))
            {
                _newsItemService.UpdateNewsItemById(newsItem,newsItemId);
                return NoContent();
            }
            else{
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }

        [Route("")]
        [HttpPost]
        public IActionResult CreateNewNewsItem([FromBody] NewsItemInputModel body)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            var entity = _newsItemService.CreateNewNewsItem(body);
            return CreatedAtRoute("getNewsItemById", new { id = entity.Id }, null);
        }
        

        // http/{s}://localhost:5000/{1}/api/1
        [Route("{newsitemid:int}")]
        [HttpDelete]
        public IActionResult DeleteNewsItemById(int newsItemId)
        {
            _newsItemService.DeleteNewsItemById(newsItemId);
            _newsItemService.DeleteNewsItemAuthorConnection(newsItemId);
            _newsItemService.DeleteNewsItemCategoriesConnection(newsItemId);
            return NoContent();
        }

        [Route("/categories")]
        [HttpGet]
        // Should work, but does this confine to the 3 layered system?
        public IActionResult getAllCategories([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
        {   
            var categories = _categoryService.getAllCategories();
            // foreach (var category in categories)
            // {
            //     category.Links.AddReference("self", $"/api/category/{r.Id}");
            //     category.Links.AddReference("edit", $"/api/category/{r.Id}");
            //     category.Links.AddReference("delete", $"/api/category/{r.Id}");
            // }
            // categories.ForEach(r => {
                
            // });
            var envelope = new Envelope<CategoryDto>(pageSize, pageNumber, categories);
            return Ok(envelope);
        }

        [Route("/categories/{categoryId:int}", Name="getCategoryById")]
        [HttpGet]
        public IActionResult getCategoryById(int categoryId)
        {
            
            return Ok(_categoryService.getCategoryById(categoryId));
        }

        [Route("/categories/{categoryId:int}")]
        [HttpPost]
        public IActionResult CreateNewCategory([FromBody] CategoryInputModel category)
        {
            var newcategory = _categoryService.CreateNewCategory(category);
            return CreatedAtRoute("getCategoryById", new { id = newcategory.Id }, null);
        }

        [Route("/api/categories/{categoryId}/newsItems/{newsItemId}")]
        [HttpPost]
        public IActionResult CreateNewAuthorNewsItemLink(int categoryId, int newsItemId)
        {
            var entity = _categoryService.CreateNewAuthorNewsItemLink(categoryId,newsItemId);
            return NoContent();
        }

        [Route("/categories/{categoryId:int}")]
        [HttpPut]
        public IActionResult UpdateCategoryById([FromBody] CategoryInputModel category , int categoryId)
        {
            _categoryService.UpdateCategoryById(category,categoryId);
            return NoContent();
        }

        [Route("/categories/{categoryId:int}")]
        [HttpDelete]
        public IActionResult deleteCategoryById(int categoryId)
        {
            _categoryService.DeleteCategoryById(categoryId);
            return NoContent();
        }

        [Route("/authors")]
        [HttpGet]
        public IActionResult getAllAuthors([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25) 
        {
            var authors = _authorService.getAllAuthors();
            var envelope = new Envelope<AuthorDto>(pageSize, pageNumber, authors); 
            return Ok(authors);
        }

        [Route("/authors/{authorId:int}", Name="getAuthorById")]
        [HttpGet]
        public IActionResult getAuthorById(int authorId)
        {
            return Ok(_authorService.getAuthorById(authorId));
        }

        [Route("/authors/{authorId:int}/newsItems")]
        [HttpGet]
        public IActionResult getNewsItemsOfAuthor(int authorId) 
        { 
            return Ok(_authorService.getNewsItemsByAuthorId(authorId)); 
        }

        [Route("/authors")]
        [HttpPost]
        public IActionResult createNewAuthor([FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest("Model is not properly formatted."); 
            }
            var entity = _authorService.createNewAuthor(author);
            return CreatedAtRoute("getAuthorById", new { id = entity.Id }, null);
        }

        [Route("/authors/{authorId:int}")]
        [HttpPut]
        public IActionResult updateAuthorById([FromBody] AuthorInputModel author, int id)
        {
            _authorService.UpdateAuthorById(author, id);
            return NoContent();
        }
        [Route("/authors/{authorId:int}")]
        [HttpDelete]
        public IActionResult deleteAuthorById(int authorId)
        {
            _authorService.DeleteAuthorById(authorId);
            return NoContent();
        }

        [Route("/authors/{authorId:int}/newsItems/{newsItemId:int}")]
        [HttpPost]
        public IActionResult createNewAuthorNewsItemLink(int authorId, int newsItemId)
        {
            _authorService.createNewAuthorNewsItemLink(authorId, newsItemId);
            return NoContent();
        }
    }
}
