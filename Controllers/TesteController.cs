using Microsoft.AspNetCore.Mvc;



namespace WebApplication1.Controllers
{


    public class Result
    {
        public string? Texto = string.Empty;
    }

    public class TesteController : Controller
    {
        string palavra;

        private readonly ILogger<TesteController> _logger;

        
        public TesteController(
        
            ILogger<TesteController> logger
        )
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View("Index", new Result());
        }

        [HttpPost]
        public IActionResult Index(string texto)
        {
            Result resultado = new();
            resultado.Texto = texto.ToUpper();
            
            for(int i = 0; i <= texto.Length; i++)
            {
                palavra = texto.Substring(0, 1);

            }
            resultado.Texto = palavra;

            return View("Index", resultado);
        }
    }
}
