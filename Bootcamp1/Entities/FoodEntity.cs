
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bootcamp1.Entities
{
    public class FoodEntity
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public float Price { get; set; }

    }

    public class FoodEntityModelBuilder : IEntityTypeConfiguration<FoodEntity>
    {
        public void Configure(EntityTypeBuilder<FoodEntity> entity)
        {
            entity.HasKey(e => e.FoodID);
        }
    }

    //template model builder
    //public class [EntityName]ModelBuilder : IEntityTypeConfiguration<[EntityName]>
    //{
    //    public void Configure(EntityTypeBuilder<[EntityName]> entity)
    //    {
    //        entity.HasKey(e => e.[PropertyName}]);
    //    }
    //}



}
