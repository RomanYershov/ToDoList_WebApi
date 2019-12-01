using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDoList.DAL.Entities;

namespace ToDoList.DAL.EF
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options) { }
        public DbSet<Entities.ToDoList> ToDoLists { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(u => u.ToDoLists)
                .WithOne();

            builder.Entity<Entities.ToDoList>()
                .HasMany(t => t.Tags)
                .WithOne();

            builder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique();
        }
    }
}
