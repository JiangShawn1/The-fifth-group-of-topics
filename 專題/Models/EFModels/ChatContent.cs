namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChatContent
    {
        public int Id { get; set; }

        public DateTime SentTime { get; set; }

        [Column("ChatContent")]
        [Required]
        [StringLength(200)]
        public string ChatContent1 { get; set; }

        public int? MemberId { get; set; }

        public int ChatRoomId { get; set; }

        public int EmployeeId { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Member Member { get; set; }
    }
}
