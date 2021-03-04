using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Interfaces.Services
{
    public interface IEmpresaService
    {
        Task Deletar(int empId);
    }
}
