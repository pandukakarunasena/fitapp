using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.Models
{

    public class Workout
    {
        public enum WorkoutType
        {
            Running,
            Weightlifting,
            Cycling,
            Swimming,
            // Add more workout types as needed
        }

        private int workoutID;
        private string name;
        private WorkoutType type;
        private string description;
        private int caloriesBurntPer;
        private int amountCompleted;

        public int WorkoutID
        {
            get { return workoutID; }
            set { workoutID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public WorkoutType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int CaloriesBurntPer
        {
            get { return caloriesBurntPer; }
            set { caloriesBurntPer = value; }
        }

        public int AmountCompleted
        {
            get { return amountCompleted; }
            set { amountCompleted = value; }
        }

        public Workout(int workoutID, string name, WorkoutType type, string description, int caloriesBurntPer, int amountCompleted)
        {
            WorkoutID = workoutID;
            Name = name;
            Type = type;
            Description = description;
            CaloriesBurntPer = caloriesBurntPer;
            AmountCompleted = amountCompleted;
        }
    }
}
