namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Information
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Information()
        {
            Registration_Information = new HashSet<Registration_Information>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]       
		[Display(Name = "參賽人")]
		public string Name { get; set; }

        [Required]
        [StringLength(10)]
		[Display(Name = "電話")]
		public string Phone { get; set; }
		[Display(Name = "性別")]
		public bool Gender { get; set; }

        [Required]
        [StringLength(50)]
		[Display(Name = "地址")]
		public string Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration_Information> Registration_Information { get; set; }
    }
}
