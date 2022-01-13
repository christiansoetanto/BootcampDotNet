using Bootcamp1.Models;
using Bootcamp1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Controllers
{
    public class FoodController : Controller
    {

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


        public IActionResult Index()
        {

            


            FoodViewModel FoodVM = new FoodViewModel();

            FoodVM.FoodList = FoodList;


            return View("Menu", FoodVM);
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
    }
}
