namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Members_Subscriptions
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubscriptionId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime StartAt { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime EndAt { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IsRenew { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime CreateAt { get; set; }

        public virtual Member Member { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}
