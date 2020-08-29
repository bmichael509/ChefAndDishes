using System;
using System.Collections.Generic;

namespace ChefNDishes.Models
{
    public class DishWrapper
    {
        public Dish DishForm { get; set; }
        public List<Chef> ChefDropdown { get; set; }
    }
}