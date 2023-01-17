namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AutoReplyKeyWord
    {
        public int Id { get; set; }

        public int AutoReplyID { get; set; }

        [Required]
        [StringLength(200)]
        public string KeyWord { get; set; }

        public virtual AutoReply AutoReply { get; set; }
    }
}
