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
            new CheatMeal(1, "Pizza", "Super Pizza", 50, 0),
            new CheatMeal(2, "Bread", "Super Bread", 30, 0),
            new CheatMeal(3, "Coca cola", "Super Cola", 100, 0),
            new CheatMeal(4, "Fanta", "Super Fant", 100, 0),
        };

        public static List<CheatMeal> GetAllCheatMeals() { return cheatMeals; }

        // Future Improvements, Add, Update, Delete Cheat meals.
    }
}
