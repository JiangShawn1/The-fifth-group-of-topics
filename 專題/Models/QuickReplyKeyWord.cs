namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuickReplyKeyWord
    {
        public int Id { get; set; }

        public int QuickReplyID { get; set; }

        [Required]
        [StringLength(200)]
        public string KeyWord { get; set; }

        public virtual QuickReply QuickReply { get; set; }
    }
}
