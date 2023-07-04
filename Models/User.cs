using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.Models
{
    public class User
    {
        private int userId;
        private string name;
        private int height;
        private int weight;
        private List<Workout> workouts;
        private List<CheatMeal> cheatMeals;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public List<Workout> Workouts { get => workouts; set => workouts = value; }
        public List<CheatMeal> CheatMeals { get => cheatMeals; set => cheatMeals = value; }

        public User(int userId, string name, int height, int weight)
        {
            UserId = userId;
            Name = name;
            Height = height;
            Weight = weight;
        }

        public User()
        {
        }
    }
}
