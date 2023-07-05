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
        private double height;
        private double weight;
        private List<Workout> workouts = new List<Workout>();
        private List<CheatMeal> cheatMeals = new List<CheatMeal>();

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

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public List<Workout> Workouts { get => workouts; set => workouts = value; }
        public List<CheatMeal> CheatMeals { get => cheatMeals; set => cheatMeals = value; }

        public User(int userId, string name, double height, double weight)
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
