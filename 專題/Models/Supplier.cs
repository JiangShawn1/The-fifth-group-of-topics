namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            Contests = new HashSet<Contest>();
        }

        public int SupplierId { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierName { get; set; }

        [Required]
        [StringLength(50)]
        public string SupplierTel { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierAdd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contest> Contests { get; set; }
    }
}
