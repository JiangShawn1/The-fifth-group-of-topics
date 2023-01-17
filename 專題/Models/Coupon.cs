namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coupon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coupon()
        {
            Members_Coupons = new HashSet<Members_Coupons>();
        }

        public int CouponId { get; set; }

        [Required]
        [StringLength(50)]
        public string CouponName { get; set; }

        [Required]
        [StringLength(200)]
        public string CouponContent { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public DateTime CreateAt { get; set; }

        public bool SoftDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Members_Coupons> Members_Coupons { get; set; }
    }
}
