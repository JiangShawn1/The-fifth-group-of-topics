namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountBalance")]
    public partial class AccountBalance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AccountBalance()
        {
            TransactionRecords = new HashSet<TransactionRecord>();
        }

        [Key]
        public int AccountId { get; set; }

        public int MemberId { get; set; }

        public int Balance { get; set; }

        public DateTime CreateAt { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransactionRecord> TransactionRecords { get; set; }

        public virtual TransactionRecord TransactionRecord { get; set; }
    }
}
