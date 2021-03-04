using OnboardingSIGDB1.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnboardingSIGDB1.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        CommandResponse Commit();
        void ResetChanges();
    }
}
