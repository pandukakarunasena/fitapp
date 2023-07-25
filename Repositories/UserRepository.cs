using FitApp.Views;
using FitApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.Repositories
{
    public static class UserRepository 
    {

        private static User user;

        public static User AddUser(User userToAdd)
        {
            if (user == null)
            {
                user = new User(1, userToAdd.Name, userToAdd.Height, userToAdd.Weight);
            } 

            return user;
        }

        public static User GetUser()
        {
            return user;
        }
        public static void UpdateUser(User userToUpdate)
        {
            user = new User(1, userToUpdate.Name, userToUpdate.Height, userToUpdate.Weight);
        }
        public static void AddWorkout(CompletedWorkout workout)
        {
            user.CompletedWorkouts.Add(workout);
        }

        public static void RemoveWorkout(CompletedWorkout workout)
        {
            user.CompletedWorkouts.Remove(workout);
        }
        public static void AddCheatMeal(ConsumedCheatMeal cheatMeal)
        {
            user.CheatMeals.Add(cheatMeal);
        }

        public static void RemoveCheatMeal(ConsumedCheatMeal cheatMeal)
        {
            ConsumedCheatMeal cheatMealToDelete = user.CheatMeals.FirstOrDefault(c => c.MealID == cheatMeal.MealID);
            if (cheatMealToDelete != null)
            {
                user.CheatMeals.Remove(cheatMealToDelete);
            } 
        }

        public static void UpdateCheatMeal(ConsumedCheatMeal updatedCheatMeal)
        {
            ConsumedCheatMeal cheatMealToUpdate = user.CheatMeals.FirstOrDefault(c => c.MealID == updatedCheatMeal.MealID);
            if (cheatMealToUpdate != null)
            {
                cheatMealToUpdate.Name = updatedCheatMeal.Name;
                cheatMealToUpdate.Description = updatedCheatMeal.Description;
                cheatMealToUpdate.CaloriesPerHundredG = updatedCheatMeal.CaloriesPerHundredG;
                cheatMealToUpdate.ConsumedAmount = updatedCheatMeal.ConsumedAmount;
                cheatMealToUpdate.CurrentWeightOfUser = updatedCheatMeal.CurrentWeightOfUser;
            }
        }

        public static void UpdateWorkout(CompletedWorkout updatedWorkout)
        {
            CompletedWorkout workoutToUpdate = user.CompletedWorkouts.FirstOrDefault(w => w.WorkoutID == updatedWorkout.WorkoutID);
            if (workoutToUpdate != null)
            {
                workoutToUpdate.Name = updatedWorkout.Name;
                workoutToUpdate.Type = updatedWorkout.Type;
                workoutToUpdate.Description = updatedWorkout.Description;
                workoutToUpdate.WeightAfterWorkout = updatedWorkout.WeightAfterWorkout;
                workoutToUpdate.CompletedAmount = updatedWorkout.CompletedAmount;
            }
        }

      
    }
}
