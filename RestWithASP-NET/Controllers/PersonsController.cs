using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET.Business;
using RestWithASP_NET.Data.VO;
using Swashbuckle.AspNetCore.Swagger;
using Tapioca.HATEOAS;

namespace RestWithASP_NET.Controllers
{
   
    [ApiVersion("1")]
    [Route("api/[Controller]/v{version:apiVersion}")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IPersonBusiness _personBusiness;
        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public ActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values
        [HttpPut]
        [ProducesResponseType((202), Type = typeof(PersonVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
           if (person == null) return BadRequest();
           var updatedPerson = _personBusiness.Update(person);
           if (updatedPerson == null) return NoContent();
           return new ObjectResult(updatedPerson);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {            
             _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
