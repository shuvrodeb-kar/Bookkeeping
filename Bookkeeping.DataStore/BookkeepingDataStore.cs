using Bookkeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.DataStore
{
    public class BookkeepingDataStore : IBookkeepingDataStore
    {
        private readonly BookkeepingDataContext context;
        public BookkeepingDataStore(BookkeepingDataContext context) {
            this.context = context;
        }
        public MonthYearMapping GetMonthYearMappingByMonthYear(int monthId, int year)
        {
            return context.MonthYearMappings.Where(c => c.MonthId == monthId && c.Year == year).FirstOrDefault();
         }
    }
}
