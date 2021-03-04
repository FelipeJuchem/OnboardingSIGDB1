using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities
{
    public class Cargo
    {
        public Cargo(string descricao)
        {
            Descricao = descricao;
        }
        public Cargo()
        {
        }

        public int Id { get; set; }
        public string Descricao { get; set; }


    }
}
