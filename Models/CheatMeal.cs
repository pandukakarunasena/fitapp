using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FitApp.Models
{
    class CheatMeal
    {
        int cheatMealId;
        string name;
        string description;
        string caloriesPerHundredG;
        int consumedAmount;

        public CheatMeal(int cheatMealId, string name, string description, string caloriesPerHundredG)
        {
            this.cheatMealId = cheatMealId;
            this.name = name;
            this.description = description;
            this.caloriesPerHundredG = caloriesPerHundredG;
        }

        public CheatMeal(
            int cheatMealId, 
            string name,
            string description, 
            string caloriesPerHundredG,
            int consumedAmount)
        {
            this.cheatMealId = cheatMealId;
            this.name = name;
            this.description = description;
            this.caloriesPerHundredG = caloriesPerHundredG;
            this.consumedAmount = consumedAmount;
        }
    }
}
