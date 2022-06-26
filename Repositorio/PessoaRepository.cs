using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AplicationDbContext _context;

        private readonly DbSet<Pessoa> _pessoa;

        public PessoaRepository(AplicationDbContext context)
        {
            _context = context;
            _pessoa = _context.Set<Pessoa>();
        }

        public async Task AdicionarPessoa(Pessoa pessoa)
        {
            await _pessoa.AddAsync(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarPessoa(Pessoa pessoa)
        {
            _pessoa.Update(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<Pessoa> BuscarPessoaID(long id)
        {
            return await _pessoa.FindAsync(id); 
        }

        public async Task DeletarPessoa(Pessoa pessoa)
        {
            _pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pessoa>> ListarPessoa()
        {
            return await _pessoa.OrderBy(x => x.Id).ToListAsync();
        }



    }
}
