using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET.Business;
using RestWithASP_NET.Data.VO;
using Tapioca.HATEOAS;

namespace RestWithASP_NET.Controllers
{
   
    [ApiVersion("1")]
    [Route("api/[Controller]/v{version:apiVersion}")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookBusiness _bookBusiness;
        public BooksController(IBookBusiness bookBusiness)
        {
          _bookBusiness = bookBusiness;
        }

        // GET api/books
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<BookVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        // GET api/books/5
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(BookVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BookVO book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(_bookBusiness.Create(book));
        }

        // PUT api/books
        [HttpPut]
        [ProducesResponseType((202), Type = typeof(BookVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BookVO book)
        {
           if (book == null) return BadRequest();
           var updatedbook = _bookBusiness.Update(book);
           if (updatedbook == null) return NoContent();
           return new ObjectResult(updatedbook);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {            
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
