namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomerFeedback
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string FeedbackContent { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        public int QuestionTypeId { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual QuestionType QuestionType { get; set; }
    }
}
