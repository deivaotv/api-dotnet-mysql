using ApiMySql.Model;
using ApiMySql.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiMySql.Controller
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [Produces(typeof(Pessoa))]
        public IActionResult Get()
        {
            var pessoas = _pessoaRepository.GetAll();

            if (pessoas.Count() == 0)
                return NoContent();

            return Ok(pessoas);
        }

    }
}