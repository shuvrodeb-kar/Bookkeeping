using Bookkeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.DataStore
{
    public interface IBookkeepingDataStore
    {
        MonthYearMapping GetMonthYearMappingByMonthYear(int monthId, int year);
    }
}
