using Bootcamp1.Entities;
using Bootcamp1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Services
{
    public class FoodService
    {

        private BootcampDotNetDBContext dbContext;

        public FoodService(BootcampDotNetDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<FoodModel>> GetAllFood()
        {


            var foods = await dbContext.Food.Include(e => e.Chef)
                .Select(e => new FoodModel()
                {
                    FoodName = e.FoodName,
                    FoodID = e.FoodID,
                    Price = e.Price,
                    ChefName = e.Chef.ChefName
                }).ToListAsync();



            return foods;

        }


    }
}
