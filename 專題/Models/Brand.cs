namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Column("Brand")]
        [Required]
        [StringLength(50)]
        public string Brand1 { get; set; }

        [Required]
        [StringLength(50)]
        public string BrandImageUrl { get; set; }

        [Required]
        [StringLength(350)]
        public string BrandIntroduce { get; set; }

        public int OnSale_Id { get; set; }

        public virtual OnSale OnSale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
