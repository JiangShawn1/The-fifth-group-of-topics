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

		public virtual DbSet<AccountBalance> AccountBalances { get; set; }
		public virtual DbSet<AutoReply> AutoReplies { get; set; }
		public virtual DbSet<AutoReplyKeyWord> AutoReplyKeyWords { get; set; }
		public virtual DbSet<Brand> Brands { get; set; }
		public virtual DbSet<CartItem> CartItems { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<ChatContent> ChatContents { get; set; }
		public virtual DbSet<ChatRoomAutoReply> ChatRoomAutoReplies { get; set; }
		public virtual DbSet<ChatRoom> ChatRooms { get; set; }
		public virtual DbSet<Color> Colors { get; set; }
		public virtual DbSet<CommonAnswer> CommonAnswers { get; set; }
		public virtual DbSet<CommonQuestion> CommonQuestions { get; set; }
		public virtual DbSet<Contest_Category> Contest_Category { get; set; }
		public virtual DbSet<Contest> Contests { get; set; }
		public virtual DbSet<Coupon> Coupons { get; set; }
		public virtual DbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
		public virtual DbSet<Employee> Employees { get; set; }
		public virtual DbSet<Forum_Reply> Forum_Reply { get; set; }
		public virtual DbSet<Forum_S1MainTopicBranch1> Forum_S1MainTopicBranch1 { get; set; }
		public virtual DbSet<Forum_S1MainTopicsBranch1Thread> Forum_S1MainTopicsBranch1Thread { get; set; }
		public virtual DbSet<Forum_S1MainTopic> Forum_S1MainTopic { get; set; }
		public virtual DbSet<ForumSection1> ForumSection1 { get; set; }
		public virtual DbSet<Information> Information { get; set; }
		public virtual DbSet<Member> Members { get; set; }
		public virtual DbSet<Members_Coupons> Members_Coupons { get; set; }
		public virtual DbSet<Members_Subscriptions> Members_Subscriptions { get; set; }
		public virtual DbSet<OnSale> OnSales { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<ProductsImage> ProductsImages { get; set; }
		public virtual DbSet<ProductSize> ProductSizes { get; set; }
		public virtual DbSet<QuestionType> QuestionTypes { get; set; }
		public virtual DbSet<QuickReply> QuickReplies { get; set; }
		public virtual DbSet<QuickReplyKeyWord> QuickReplyKeyWords { get; set; }
		public virtual DbSet<Registration> Registrations { get; set; }
		public virtual DbSet<Registration_Information> Registration_Information { get; set; }
		public virtual DbSet<Stock> Stocks { get; set; }
		public virtual DbSet<Subscription> Subscriptions { get; set; }
		public virtual DbSet<Supplier> Suppliers { get; set; }
		public virtual DbSet<TransactionRecord> TransactionRecords { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AccountBalance>()
				.HasMany(e => e.TransactionRecords)
				.WithRequired(e => e.AccountBalance)
				.HasForeignKey(e => e.ExportAccountId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<AccountBalance>()
				.HasOptional(e => e.TransactionRecord)
				.WithRequired(e => e.AccountBalance1);

			modelBuilder.Entity<AutoReply>()
				.HasMany(e => e.AutoReplyKeyWords)
				.WithRequired(e => e.AutoReply)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<AutoReply>()
				.HasMany(e => e.ChatRoomAutoReplies)
				.WithRequired(e => e.AutoReply)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Brand>()
				.HasMany(e => e.Products)
				.WithRequired(e => e.Brand)
				.HasForeignKey(e => e.Brand_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Category>()
				.HasMany(e => e.Contest_Category)
				.WithRequired(e => e.Category)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ChatRoom>()
				.HasMany(e => e.ChatContents)
				.WithRequired(e => e.ChatRoom)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ChatRoom>()
				.HasMany(e => e.ChatRoomAutoReplies)
				.WithRequired(e => e.ChatRoom)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Color>()
				.HasMany(e => e.Products)
				.WithRequired(e => e.Color)
				.HasForeignKey(e => e.Color_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<CommonQuestion>()
				.HasMany(e => e.CommonAnswers)
				.WithRequired(e => e.CommonQuestion)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Contest_Category>()
				.HasMany(e => e.Registrations)
				.WithRequired(e => e.Contest_Category)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Contest>()
				.HasMany(e => e.Contest_Category)
				.WithRequired(e => e.Contest)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Coupon>()
				.HasMany(e => e.Members_Coupons)
				.WithRequired(e => e.Coupon)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Employee>()
				.HasMany(e => e.ChatContents)
				.WithRequired(e => e.Employee)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Forum_S1MainTopicsBranch1Thread>()
				.HasMany(e => e.Forum_Reply)
				.WithRequired(e => e.Forum_S1MainTopicsBranch1Thread)
				.HasForeignKey(e => e.replyId)
				.WillCascadeOnDelete(false);

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

			modelBuilder.Entity<Information>()
				.Property(e => e.Phone)
				.IsFixedLength();

			modelBuilder.Entity<Information>()
				.HasMany(e => e.Registration_Information)
				.WithRequired(e => e.Information)
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
				.HasMany(e => e.AccountBalances)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.MemberId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.CartItems)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.Member_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.ChatContents)
				.WithOptional(e => e.Member)
				.HasForeignKey(e => e.MemberId);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Forum_Reply)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.Member_Id)
				.WillCascadeOnDelete(false);

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

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Members_Coupons)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.MemberId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Members_Subscriptions)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.MemberId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Orders)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.MemberId)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
				.HasMany(e => e.Registrations)
				.WithRequired(e => e.Member)
				.HasForeignKey(e => e.MemberID)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<OnSale>()
				.HasMany(e => e.Brands)
				.WithRequired(e => e.OnSale)
				.HasForeignKey(e => e.OnSale_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.CartItems)
				.WithRequired(e => e.Product)
				.HasForeignKey(e => e.Product_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Stocks)
				.WithRequired(e => e.Product)
				.HasForeignKey(e => e.Product_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ProductsImage>()
				.HasMany(e => e.Products)
				.WithRequired(e => e.ProductsImage)
				.HasForeignKey(e => e.ProductsImages_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ProductSize>()
				.HasMany(e => e.Stocks)
				.WithRequired(e => e.ProductSize)
				.HasForeignKey(e => e.ProductSize_Id)
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

			modelBuilder.Entity<Registration>()
				.HasMany(e => e.Registration_Information)
				.WithRequired(e => e.Registration)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Subscription>()
				.HasMany(e => e.Members_Subscriptions)
				.WithRequired(e => e.Subscription)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.SupplierTel)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.Contests)
				.WithRequired(e => e.Supplier)
				.WillCascadeOnDelete(false);
		}
	}
}
