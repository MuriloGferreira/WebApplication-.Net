using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{

    [Route("pessoas")]

    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;

        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var pessoas = await _pessoaService.ListarPessoa();
            return Ok(pessoas);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] PessoaDTO pessoa)
        {
            await _pessoaService.AdicionarPessoa(pessoa);

            return Created("", string.Empty);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPeloId([FromRoute] long id)
        {
            var pessoa = await _pessoaService.BuscarPessoaID(id);

            return Ok(pessoa);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] PessoaDTO pessoa)
        {
            await _pessoaService.AtualizarPessoa(pessoa);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar([FromRoute] long id)
        {
            await _pessoaService.DeletarPessoa(id);

            return Ok();
        }
    }


}