using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace 專題.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
			: base("name=AppDbContext1")
		{
		}

		public virtual DbSet<Forum_SectionBranch1Topics> Forum_SectionBranch1Topics { get; set; }
		public virtual DbSet<Forum_SectionBranch1TopicsThread> Forum_SectionBranch1TopicsThread { get; set; }
		public virtual DbSet<ForumSection> ForumSections { get; set; }
		public virtual DbSet<ForumSectionBranch> ForumSectionBranches { get; set; }
		public virtual DbSet<Member> Members { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Forum_SectionBranch1Topics>()
				.HasMany(e => e.Forum_SectionBranch1TopicsThread)
				.WithRequired(e => e.Forum_SectionBranch1Topics)
				.HasForeignKey(e => e.topicId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ForumSection>()
				.HasMany(e => e.ForumSectionBranches)
				.WithRequired(e => e.ForumSection)
				.HasForeignKey(e => e.sectionNameId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ForumSectionBranch>()
				.HasMany(e => e.Forum_SectionBranch1Topics)
				.WithRequired(e => e.ForumSectionBranch)
				.HasForeignKey(e => e.BranchId)
				.WillCascadeOnDelete(false);

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
				.HasMany(e => e.Forum_SectionBranch1TopicsThread)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.replyMemberId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.ForumSectionBranches)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.administratorId)
				.WillCascadeOnDelete(false);
		}
	}
}
