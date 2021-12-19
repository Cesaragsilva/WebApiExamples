using Microsoft.AspNetCore.Mvc;
using WebAPI_Examples.Dominios;

namespace WebAPI_Examples.Config.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
        }

        protected IActionResult Ok<T>(T resultado) where T : Resultado
        {
            return base.Ok(new { Link = "https://minhaapi.com.br", Data = resultado.Dados });
        }
    }
}
