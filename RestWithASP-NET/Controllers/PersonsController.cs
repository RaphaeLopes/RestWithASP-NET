using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET.Model;
using RestWithASP_NET.Business;

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
        public ActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personBusiness.Create(person));
        }

        // PUT api/values
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
           if (person == null) return BadRequest();
           var updatedPerson = _personBusiness.Update(person);
           if (updatedPerson == null) return NoContent();
           return new ObjectResult(updatedPerson);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {            
             _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
