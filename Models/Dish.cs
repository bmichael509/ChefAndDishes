using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefNDishes.Models
{
    public class Dish
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int DishId { get; set; }

        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Name of Dish")]
        public string Name { get; set; }
        [Required(ErrorMessage = "is required")]
        [Range(1, 6)]
        [Display(Name = "Tastiness")]
        public int Tastiness { get; set; }
        [Required(ErrorMessage = "is required")]
        [Range(1, 99999999999999)]
        [Display(Name = "# of Calories")]
        public int Calories { get; set; }
        public string Description {get;set;}
        public int ChefId {get; set;}
        public Chef Chef {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}