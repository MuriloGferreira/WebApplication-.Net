using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task AdicionarPessoa(Pessoa pessoa);

        Task AtualizarPessoa(Pessoa pessoa);

        Task DeletarPessoa(Pessoa pessoa);

        Task<List<Pessoa>> ListarPessoa();

        Task<Pessoa> BuscarPessoaID(long id);
    }
}
