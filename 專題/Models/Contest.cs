namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contest()
        {
            Contest_Category = new HashSet<Contest_Category>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SupplierID { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime ContestDate { get; set; }

        public DateTime RegistrationDeadline { get; set; }

        [Required]
        [StringLength(50)]
        public string Area { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        [Required]
        public string MapURL { get; set; }

        [Required]
        [StringLength(50)]
        public string RegistrationURL { get; set; }

        [Required]
        public string Detail { get; set; }

        public int Review { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contest_Category> Contest_Category { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
