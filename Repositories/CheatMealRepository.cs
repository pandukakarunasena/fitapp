using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FitApp.Models;

namespace FitApp.Repositories
{
    internal class CheatMealRepository
    {
        private static List<CheatMeal> cheatMeals = new List<CheatMeal>()
        {
            new CheatMeal(1, "Pizza", "Super Pizza", 50),
            new CheatMeal(2, "Bread", "Super Bread", 30),
            new CheatMeal(3, "Coca cola", "Super Cola", 100),
            new CheatMeal(4, "Fanta", "Super Fant", 100),
        };

        public static CheatMeal GetCheatMealByID(int id)
        {
            CheatMeal cheatMeal = null;
            if (id >= 1)
            {
                cheatMeal = cheatMeals[id];
            }
            return cheatMeal;
        }

        public static List<CheatMeal> GetAllCheatMeals() { return cheatMeals; }

        public static void AddWorkout(CheatMeal cheatMeal)
        {
            if (cheatMeal == null) return;
            cheatMeals.Add(cheatMeal);
        }
        public static CheatMeal UpdateCheatMeal(CheatMeal cheatMeal)
        {
            if (cheatMeal == null) return null;

            CheatMeal cheatMealToUpdate = cheatMeals.Find(meal => cheatMeal.MealID == meal.MealID);

            cheatMealToUpdate.MealID = cheatMeal.MealID;
            cheatMealToUpdate.Name = cheatMeal.Name;
            cheatMealToUpdate.Description = cheatMeal.Description;
            cheatMealToUpdate.CaloriesPerHundredG = cheatMeal.CaloriesPerHundredG;

            return cheatMealToUpdate;

        }
        public static void DeleteCheatMeal(CheatMeal cheatMeal)
        {
            if (cheatMeal != null)
            {
                cheatMeals.Remove(cheatMeal);
            }
        }
        
    }
}
