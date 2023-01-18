namespace 專題.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registration_Information
    {
        public int Id { get; set; }

        public int RegistrationID { get; set; }

        public int InformationID { get; set; }

        public virtual Information Information { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
