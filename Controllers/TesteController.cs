using Microsoft.AspNetCore.Mvc;



namespace WebApplication1.Controllers
{


    public class Result
    {
        public string? Texto = string.Empty;
    }

    public class TesteController : Controller
    {
        string [] palavra;
        string palavracodificada;
        char[] alfabeto = new char[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };


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

            palavra = new string[texto.Length];
            palavracodificada = "";

            for (int i = 0; i < texto.Length; i++)
            {
                palavra[i] = texto.Substring(i, 1);
            }

            for(int i = 0;i < palavra.Length; i++)
            {
                char letraOriginal = char.Parse(palavra[i]);

                if (char.IsLetter(letraOriginal))
                {
                    
                    int posicaoOriginal = Array.IndexOf(alfabeto, char.ToLower(letraOriginal));

                    
                    int novaPosicao = (posicaoOriginal + 3) % alfabeto.Length;

                    
                    char novaLetra = alfabeto[novaPosicao];

                    
                    if (char.IsUpper(letraOriginal))
                    {
                        palavracodificada += char.ToUpper(novaLetra);
                    }
                    else
                    {
                        palavracodificada += novaLetra;
                    }
                }
                else
                {
                    
                    palavracodificada += letraOriginal;
                }
            }

            
            resultado.Texto = palavracodificada;

            return View("Index", resultado);
        }
    }
}
