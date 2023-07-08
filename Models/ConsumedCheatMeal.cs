using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.Models
{ 
    public class ConsumedCheatMeal : CheatMeal
    {
        public DateTime Date { get; set; }
        public int ConsumedAmount { get; set; }

        public double CurrentWeightOfUser { get; set; }

        public ConsumedCheatMeal(int mealID, DateTime date, string name, 
            string description, int caloriesPerHundredG, int consumedAmount, double currentWeightOfUser) :
            base(mealID, name, description, caloriesPerHundredG)
        {
            this.Date = date;
            this.ConsumedAmount = consumedAmount;
            this.CurrentWeightOfUser = currentWeightOfUser;
        }
    }
}
