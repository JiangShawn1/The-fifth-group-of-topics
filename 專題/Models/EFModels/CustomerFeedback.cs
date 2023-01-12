namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	using System.Net.Mail;
	using System.Net;
    using System.ComponentModel;

	public partial class CustomerFeedback
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
		[DisplayName("回覆內容")]
		public string FeedbackContent { get; set; }

        [Required]
        [StringLength(100)]
		[DisplayName("客戶名稱")]
		public string CustomerName { get; set; }

        [Required]
        [StringLength(256)]
		[DisplayName("聯絡信箱")]
		public string Email { get; set; }


		[DisplayName("問題類型")]
		public int QuestionTypeId { get; set; }


		[DisplayName("狀態")]
		public int Status { get; set; }

		[DisplayName("留言時間")]

		public DateTime CreateTime { get; set; }

        public virtual QuestionType QuestionType { get; set; }

		
	}
		
}
