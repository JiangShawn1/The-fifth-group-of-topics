namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TransactionRecord
    {
        [Key]
        public int TradeId { get; set; }

        public int ExportAccountId { get; set; }

        public int ImportAccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string TradeContent { get; set; }

        public int TradeAmount { get; set; }

        public DateTime CreateAt { get; set; }

        public virtual AccountBalance AccountBalance { get; set; }

        public virtual AccountBalance AccountBalance1 { get; set; }
    }
}
