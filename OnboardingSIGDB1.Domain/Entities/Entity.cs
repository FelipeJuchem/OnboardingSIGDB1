using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Entities
{
    public abstract class Entity<TId, TEntity>
        where TId : struct 
        where TEntity : Entity<TId, TEntity>
    {
        public TId Id { get; protected set; }



    }
}
