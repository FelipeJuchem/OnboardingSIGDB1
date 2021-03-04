using OnboardingSIGDB1.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities
{
    public class Empresa : Entity<int, Empresa>
    {
        public Empresa(string nome,string cnpj, DateTime dataFundacao)
        {
            Nome = nome;
            Cnpj = cnpj;
            DataFundacao = dataFundacao;
        }

        protected Empresa()
        {

        }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataFundacao { get; private set; }
        

    }
}
