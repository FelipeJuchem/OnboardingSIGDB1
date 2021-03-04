using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IRepository<TId, TEntity>
        where TId : struct 
        where TEntity : class 
    {
        void Adicionar(TEntity obj);
        void Atualizar(TEntity obj);
        void Remover(TEntity obj);
        Task<IEnumerable<TEntity>> Buscar();
        Task<TEntity> BuscarPorId(TId id);


    }
}
