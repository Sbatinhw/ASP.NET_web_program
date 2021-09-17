using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetsPersons.Domain.Interfaces;
using TimeSheetsPersons.Models;
using TimeSheetsPersons.Models.DTO;

namespace TimeSheetsPersons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonManager personManager;

        public PersonController(IPersonManager personManager)
        {
            this.personManager = personManager;
        }

        [HttpGet("persons/{id}")]
        public IActionResult GetById([FromRoute]int id)
        {
            Person result = personManager.GetById(id);

            return Ok(result);
        }

        [HttpGet("persons/SearchTerm={term}")]
        public IActionResult GetByName([FromBody] string term)
        {
            Person result = personManager.GetByName(term);

            return Ok(result);
        }

        [HttpGet("persons/skip={skip}take={take}")]
        public IActionResult GetPagination(
            [FromRoute] int skip,
            [FromRoute] int take
            )
        {
            List<Person> result = personManager.GetByPagination(skip, take).ToList();

            return Ok(result);
        }

        [HttpPost("persons")]
        public IActionResult Create([FromBody] DtoPersonCreate dtoPerson)
        {
            personManager.Create(dtoPerson);

            return Ok();
        }

        [HttpPut("persons")]
        public IActionResult Update([FromBody] Person person)
        {
            personManager.Update(person);

            return Ok();
        }

        [HttpDelete("persons/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            personManager.Delete(id);

            return Ok();
        }

    }
}
