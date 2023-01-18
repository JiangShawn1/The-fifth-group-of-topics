namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ForumSection")]
	public partial class ForumSection
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public ForumSection()
		{
			ForumSectionBranches = new HashSet<ForumSectionBranch>();
		}

		public int id { get; set; }

		[Required]
		[StringLength(50)]
		public string sectionName { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<ForumSectionBranch> ForumSectionBranches { get; set; }
	}
}

