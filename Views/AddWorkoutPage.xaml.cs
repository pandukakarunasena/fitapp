using FitApp.Models;
using FitApp.Repositories;
using FitApp.Views.Modals;
using System.Collections.ObjectModel;

namespace FitApp.Views;

public partial class AddWorkoutPage : ContentPage
{
    ObservableCollection<Workout> Workouts;
    ObservableCollection<CompletedWorkout> CompletedWorkouts;
    Workout selectedWorkout;
    User user;
	public AddWorkoutPage()
	{
		InitializeComponent();
        Workouts = new ObservableCollection<Workout>(WorkoutRepository.GetAllWorkouts());
        WorkoutListView.ItemsSource = Workouts;

        user = UserRepository.GetUser();

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        loadContent();
    }

    private void loadContent()
    {
        CompletedWorkouts = new ObservableCollection<CompletedWorkout>(user.CompletedWorkouts);
        WorkoutHistoryListView.ItemsSource = CompletedWorkouts;
    }
    private void OnWorkoutSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Deselect the item
        ((ListView)sender).SelectedItem = null;
    }

    private async void btnSelectWorkout_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var workout = button.BindingContext as Workout;
        if (workout != null)
        {
            selectedWorkout = workout;
            MessagingCenter.Subscribe<WorkoutDetailsModalPage, WorkoutDetail>(this, "WorkoutDetail", OnWorkoutDetailReceived);
            var workoutDetailsModalPage = new WorkoutDetailsModalPage();
            // Set the current page as the binding context to access its properties
            workoutDetailsModalPage.BindingContext = this; 

            await Application.Current.MainPage.Navigation.PushModalAsync(workoutDetailsModalPage);
        }
    }

    private void OnWorkoutDetailReceived(WorkoutDetailsModalPage sender, WorkoutDetail workoutDetail)
    {
        // Handle the received workout details (amount completed and intensity)
        float weightAfterWorkout = workoutDetail.Weight;
        string completedAmount = workoutDetail.AmountCompleted;

        if (completedAmount != null)
        {
            CompletedWorkout completedWorkout = new CompletedWorkout (
                selectedWorkout.WorkoutID,
                DateTime.Now,
                selectedWorkout.Name,
                selectedWorkout.Type,
                selectedWorkout.Description,
                weightAfterWorkout,
                completedAmount
            );

            user.CompletedWorkouts.Add(completedWorkout);
            user.Weight = weightAfterWorkout;
        }

        MessagingCenter.Unsubscribe<WorkoutDetailsModalPage, WorkoutDetail>(this, "WorkoutDetail");
    }
}
