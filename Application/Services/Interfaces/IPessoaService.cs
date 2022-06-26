using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Services.Interfaces
{
    public interface IPessoaService
    {
        Task AdicionarPessoa(PessoaDTO pessoa);

        Task AtualizarPessoa(PessoaDTO pessoa);

        Task DeletarPessoa(long id);

        Task<List<PessoaDTO>> ListarPessoa();

        Task<PessoaDTO> BuscarPessoaID(long id);
    }
}
