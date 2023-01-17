namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuickReply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuickReply()
        {
            QuickReplyKeyWords = new HashSet<QuickReplyKeyWord>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        [DisplayName("回覆內容")]
        public string QuickReplyContent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuickReplyKeyWord> QuickReplyKeyWords { get; set; }
    }
}
