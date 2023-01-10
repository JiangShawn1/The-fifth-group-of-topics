namespace 專題.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
	using System.Net.Mail;
	using System.Net;
	using System.Net;
	using System.Net.Mail;

	public partial class CustomerFeedback
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string FeedbackContent { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }

        public int QuestionTypeId { get; set; }

        public int Status { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual QuestionType QuestionType { get; set; }

		public void SendEmail()
		{
			//設定smtp主機
			string smtpAddress = "smtp.gmail.com";
			//設定Port
			int portNumber = 587;
			bool enableSSL = true;
			//填入寄送方email和密碼
			string emailFrom = "tonytest06480@gmail.com";
			string password = "bwuxyasyhbzaeqyn";
			//收信方email 可以用逗號區分多個收件人
			string emailTo = "tonytest06480@gmail.com";
			//主旨
			string subject = "測試";
			//內容
			string body = "測試測試測試";

			using (MailMessage mail = new MailMessage())
			{
				mail.From = new MailAddress(emailFrom);
				mail.To.Add(emailTo);
				mail.Subject = subject;
				mail.Body = body;
				// 若你的內容是HTML格式，則為True
				mail.IsBodyHtml = false;

				//如果需要夾帶檔案
				//mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
				//mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

				using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
				{
					smtp.Credentials = new NetworkCredential(emailFrom, password);
					smtp.EnableSsl = enableSSL;
					smtp.Send(mail);
				}
			}
		}
	}
		
}
