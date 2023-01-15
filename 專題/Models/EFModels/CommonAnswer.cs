namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommonAnswer
    {
        public int Id { get; set; }

        [DisplayName("問題")]
        public int CommonQuestionId { get; set; }

        [Required]
        [StringLength(1000)]
        [DisplayName("回覆")]
        public string Answer { get; set; }

        [DisplayName("問題")]
        public virtual CommonQuestion CommonQuestion { get; set; }
    }
}
