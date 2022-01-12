using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp1.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
    public class UserModelBuilder : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> entity)
        {
           entity.HasKey(e => e.UserID);
        }
    }
}
