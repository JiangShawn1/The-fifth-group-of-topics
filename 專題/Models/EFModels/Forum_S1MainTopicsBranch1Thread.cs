namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Forum_S1MainTopicsBranch1Thread
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Forum_S1MainTopicsBranch1Thread()
        {
            Forum_S1MainTopicBranch1 = new HashSet<Forum_S1MainTopicBranch1>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int boardId { get; set; }

        public int topicState { get; set; }

        public int replyNumber { get; set; }

        [Required]
        [StringLength(500)]
        public string replyContent { get; set; }

        public DateTime replyTime { get; set; }

        public int? replyState { get; set; }

        public int? replyMemberId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Forum_S1MainTopicBranch1> Forum_S1MainTopicBranch1 { get; set; }

        public virtual Member Member { get; set; }
    }
}
