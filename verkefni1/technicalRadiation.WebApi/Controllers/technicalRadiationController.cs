using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using technicalRadiation.Service;

namespace technicalRadiation.WebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TRController : ControllerBase
    {
        private NewsItemService _newsItemService = new NewsItemService();

        // [FromQuery] type name
        // http/{s}://localhost:5000/{1}/api
        [Route("")]
        [HttpGet]
        public IActionResult getAllNewsItems()
        {
            return Ok(_newsItemService.getAllNewsItems());
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
        public IActionResult getAllCategories()
        {
            return Ok();
        }

        [Route("/categories/{categoryId:int}")]
        [HttpGet]
        public IActionResult getCategoryById(int categoryId)
        {
            return Ok();
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
        public IActionResult getAllAuthors() 
        { 
            return Ok();
        }

        [Route("/authors/{authorId:int}")]
        [HttpGet]
        public IActionResult getAuthorById(int authorId)
        {
            return Ok();
        }

        [Route("/authors/{authorId:int}/newsItems")]
        public IActionResult getNewsItemsOfAuthor(int authorId) 
        { 
            return Ok(); 
        }
    }
}
