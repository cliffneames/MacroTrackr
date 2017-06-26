using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MacroTrackr.Models
{
    public class UserPrefFoodItemViewModel
    { 
         public IEnumerable<UserPreference> userPreference { get; set; }
         public IEnumerable<FoodItem> foodItem{ get; set; }
    }
}