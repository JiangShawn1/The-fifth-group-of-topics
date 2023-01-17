namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChatRoomAutoReply
    {
        public int Id { get; set; }

        [DisplayName("發送時間")]
        public DateTime SentTime { get; set; }
		[DisplayName("自動回覆內容")]
		public int AutoReplyId { get; set; }
		[DisplayName("聊天室")]
		public int ChatRoomId { get; set; }

        public virtual AutoReply AutoReply { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
    }
}
