using Bootcamp1.Entities;
using Bootcamp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bootcamp1
{
    public class BootcampDotNetDBContext : DbContext
    {
        public virtual DbSet<UserModel> User { get; set; }


        public virtual DbSet<FoodEntity> FoodEntity { get; set; }


        public BootcampDotNetDBContext(DbContextOptions<BootcampDotNetDBContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ini buat nge-scan Assembly 
            // untuk apply konfigurasi IEntityTypeConfiguration<T>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
