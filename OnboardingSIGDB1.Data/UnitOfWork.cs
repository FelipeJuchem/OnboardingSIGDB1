using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OnboardingSIGDB1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public CommandResponse Commit()
        {
            try
            {
                _dataContext.SaveChanges();
                return new CommandResponse(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new CommandResponse(false);
            }
        }

        public void ResetChanges()
        {
            var entries = _dataContext.ChangeTracker
                .Entries()
                .Where(ent => ent.State != EntityState.Unchanged)
                .ToList();

            for (var i = 0; i < entries.Count; i++)
            {
                var entry = entries.ElementAt(i);
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.State = EntityState.Unchanged;
                        continue;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        continue;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
