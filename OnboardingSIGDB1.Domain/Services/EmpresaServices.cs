using OnboardingSIGDB1.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;



namespace OnboardingSIGDB1.Domain.Services
{
    public class EmpresaServices
    {

        private readonly IEmpresaRepositorio _empresaRepositorio;
        public EmpresaServices(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public void Deletar(int empId)
        {
            //var empresa = _context.Empresa.Where(x => x.Id == empId ).FirstOrDefault();
            //_context.Empresa.Remove(empresa);
            //_context.SaveChanges();
            var empresa = _empresaRepositorio.BuscarPorId(empId);
        }



    }
}
