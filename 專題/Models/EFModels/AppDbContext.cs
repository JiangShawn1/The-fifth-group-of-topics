using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace 專題.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbContext")
		{
		}

		public virtual DbSet<Forum_S1MainTopicBranch1> Forum_S1MainTopicBranch1 { get; set; }
		public virtual DbSet<Forum_S1MainTopicsBranch1Thread> Forum_S1MainTopicsBranch1Thread { get; set; }
		public virtual DbSet<Forum_S1MainTopic> Forum_S1MainTopic { get; set; }
		public virtual DbSet<ForumSection1> ForumSection1 { get; set; }
		public virtual DbSet<Member> Members { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Forum_S1MainTopicsBranch1Thread>()
				.HasMany(e => e.Forum_S1MainTopicBranch1)
				.WithRequired(e => e.Forum_S1MainTopicsBranch1Thread)
				.HasForeignKey(e => e.essayId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Forum_S1MainTopic>()
				.Property(e => e.boardAdministrator)
				.IsUnicode(false);

			modelBuilder.Entity<ForumSection1>()
				.Property(e => e.mainBoardAdministrator)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Account)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Password)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Phone)
				.IsFixedLength()
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.Property(e => e.Mail)
				.IsUnicode(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Forum_S1MainTopicsBranch1Thread)
				.WithOptional(e => e.Member)
				.HasForeignKey(e => e.replyMemberId);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Forum_S1MainTopic)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.boardAdministratorId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.ForumSection1)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.administratorId)
				.WillCascadeOnDelete(false);
		}
	}
}
