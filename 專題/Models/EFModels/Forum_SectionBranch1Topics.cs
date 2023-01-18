namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

	public partial class Forum_SectionBranch1Topics
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Forum_SectionBranch1Topics()
		{
			Forum_SectionBranch1TopicsThread = new HashSet<Forum_SectionBranch1TopicsThread>();
		}

		public int id { get; set; }

		public int BranchId { get; set; }

		[Required]
		[StringLength(100)]
		public string Topic { get; set; }

		public int State { get; set; }

		public virtual ForumSectionBranch ForumSectionBranch { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Forum_SectionBranch1TopicsThread> Forum_SectionBranch1TopicsThread { get; set; }
	}
}

