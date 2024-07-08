using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace OcdServiceMono.Lib.Interfaces
{
    public interface IUnitOfWork
    {
        void CreateTransaction();
        void Commit();
        void Roolback();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);        
    }
}
