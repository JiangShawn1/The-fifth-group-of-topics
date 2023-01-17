namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductsImage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
