namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChatRoom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatRoom()
        {
            ChatContents = new HashSet<ChatContent>();
            ChatRoomAutoReplies = new HashSet<ChatRoomAutoReply>();
        }

		[DisplayName("聊天室")]
		public int Id { get; set; }

        [DisplayName("開始時間")]
        public DateTime StartTime { get; set; }
		[DisplayName("結束時間")]
		public DateTime EndTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatContent> ChatContents { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatRoomAutoReply> ChatRoomAutoReplies { get; set; }
    }
}
