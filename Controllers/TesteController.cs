using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class Result
    {
        public string? TextoEntrada = string.Empty;
        public string? TextoSaida = string.Empty;
    }

    public class TesteController : Controller
    {
        char[] alfabeto = new char[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
        };

        public IActionResult Index()
        {
            return View("Index", new Result());
        }

        [HttpPost]
        public IActionResult Processar(string texto, string acao)
        {
            Result resultado = new();
            resultado.TextoEntrada = texto;

            if (string.IsNullOrEmpty(texto))
            {
                return View("Index", resultado);
            }

            string textoProcessado = "";

            for (int i = 0; i < texto.Length; i++)
            {
                char letraOriginal = char.Parse(texto.Substring(i, 1));
                char letraProcessada = letraOriginal; 

                if (char.IsLetter(letraOriginal))
                {
                    int posicaoOriginal = Array.IndexOf(alfabeto, char.ToLower(letraOriginal));

                    if (posicaoOriginal != -1)
                    {
                        int novaPosicao;
                        if (acao == "codificar")
                        {
                            novaPosicao = (posicaoOriginal + 3) % alfabeto.Length;
                        }
                        else 
                        {
                            novaPosicao = (posicaoOriginal - 3 + alfabeto.Length) % alfabeto.Length;
                        }

                        letraProcessada = alfabeto[novaPosicao];

                        if (char.IsUpper(letraOriginal))
                        {
                            letraProcessada = char.ToUpper(letraProcessada);
                        }
                    }
                }
                textoProcessado += letraProcessada;
            }

            resultado.TextoSaida = textoProcessado;
            return View("Index", resultado);
        }
    }
}