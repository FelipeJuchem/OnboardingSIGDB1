using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Data.Repositorios
{
    public class EmpresaRepository : Repository<int, Empresa>, IEmpresaRepositorio
    {
        private readonly DataContext _context;

        public EmpresaRepository(DataContext context) : base(context)
        {
            _context = context;
        }


    }
}
