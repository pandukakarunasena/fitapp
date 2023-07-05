using FitApp.Models;

namespace FitApp.Repositories
{
    internal class WorkoutRepository
    {
        private static List<Workout> workouts = new List<Workout>() {
            new Workout(1, "Jogging", Workout.WorkoutType.Running, "Simple Jogging", 100, null),
            new Workout(2, "Marathon", Workout.WorkoutType.Running, "Simple Marathon", 150, null),
            new Workout(1, "Cycling", Workout.WorkoutType.Cycling, "Simple Cycling", 300, null),
            new Workout(1, "Swimming", Workout.WorkoutType.Swimming, "Simple Swim", 400, null),
        };

        public static List<Workout> GetAllWorkouts() => workouts;

        public static void AddWorkout(Workout workout)
        {
            workouts.Add(workout);
        }

        // Future improvements: add, delete, upadte new workouts
    }
}
