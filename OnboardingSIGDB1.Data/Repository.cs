using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Domain.Base;
using OnboardingSIGDB1.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.Data
{
    public class Repository<TId,TEntity> : IRepository<TId, TEntity>
        where TId : struct
        where TEntity : Entity<TId, TEntity>  
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DataContext context)
        {
            _dbSet = context.Set<TEntity>(); 
        }

        public void Adicionar(TEntity obj)
        {
            _dbSet.Add(obj);
        }
        public void Atualizar(TEntity obj)
        {
            _dbSet.Update(obj);
        }
        public void Remover(TEntity obj)
        {
            _dbSet.Remove(obj);
        }
        public async Task<IEnumerable<TEntity>> Buscar()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity>BuscarPorId(TId id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => EqualityComparer<TId>.Default.Equals(x.Id,id));
        }




    }
}
