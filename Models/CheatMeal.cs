using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FitApp.Models
{
    public class CheatMeal
    {
        private int mealID;
        private string name;
        private string description;
        private int caloriesPerHundredG;
        private int consumedAmount;

        public int MealID
        {
            get { return mealID; }
            set { mealID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int CaloriesPerHundredG
        {
            get { return caloriesPerHundredG; }
            set { caloriesPerHundredG = value; }
        }

        public int ConsumedAmount
        {
            get { return consumedAmount; }
            set { consumedAmount = value; }
        }

        public CheatMeal(int mealID, string name, string description, int caloriesPerHundredG, int consumedAmount)
        {
            MealID = mealID;
            Name = name;
            Description = description;
            CaloriesPerHundredG = caloriesPerHundredG;
            ConsumedAmount = consumedAmount;
        }
    }
}
