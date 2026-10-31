using PeopleWebAPI.Models;
using PeopleWebAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace PeopleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new PersonData().GetPeople();
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] Person value)
        {
            var pd = new PersonData();
            pd.SavePerson(value);
        }
    }
}
