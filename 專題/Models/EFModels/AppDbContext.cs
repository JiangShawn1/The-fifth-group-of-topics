using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace 專題.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=TheFifthGroupOfTopics")
		{
		}

		public virtual DbSet<AutoReply> AutoReplies { get; set; }
		public virtual DbSet<AutoReplyKeyWord> AutoReplyKeyWords { get; set; }
		public virtual DbSet<ChatContent> ChatContents { get; set; }
		public virtual DbSet<ChatRoomAutoReply> ChatRoomAutoReplies { get; set; }
		public virtual DbSet<ChatRoom> ChatRooms { get; set; }
		public virtual DbSet<CommonAnswer> CommonAnswers { get; set; }
		public virtual DbSet<CommonQuestion> CommonQuestions { get; set; }
		public virtual DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<QuestionType> QuestionTypes { get; set; }
		public virtual DbSet<QuickReply> QuickReplies { get; set; }
		public virtual DbSet<QuickReplyKeyWord> QuickReplyKeyWords { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AutoReply>()
				.HasMany(e => e.AutoReplyKeyWords)
				.WithRequired(e => e.AutoReply)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<AutoReply>()
				.HasMany(e => e.ChatRoomAutoReplies)
				.WithRequired(e => e.AutoReply)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ChatRoom>()
				.HasMany(e => e.ChatContents)
				.WithRequired(e => e.ChatRoom)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ChatRoom>()
				.HasMany(e => e.ChatRoomAutoReplies)
				.WithRequired(e => e.ChatRoom)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CommonQuestion>()
				.HasMany(e => e.CommonAnswers)
				.WithRequired(e => e.CommonQuestion)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Employee>()
				.HasMany(e => e.ChatContents)
				.WithRequired(e => e.Employee)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<QuestionType>()
				.HasMany(e => e.CommonQuestions)
				.WithRequired(e => e.QuestionType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<QuestionType>()
				.HasMany(e => e.CustomerFeedbacks)
				.WithRequired(e => e.QuestionType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<QuickReply>()
				.HasMany(e => e.QuickReplyKeyWords)
				.WithRequired(e => e.QuickReply)
				.WillCascadeOnDelete(false);
		}
	}
}
