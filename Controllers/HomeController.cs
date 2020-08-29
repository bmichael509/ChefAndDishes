using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ChefNDishes.Models;

namespace ChefNDishes.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        //for each route this controller is to handle:
        [HttpGet("/dishes/new")]     //Http Method and the route
        public IActionResult NewDish() //When in doubt, use IActionResult
        {
            DishWrapper WMod = new DishWrapper();
            WMod.ChefDropdown = _context.Chefs.ToList();
            return View("NewDish", WMod); //or whatever you want to return
        }

        [HttpPost("/dishes/create")]
        public IActionResult CreateDish(DishWrapper Form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Form.DishForm);
                _context.SaveChanges();
                return RedirectToAction("AllDishes");
            }
            return RedirectToAction("NewDish");
        }

        [HttpGet("/dishes")]
        public IActionResult AllDishes()
        {
            List<Dish> Menu = _context.Dishes.Include(d => d.Chef).ToList();
            return View("AllDishes", Menu);
        }

        [HttpGet("/")]
        public IActionResult Chefs()
        {
            List<Chef> Kitchen = _context.Chefs  
                .Include(d => d.Dishes).ToList();
            return View("AllChefs", Kitchen);
        }

        [HttpGet("/chefs/new")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }

        [HttpPost("/chefs/create")]
        public IActionResult CreateChef(Chef FNG)
        {
            if (ModelState.IsValid)
{
                if(FNG.Age > DateTime.Today)
                {
                    ModelState.AddModelError("Age", "Birthday cannot be in the future.");
                    return RedirectToAction("NewChef");
                }
                _context.Add(FNG);
                _context.SaveChanges();
                return RedirectToAction("Chefs");
            }
            return RedirectToAction("NewChef");
        }
    }
}