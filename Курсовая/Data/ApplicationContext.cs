using Microsoft.EntityFrameworkCore;
using Курсовая.Models.UsingModel;

namespace Курсовая.Data
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Salary> Salarys { get; set; }
		public DbSet<AcademicDegree> AcademicDegrees { get; set; }
		public DbSet<AdditionalPayment> AdditionalPayments { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<General> Generals { get; set; }
		public DbSet<Classes> Classes { get; set; }
		public ApplicationContext()
		{
			Database.EnsureCreated();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=kurs;Username=postgres;Password=1234");
			//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Salary>().ToTable("Salary");
			modelBuilder.Entity<AcademicDegree>().ToTable("AcademicDegree");
			modelBuilder.Entity<AdditionalPayment>().ToTable("AdditionalPayment");
			modelBuilder.Entity<Category>().ToTable("Category");
			modelBuilder.Entity<General>().ToTable("General");
			modelBuilder.Entity<Classes>().ToTable("Classes");
		}
	}
}
