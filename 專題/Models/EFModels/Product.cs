namespace å°ˆé?.Models.EFModels
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

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public int? Brand_Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ProductName { get; set; }

    [Required]
    [StringLength(500)]
    public string ProductIntroduce { get; set; }

    public int Color_Id { get; set; }

    public int Price { get; set; }

    [StringLength(300)]
    public string ImageUrl { get; set; }

    public virtual Brand Brand { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<CartItem> CartItems { get; set; }

    public virtual Color Color { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Stock> Stocks { get; set; }
}
}
