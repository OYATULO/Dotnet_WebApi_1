
using Microsoft.EntityFrameworkCore;
using Test_webAPI_USERS.Model;

namespace Test_webAPI_USERS.Context
{
	public class AppDBcontext:DbContext
	{
		public enum Gender
		{
			женщина,
			мужчина,
			неизвестно
		}
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			try
			{
				string connectionString = string.Format(@"Data Source=MSI; Initial Catalog=UserDB; User Id=MSI\OYATULLO; Password=; Encrypt=false; Trusted_Connection=True;");
				optionsBuilder.UseSqlServer(connectionString);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
		public DbSet<Users> UserDB { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var data = new Users {

				Guid = Guid.NewGuid(),
				Name = "user1",
				Login = "user1",
				Password="user1",
				Gender= ((int)Gender.мужчина),
				Birthday = new DateTime(2000,01,01),
				Admin= true,
				CreatedOn = DateTime.Now,
				CreatedBy = "admin",
				ModifiedBy = "admin",
				ModifiedOn = DateTime.Now,
				RevokedBy = "admin",
				RevokedOn = DateTime.Now
			};

			modelBuilder.Entity<Users>().HasData(data);
		}

	}
}
