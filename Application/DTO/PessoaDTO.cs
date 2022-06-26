using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class PessoaDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Profissao { get; set; }
        public string EstadoCivil { get; set; }

        public PessoaDTO(long id, string nome, int idade, string profissao, string estadoCivil)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Profissao = profissao;
            EstadoCivil = estadoCivil;
        }
    }
   
}
