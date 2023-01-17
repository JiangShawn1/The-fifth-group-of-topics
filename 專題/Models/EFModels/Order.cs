namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNumber { get; set; }

        public DateTime? CreateAt { get; set; }

        public int OrderType { get; set; }

        public int OrderStatus { get; set; }

        public int TradeStatus { get; set; }

        public int? UseCoupon { get; set; }

        public int Amount { get; set; }

        [StringLength(50)]
        public string ShippingMethod { get; set; }

        [StringLength(200)]
        public string OrderAddress { get; set; }

        [Required]
        [StringLength(500)]
        public string OrderContent { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual Member Member { get; set; }
    }
}
