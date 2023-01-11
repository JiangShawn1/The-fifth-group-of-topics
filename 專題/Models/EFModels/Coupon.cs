namespace 專題.Models.EFModels
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
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CouponName { get; set; }

        [Required]
        [StringLength(50)]
        public string CouponNumber { get; set; }

        public int CouponType { get; set; }

        public int CouponDiscount { get; set; }

        public int? CouponQuantity { get; set; }

        public int? AccountQuantity { get; set; }

        public int? MinSpend { get; set; }

        public bool IsCombine { get; set; }

        [StringLength(50)]
        public string CouponImage { get; set; }

        [StringLength(500)]
        public string CouponContent { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime? EndAt { get; set; }

        public int? CorrespondProduct { get; set; }

        public DateTime CreateAt { get; set; }

        public bool SoftDelete { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
