namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Forum_Reply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int Member_Id { get; set; }

        public int replyId { get; set; }

        public virtual Forum_S1MainTopicsBranch1Thread Forum_S1MainTopicsBranch1Thread { get; set; }

        public virtual Member Member { get; set; }
    }
}
