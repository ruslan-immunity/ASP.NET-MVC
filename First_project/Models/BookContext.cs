using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace First_project.Models
{
    public class BookContext : DbContext
    {
        public BookContext(): base() 
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // использование Fluent API
            modelBuilder.Entity<Book>().ToTable("List book");
            //modelBuilder.Ignore<Book>();
            modelBuilder.Entity<Book>().HasKey(book => book.Id);
            /*modelBuilder.Entity<Book>().Property(book => book.Name).HasColumnName("BookName");
            modelBuilder.Entity<Book>().Ignore(book => book.Name);*/
            modelBuilder.Entity<Book>().Property(book => book.Name).IsRequired();
            modelBuilder.Entity<Book>().Property(book => book.Author).IsRequired();
            modelBuilder.Entity<Book>().Property(book => book.Price).IsRequired();
            modelBuilder.Entity<Book>().Property(book => book.Name).HasMaxLength(30);
            modelBuilder.Entity<Book>().Property(book => book.Author).HasMaxLength(20);
            base.OnModelCreating(modelBuilder);
        }
    }
}