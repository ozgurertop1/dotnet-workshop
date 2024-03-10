using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Core.UnitofWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync(); //SaveChangesAsync temsil etsin.
        void Commit(); //SaveChanges() temsil etsin.
    }
}
