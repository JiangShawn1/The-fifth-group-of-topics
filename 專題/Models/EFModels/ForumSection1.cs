namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ForumSection1
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string sectionName { get; set; }

        [Required]
        [StringLength(50)]
        public string mainBoardAdministrator { get; set; }

        public int mainTopicId { get; set; }

        public int administratorId { get; set; }

        public virtual Member Member { get; set; }
    }
}
