using appSumaConection.Entities;
using appSumaConection.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace appSumaConection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumaConectionController : ControllerBase
    {
        private readonly ISumaServices _service;

        public SumaConectionController(ISumaServices service)
        {
            _service = service;
        }



        // GET: api/<SumaConectionController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Hola desde la primer api");
        }

        // GET api/<SumaConectionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SumaConectionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Suma suma)
        {
            try
            {
                var result = await _service.Suma(suma);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<SumaConectionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SumaConectionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
