using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UOB.Repository.EF.Entities;

namespace UOB.Repository.EF.Context
{
    public class LibraryContext :DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
         : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<MemberRecord> MemberRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed popular novels 📚
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = Guid.Parse("c493d6b4-41f0-4e5c-bc88-687c6927b3ce"), Title = "Harry Potter and the Philosopher's Stone", Author = "J.K. Rowling", IsAvailable = true },
                new Book { Id = Guid.Parse("a129c1ff-2b7a-46e7-bcf3-18e2ab774f6f"), Title = "The 3 Mistakes of My Life", Author = "Chetan Bhagat", IsAvailable = true },
                new Book { Id = Guid.Parse("e9a8ce3b-9c2b-4dcb-a8ce-1b4fc3b02e5b"), Title = "Half Girlfriend", Author = "Chetan Bhagat", IsAvailable = true },
                new Book { Id = Guid.Parse("8c61ed09-34ce-47ef-9635-2c1b54e098c2"), Title = "The Alchemist", Author = "Paulo Coelho", IsAvailable = true },
                new Book { Id = Guid.Parse("9d4a5683-cf70-4122-9e8c-64b4a5b22867"), Title = "The Fault in Our Stars", Author = "John Green", IsAvailable = false }
            );

            // Seed one default member 👤
            modelBuilder.Entity<Members>().HasData(
                new Members { Id = Guid.Parse("4f45b7b6-8c59-4b9a-bf55-88b9c1f08fa3"), Name = "UOB Domain", Email = "domain@privacy.com",IsActive = true}
            );
        }
    }
}
