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
        private string mealID;
        private string name;
        private string description;
        private int caloriesPerHundredG;

        public string MealID
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

        public CheatMeal(string mealID, string name, string description, int caloriesPerHundredG)
        {
            MealID = mealID;
            Name = name;
            Description = description;
            CaloriesPerHundredG = caloriesPerHundredG;
        }
    }
}
