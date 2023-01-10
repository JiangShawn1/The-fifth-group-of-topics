namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChatRoomAutoReply
    {
        public int Id { get; set; }

        public DateTime SentTime { get; set; }

        public int AutoReplyId { get; set; }

        public int ChatRoomId { get; set; }

        public virtual AutoReply AutoReply { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
    }
}
