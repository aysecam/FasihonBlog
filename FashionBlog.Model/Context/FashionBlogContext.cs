using FashionBlog.Core.Entity;
using FashionBlog.Model.Entities;
using FashionBlog.Model.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FashionBlog.Model.Context
{
    public class FashionBlogContext : DbContext
    {
        public FashionBlogContext(DbContextOptions<FashionBlogContext> options) : base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new PostInfoMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostInfo> PostInfos { get; set; }

        public override int SaveChanges()
        {
            var ChangedEntites = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted ||
            x.State == EntityState.Modified).ToList();

            string computerName = Environment.MachineName;
            string localhost = "127.0.0.1";
            DateTime date = DateTime.Now;

            foreach (var item in ChangedEntites)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            entity.ModifiedComputerName = computerName;
                            entity.ModifiedDate = date;
                            entity.ModifiedIP = localhost;
                            break;
                        case EntityState.Added:
                            entity.CreatedComputerName = computerName;
                            entity.CreatedDate = date;
                            entity.CreatedIP = localhost;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
