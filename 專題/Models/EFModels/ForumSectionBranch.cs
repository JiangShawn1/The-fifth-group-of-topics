namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ForumSectionBranch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ForumSectionBranch()
        {
            Forum_SectionBranch1Topics = new HashSet<Forum_SectionBranch1Topics>();
        }

        public int id { get; set; }

        public int sectionNameId { get; set; }

        [StringLength(50)]
        public string branchName { get; set; }

        [Required]
        [StringLength(50)]
        public string sectionAdministrator { get; set; }

        public int administratorId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Forum_SectionBranch1Topics> Forum_SectionBranch1Topics { get; set; }

        public virtual ForumSection ForumSection { get; set; }

        public virtual Member Member { get; set; }
    }
}
