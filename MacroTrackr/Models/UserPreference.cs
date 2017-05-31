using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MacroTrackr.Models
{
    public class UserPreference
    {
        public int UserPreferenceID { get; set; }
        public ApplicationUser User { get; set; }
        public string UserID { get; set; }
        public int MacroNutrientID { get; set; }
        public MacroNutrient Macro { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}