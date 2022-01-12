using Bootcamp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bootcamp1
{
    public class BootcampDBContext : DbContext
    {

        public virtual DbSet<UserModel> User { get; set; }

        public BootcampDBContext(DbContextOptions<BootcampDBContext> options)
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
