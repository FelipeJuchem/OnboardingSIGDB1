using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities
{
    public class Funcionario
    {

        public Funcionario(string nome, string cpf, DateTime dataContratacao )
        {
            Nome = nome;
            Cpf = cpf;
            DataContratacao = dataContratacao;
        }

        protected Funcionario()
        {
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataContratacao { get; private set; }
    }
}
