﻿using System;
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
            new CheatMeal("7dbd71f4-1d8d-49f1-b0dd-7d0a7e38e69c", "Pizza", "Super Pizza", 50),
            new CheatMeal("9f63ed4a-0bc7-4a3d-8a15-8c4dfe503ed9", "Bread", "Super Bread", 30),
            new CheatMeal("3aeb3771-4466-4b6f-99e7-69b086974b6c", "Coca cola", "Super Cola", 100),
            new CheatMeal("8e72e94c-11f7-45e4-96e6-2d6a987e8e0f", "Fanta", "Super Fant", 100),
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
