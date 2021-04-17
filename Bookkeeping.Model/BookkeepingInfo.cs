using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.Model
{
    [Table("BookkeepingInfo")]
    public class BookkeepingInfo : IEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MonthYearMappingId { get; set; }
        public decimal Income { get; set; }
        public decimal Cost { get; set; }
    }
}
