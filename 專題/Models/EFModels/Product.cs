namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }

        public int? Brand_Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} 不得大於 {1}")]
        [Display(Name ="商品名稱")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "價錢必須填寫")]
        [StringLength(500)]
        [Display(Name = "商品介紹")]
        public string ProductIntroduce { get; set; }

        public int Color_Id { get; set; }

        [Required(ErrorMessage ="價錢必須填寫")]
        [Display(Name = "價錢")]

        public int Price { get; set; }

        [Required(ErrorMessage ="商品圖片必須上傳")]
        public string ImageUrl { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual Color Color { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
