using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.Model
{
    [Table("Reconciliation")]
    public class Reconciliation : IEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MonthYearMappingId { get; set; }
        public int ReconciliationItemId { get; set; }
        public decimal Amount { get; set; }
    }
}
