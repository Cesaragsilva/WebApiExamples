using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI_Examples.Config.Controllers;
using WebAPI_Examples.Dominios;

namespace WebAPI_Examples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new Resultado(Summaries));
        }
    }
}
