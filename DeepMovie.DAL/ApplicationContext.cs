using DeepMovie.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DonationStage> DonationStages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<FilmMember> FilmMember { get; set; }
        public DbSet<Content> Content { get; set;  }
        public DbSet<UserProfile> UserProfile { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmCategory>()
                .HasKey(bc => new { bc.FilmID, bc.CategoryID });
            modelBuilder.Entity<FilmCategory>()
                .HasOne(bc => bc.Film)
                .WithMany(b => b.FilmCategories)
                .HasForeignKey(bc => bc.FilmID);
            modelBuilder.Entity<FilmCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.FilmCategories)
                .HasForeignKey(bc => bc.CategoryID);

            modelBuilder.Entity<FilmMember>()
                .HasKey(x => new { x.FilmID, x.MemberID });
            modelBuilder.Entity<FilmMember>()
                .HasOne(x => x.Film)
                .WithMany(x => x.FilmMembers)
                .HasForeignKey(x => x.FilmID);
            modelBuilder.Entity<FilmMember>()
              .HasOne(x => x.Member)
              .WithMany(x => x.FilmMembers)
              .HasForeignKey(x => x.MemberID);


        }
    }
}
