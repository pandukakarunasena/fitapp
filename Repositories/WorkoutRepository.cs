using FitApp.Models;

namespace FitApp.Repositories
{
    internal class WorkoutRepository
    {
        private static List<Workout> workouts = new List<Workout>() {,
            new Workout(1, "Jogging", Workout.WorkoutType.Running, "Simple Jogging"),
            new Workout(2, "Marathon", Workout.WorkoutType.Running, "Simple Marathon"),
            new Workout(3, "Cycling", Workout.WorkoutType.Cycling, "Simple Cycling"),
            new Workout(4, "Swimming", Workout.WorkoutType.Swimming, "Simple Swim"),
        };

        public static Workout GetWorkoutByID(int id)
        {
            Workout workout = null;
            if (id >= 1)
            {
                workout = workouts[id];
            }
            return workout;
        }
        public static List<Workout> GetAllWorkouts() => workouts;

        public static void AddWorkout(Workout workout)
        {
            if (workout == null) return;
            workouts.Add(workout);
        }

        // Future improvements: add, delete, upadte new workouts
        public static Workout UpdateWorkout(Workout workout)
        {
            if (workout == null) return null;

            Workout workoutToUpdate = workouts.Find(meal => workout.WorkoutID == meal.WorkoutID);

            workoutToUpdate.WorkoutID = workout.WorkoutID;
            workoutToUpdate.Name = workout.Name;
            workoutToUpdate.Description = workout.Description;
            workoutToUpdate.Type = workout.Type;

            return workoutToUpdate;

        }
        public static void DeleteWorkout(Workout workout)
        {
            if (workout != null)
            {
                workouts.Remove(workout);
            }          
        }
    }
}
