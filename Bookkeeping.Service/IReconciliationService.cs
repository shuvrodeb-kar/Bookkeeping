using Bookkeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.Service
{
    public interface IReconciliationService
    {
        public Task SaveReconciliation(Reconciliation reconciliation);
    }
}
