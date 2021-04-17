using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.Model
{
    [Table("ReconciliationItem")]
    public class ReconciliationItem : IEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public IncomeExpense IncomeExpenseType { get; set; }
        public string ItemName { get; set; }
    }
}
