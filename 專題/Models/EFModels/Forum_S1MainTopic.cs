namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Forum-S1MainTopic")]
    public partial class Forum_S1MainTopic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int boardId { get; set; }

        [Required]
        [StringLength(50)]
        public string boardName { get; set; }

        [Required]
        [StringLength(50)]
        public string boardAdministrator { get; set; }

        public int boardAdministratorId { get; set; }

        public virtual Member Member { get; set; }
    }
}
