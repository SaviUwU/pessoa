using Microsoft.AspNetCore.Mvc;
using pessoa.teste;

namespace pessoa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoinhaController : ControllerBase
    {
       
        [HttpPost("calcular-e-consultar-imc")]
        public IActionResult CalcularEConsultarIMC([FromBody] Pessoa pessoa)
        {
            if (pessoa.Altura <= 0 || pessoa.Peso <= 0)
            {
                return BadRequest("Peso e altura devem ser maiores que zero.");
            }

            double imc = pessoa.Peso / (pessoa.Altura * pessoa.Altura);
            string descricao = ObterDescricaoIMC(imc);

            return Ok(new
            {
                Nome = pessoa.Nome,
                Peso = pessoa.Peso,
                Altura = pessoa.Altura,
                IMC = imc,
                Descricao = descricao
            });
        }

        private string ObterDescricaoIMC(double imc)
        {
            if (imc < 16)
            {
                return "Magreza grave";
            }
            else if (imc >= 16 && imc < 16.9)
            {
                return "Magreza moderada";
            }
            else if (imc >= 17 && imc < 18.4)
            {
                return "Magreza leve";
            }
            else if (imc >= 18.5 && imc < 24.9)
            {
                return "Saudável";
            }
            else if (imc >= 25 && imc < 29.9)
            {
                return "Sobrepeso";
            }
            else if (imc >= 30 && imc < 34.9)
            {
                return "Obesidade grau I";
            }
            else if (imc >= 35 && imc < 39.9)
            {
                return "Obesidade grau II";
            }
            else
            {
                return "Obesidade grau III";
            }
        }
    }
}
