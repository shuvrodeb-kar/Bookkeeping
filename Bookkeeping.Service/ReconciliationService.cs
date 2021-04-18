using Bookkeeping.DataStore;
using Bookkeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.Service
{
    public class ReconciliationService : IReconciliationService
    {
        private readonly IRepository<Reconciliation> repoReconciliation;
        private readonly IRepository<MonthYearMapping> repoMonthYearMapping;
        private readonly IBookkeepingDataStore bookkeepingDataStore;

        public ReconciliationService(IRepository<Reconciliation> repoReconciliation, IRepository<MonthYearMapping> repoMonthYearMapping, IBookkeepingDataStore bookkeepingDataStore) {
            this.repoReconciliation = repoReconciliation;
            this.repoMonthYearMapping = repoMonthYearMapping;
            this.bookkeepingDataStore = bookkeepingDataStore;
        }
        public async Task SaveReconciliation(Reconciliation reconciliation)
        {
            await RetriveMonthYearMappingInfo(reconciliation);

            await repoReconciliation.Add(reconciliation);
        }

        private async Task RetriveMonthYearMappingInfo(Reconciliation reconciliation)
        {
            MonthYearMapping monthYearMapping = new MonthYearMapping();
            monthYearMapping.MonthId = reconciliation.MonthId;
            monthYearMapping.Year = reconciliation.Year;

            MonthYearMapping monthYear = bookkeepingDataStore.GetMonthYearMappingByMonthYear(reconciliation.MonthId, reconciliation.Year);

            if (monthYear == null)
            {
                reconciliation.MonthYearMappingId = await repoMonthYearMapping.Add(monthYearMapping);
            }
            else
            {
                reconciliation.MonthYearMappingId = monthYear.Id;
            }
        }
    }
}
