using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NSB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtendenteController : Controller
    {
        [HttpPost("CadastrarCliente")]

        [HttpGet("ListarClientes")]

        [HttpGet("ListarCliente/[id]")]

        [HttpPut("AlterarCliente")]

        [HttpPost("Comanda")]

        [HttpGet("ListarComandas")]

        [HttpGet("ListarComanda/[id]")]

        [HttpPut("AlterarComanda")]
        //Dentro deste controller vai para outro controller que será para adicionar, deletar produto

        [HttpDelete("CancelarComanda/[id]")]


    }
}
