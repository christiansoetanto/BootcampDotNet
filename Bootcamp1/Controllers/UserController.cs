using Bootcamp1.Models;
using Bootcamp1.Services;
using Bootcamp1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp1.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            List<UserModel> users = userService.GetUsers();

            UserViewModel uvm = new UserViewModel()
            {
                Users = users
            };

            return View(uvm);
        }

       
    }
}
