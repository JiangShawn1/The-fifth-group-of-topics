namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Forum_S1MainTopicBranch1
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int boardNameId { get; set; }

        public int essayId { get; set; }

        [Required]
        [StringLength(100)]
        public string essayTopic { get; set; }

        public int State { get; set; }

        public virtual Forum_S1MainTopicsBranch1Thread Forum_S1MainTopicsBranch1Thread { get; set; }
    }
}
