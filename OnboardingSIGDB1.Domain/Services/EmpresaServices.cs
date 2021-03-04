using OnboardingSIGDB1.Domain.Interfaces.Repositories;
using OnboardingSIGDB1.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Services
{
    public class EmpresaServices : IEmpresaService
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;
        public EmpresaServices(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public async Task Deletar(int empId)
        {
            //var empresa = _context.Empresa.Where(x => x.Id == empId ).FirstOrDefault();
            //_context.Empresa.Remove(empresa);
            //_context.SaveChanges();
            var empresa = await _empresaRepositorio.BuscarPorId(empId);
            if (empresa != null)
            {
                _empresaRepositorio.Remover(empresa);
            }
        }
    }
}
