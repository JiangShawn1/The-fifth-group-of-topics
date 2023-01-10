namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CartItem
    {
        public int Id { get; set; }

        public int Member_Id { get; set; }

        public int Product_Id { get; set; }

        public int Qty { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
