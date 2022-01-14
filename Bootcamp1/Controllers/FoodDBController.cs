using Bootcamp1.Models;
using Bootcamp1.Services;
using Bootcamp1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Controllers
{
    public class FoodDBController : Controller
    {
        //dependency injection
        private readonly FoodService foodService;
        public FoodDBController (FoodService foodService)
        {
            this.foodService = foodService;
        }

        public static List<FoodModel> FoodList = new List<FoodModel>()
        {
            new FoodModel()
            {
                FoodID = 1,
                FoodName = "Burger",
                Price = 12.89f
            },
            new FoodModel()
            {
                FoodID = 2,
                FoodName = "Pizza",
                Price = 8.23f
            },
            new FoodModel()
            {
                FoodID = 3,
                FoodName = "French Fries",
                Price = 23.54f
            }
        };


        public async Task<IActionResult> Index()
        {
            FoodDBViewModel FoodDBVM = new FoodDBViewModel();
            List<FoodModel> foods = await foodService.GetAllFood();
            FoodDBVM.FoodList = foods;
            return View("Menu", FoodDBVM);
        }

        public IActionResult Create(FoodViewModel ModelSubmit)
        {

            // linQ
            int NewID = FoodList.Max(e => e.FoodID) + 1;

            ModelSubmit.Food.FoodID = NewID;

            FoodList.Add(ModelSubmit.Food);


            return RedirectToAction("Index");


        }


        public IActionResult CreateFromAjax(FoodViewModel ModelSubmit)
        {

            // linQ
            int NewID = FoodList.Max(e => e.FoodID) + 1;

            ModelSubmit.Food.FoodID = NewID;

            FoodList.Add(ModelSubmit.Food);

            //annonymous object
            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Create From Ajax"
            });

            return Ret;
        }

        public async Task<IActionResult> GetAllFood()
        {
            FoodDBViewModel FoodDBVM = new FoodDBViewModel();
            var foods = await foodService.GetAllFood();
            FoodDBVM.FoodList = foods;
            return View("_FoodList", FoodDBVM);
        }

     

        public IActionResult DeleteFood(int foodId)
        {
            //remove item dari FoodList yang memiliki FoodID == foodId

            for(int i = 0; i < FoodList.Count; i++)
            {
                if(FoodList[i].FoodID == foodId)
                {
                    //cara 1: remove index
                    FoodList.RemoveAt(i);

                    //cara 2: remove object
                    //FoodList.Remove(FoodList[i]);
                    break;
                }
            }


            //cara 3
            //LINQ
            //FoodList.RemoveAll(e => e.FoodID == foodId);
            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Delete"
            });
            return Ret;

        }



        public IActionResult UpdateFood(FoodViewModel ModelSubmit)
        {
            for (int i = 0; i < FoodList.Count; i++)
            {
                if (FoodList[i].FoodID == ModelSubmit.Food.FoodID)
                {
                    FoodList[i] = ModelSubmit.Food;
                    break;
                    //FoodList[i].FoodName = ModelSubmit.Food.FoodName;
                    //FoodList[i].Price = ModelSubmit.Food.Price;
                }
            }

            JsonResult Ret = Json(new
            {
                Status = true,
                Message = "Berhasil Update"
            });
            return Ret;

        }


    }
}
