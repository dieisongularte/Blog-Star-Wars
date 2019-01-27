using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogStarWars.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogStarWars.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}