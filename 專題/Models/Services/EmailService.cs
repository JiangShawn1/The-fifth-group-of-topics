using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace 專題.Models.Services
{
	public class EmailService
	{
		public void SendEmail(string _emailTo, string _subject, string _body)
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
			//string emailTo = "tonytest06480@gmail.com";
			string emailTo = _emailTo;
			//主旨
			//string subject = "測試";
			string subject = _subject;
			//內容
			//string body = "測試測試測試";
			string body = _body;

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