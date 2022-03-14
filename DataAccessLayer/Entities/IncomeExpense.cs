using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class IncomeExpense
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Price { get; set; }
        public string ImageBase64 { get; set; }
        public int InExTypeID { get; set; }

        [ForeignKey("InExTypeID")]
        public InExType InExType { get; set; }
    }
}
