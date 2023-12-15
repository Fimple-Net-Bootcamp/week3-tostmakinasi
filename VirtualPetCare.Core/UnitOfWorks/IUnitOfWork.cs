using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCare.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();

        void CommitChanges();

        Task BeginTransactionAsync();

        Task TransactionCommitAsync();

    }
}
