using System;
using System.Collections.Generic;
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
        public MealTime TimeOfMeal { get; set; }
        public DateTime WhenEaten { get; set; }
        public float Carbs { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }

    }

    public enum MealTime { snack, breakfast, lunch, dinner }
}