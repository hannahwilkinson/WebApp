using System;
using _450MIST.Models;
using Microsoft.EntityFrameworkCore;

namespace _450MIST.Data
{
	public class BooksDBContext : DbContext
	{
		public BooksDBContext(DbContextOptions<BooksDBContext> options) : base(options)
		{

		}

		//add a table to the database where every row is a book
		public DbSet<Book> books { get; set; }

		//put in seed data (mock data)
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//HasData method - add data to our entity "books"
			modelBuilder.Entity<Book>().HasData(

				//BookID needs to be unique
				new Book
				{
					BookID = 1,
					Title = "C# for Beginners",
					Description = "This has no description",
					Author = "Salman Nazir",
					Genre = "Coding",
					Price = 19.99m,
					DatePublished = new DateTime(2023, 10, 20)
				},

				new Book
				{
					BookID = 2,
					Title = "Advanced C#",
					Description = "This has no description",
					Author = "Adman Freeman",
					Genre = "Coding",
					Price = 59.99m,
					DatePublished = new DateTime(2022, 10, 20)
				},

				new Book
				{
					BookID = 3,
					Title = "HTML for Beginners",
					Description = "This has no description",
					Author = "Morgan Freeman",
					Genre = "Coding",
					Price = 15.99m,
					DatePublished = new DateTime(2020, 10, 20)
				});
		}
	}
}