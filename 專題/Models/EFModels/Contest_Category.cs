namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Contest_Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contest_Category()
        {
            Registrations = new HashSet<Registration>();
        }

        public int Id { get; set; }

        public int ContestID { get; set; }

        public int CategoryID { get; set; }

        public int Quota { get; set; }

        public int EnterFee { get; set; }

        public virtual Category Category { get; set; }

        public virtual Contest Contest { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
