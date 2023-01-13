namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Forum_SectionBranch1TopicsThread
    {
        public int id { get; set; }

        public int topicId { get; set; }

        public int topicState { get; set; }

        public int replyNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string replyContent { get; set; }

        public DateTime replyTime { get; set; }

        public int? replyState { get; set; }

        public int? replyMemberId { get; set; }

        public virtual Forum_SectionBranch1Topics Forum_SectionBranch1Topics { get; set; }
    }
}
