namespace 專題.Models.EFModels.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class ProductVM
    {

        public int Id { get; set; }

        [Required]
        public int Brand_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(500)]
        public string ProductIntroduce { get; set; }

        [Required]
        public int Color_Id { get; set; }

        public int Price { get; set; }


        public HttpPostedFileBase ImageUrl { get; set; }


    }
}
