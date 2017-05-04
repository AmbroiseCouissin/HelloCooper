using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloCooper.Repositories;
using HelloCooper.Models;

namespace HelloCooper.Controllers
{
    [Route("api/hellocooper")]
    public class HelloCooperController : Controller
    {
        private readonly IHelloMessageRepository _helloMessageRepository;

        public HelloCooperController(IHelloMessageRepository helloMessageRepository)
        {
            _helloMessageRepository = helloMessageRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (id == null)
                return BadRequest("The id can't be null");

            CustomMessage customHelloMessage = await _helloMessageRepository.GetCustomHelloMessageAsync(id);

            return Ok(customHelloMessage);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CustomMessage customMessage)
        {
            if (customMessage == null || customMessage.Id == null || customMessage.Message == null)
                return BadRequest("The custom message is invalid");

            await _helloMessageRepository.CreateCustomHelloMessageAsync(customMessage);

            return Ok();
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
