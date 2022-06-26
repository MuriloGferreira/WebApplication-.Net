using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Model;

namespace Application.Services.Concrete
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task AdicionarPessoa(PessoaDTO pessoa)
        {
            await _pessoaRepository.AdicionarPessoa(CriarObjetoPessoa(pessoa));
        }
          
        public async Task AtualizarPessoa(PessoaDTO pessoa)
        {
            var pessoaId = await _pessoaRepository.BuscarPessoaID(pessoa.Id);

            pessoaId.Nome = pessoa.Nome;
            pessoaId.Idade = pessoa.Idade;
            pessoaId.Profissao = pessoa.Profissao;
            pessoaId.EstadoCivil = pessoa.EstadoCivil;

            await _pessoaRepository.AtualizarPessoa(pessoaId);
        }

        public async Task<PessoaDTO> BuscarPessoaID(long id)
        {
            var buscarId = await _pessoaRepository.BuscarPessoaID(id);

            return CriarObjetoPessoaDTO(buscarId);
        }

        public async Task DeletarPessoa(long id)
        {
            var buscarId = await _pessoaRepository.BuscarPessoaID(id);

            await _pessoaRepository.DeletarPessoa(buscarId);
        }

        public async Task<List<PessoaDTO>> ListarPessoa()
        {
            var repository = await _pessoaRepository.ListarPessoa();

            return CriarListaObjetoDTO(repository);
        }

        private PessoaDTO CriarObjetoPessoaDTO(Pessoa pessoa)
        {
            return new PessoaDTO(pessoa.Id, pessoa.Nome, pessoa.Idade, pessoa.Profissao, pessoa.EstadoCivil);
        }

        private Pessoa CriarObjetoPessoa(PessoaDTO pessoaDTO)
        {
            return new Pessoa(pessoaDTO.Id, pessoaDTO.Nome, pessoaDTO.Idade, pessoaDTO.Profissao, pessoaDTO.EstadoCivil);
        }

        private List<PessoaDTO> CriarListaObjetoDTO(List<Pessoa> pessoa)
        {
            var dtoList = new List<PessoaDTO>();


            foreach(var item in pessoa)
            {
                var dto = new PessoaDTO(item.Id, item.Nome, item.Idade, item.Profissao, item.EstadoCivil);

                dtoList.Add(dto);
            }

            return dtoList;
        }
    }
}
