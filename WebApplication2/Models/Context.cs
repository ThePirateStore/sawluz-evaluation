using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class Context : DbContext
    {
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prato>()
                .HasRequired(p => p.Rest)
                .WithMany(r => r.Pratos)
                .HasForeignKey(p => p.RestID);

            base.OnModelCreating(modelBuilder);
        }
    }
}