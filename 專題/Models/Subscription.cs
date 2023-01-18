namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subscription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscription()
        {
            Members_Subscriptions = new HashSet<Members_Subscriptions>();
        }

        public int SubscriptionId { get; set; }

        [Required]
        [StringLength(50)]
        public string SubscriptionName { get; set; }

        public int SubscriptionTier { get; set; }

        public int SubscriptionPrice { get; set; }

        public DateTime CreateAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Members_Subscriptions> Members_Subscriptions { get; set; }
    }
}
