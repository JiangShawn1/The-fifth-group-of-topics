namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderId { get; set; }

        public int MemberId { get; set; }

        [Required]
        [StringLength(500)]
        public string OrderContent { get; set; }

        [Required]
        [StringLength(50)]
        public string ShippingMethod { get; set; }

        [Required]
        [StringLength(200)]
        public string OrderAddress { get; set; }

        public bool IsPaid { get; set; }

        public DateTime CreateAt { get; set; }

        public virtual Member Member { get; set; }
    }
}
