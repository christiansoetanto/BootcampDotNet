using Bootcamp1.Models;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp1
{
    public class BootcampDBContext : DbContext
    {

        public virtual DbSet<UserModel> User { get; set; }

        public BootcampDBContext(DbContextOptions<BootcampDBContext> options)
         : base(options)
        {
        }
    }
}
