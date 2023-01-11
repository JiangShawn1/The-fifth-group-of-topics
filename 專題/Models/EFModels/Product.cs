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

        [Required, Display(Name = "品牌名稱")]
        public int Brand_Id { get; set; }

        [StringLength(50, ErrorMessage = "請勿超過50個字")]
        [Display(Name = "商品名稱")]
        [Required(ErrorMessage = "請輸入名稱")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "請輸入商品介紹")]
        [StringLength(500, ErrorMessage = "請勿超過500個字")]
        [Display(Name = "商品介紹")]
        public string ProductIntroduce { get; set; }
        [Required]
        [Display(Name = "商品顏色")]
        public int Color_Id { get; set; }
        [Required(ErrorMessage = "請輸入商品價錢")]
        [Display(Name = "商品價錢")]
        public int Price { get; set; }
        [Required(ErrorMessage = "請上傳商品圖片")]
        [Display(Name = "商品圖片")]
        public int ProductsImages_Id { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual Color Color { get; set; }

        public virtual ProductsImage ProductsImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
