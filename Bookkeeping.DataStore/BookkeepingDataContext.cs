using Microsoft.EntityFrameworkCore;
using Bookkeeping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.DataStore
{
    public class BookkeepingDataContext : DbContext
    {
        public BookkeepingDataContext(DbContextOptions<BookkeepingDataContext> options) : base(options)
        {
            
        }
        public DbSet<Reconciliation> Reconciliations { get; set; }
        public DbSet<ReconciliationItem> ReconciliationItemInfos { get; set; }
        public DbSet<MonthYearMapping> MonthYearMappings { get; set; }
        public DbSet<BookkeepingInfo> BookkeepingInfos { get; set; }

    }
}
