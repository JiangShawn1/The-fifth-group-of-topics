namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommonAnswer
    {
        public int Id { get; set; }

        public int CommonQuestionId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Answer { get; set; }

        public virtual CommonQuestion CommonQuestion { get; set; }
    }
}
