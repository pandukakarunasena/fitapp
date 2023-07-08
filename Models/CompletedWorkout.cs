using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.Models
{
    public class CompletedWorkout : Workout
    {

        public DateTime Date { get; set; }
        public float WeightAfterWorkout { get; set; }
        public string CompletedAmount { get; set; }

        public CompletedWorkout( int workoutID, DateTime date, string name, WorkoutType type, 
            string description, float weightAfterWorkout, string completedAmount) : base(workoutID, name, type, description)
        {
            this.Date = date;
            this.CompletedAmount = completedAmount;
            this.WeightAfterWorkout = weightAfterWorkout;
        }
    }
}
