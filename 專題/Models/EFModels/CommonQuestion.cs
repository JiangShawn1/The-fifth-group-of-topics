namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommonQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CommonQuestion()
        {
            CommonAnswers = new HashSet<CommonAnswer>();
        }

        public int Id { get; set; }

        
        [Required]
        [StringLength(1000)]
        public string Question { get; set; }

        public int QuestionTypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommonAnswer> CommonAnswers { get; set; }

        public virtual QuestionType QuestionType { get; set; }
    }
}
