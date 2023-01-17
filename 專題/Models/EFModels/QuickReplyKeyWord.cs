namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QuickReplyKeyWord
    {
        public int Id { get; set; }

		[DisplayName("回覆內容")]
		public int QuickReplyID { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("關鍵字")]
        public string KeyWord { get; set; }

        public virtual QuickReply QuickReply { get; set; }
    }
}
