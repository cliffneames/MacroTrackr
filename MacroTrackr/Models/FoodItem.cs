using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MacroTrackr.Models
{
    public class FoodItem
    {
        public int FoodItemID { get; set; }
        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
        public string Name { get; set; }
        [DisplayName("Meal")]
        public MealTime TimeOfMeal { get; set; }
        [DisplayName("Time")]
        public DateTime WhenEaten { get; set; }
        public float Carbs { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }

    }

    public enum MealTime { snack, breakfast, lunch, dinner }
}