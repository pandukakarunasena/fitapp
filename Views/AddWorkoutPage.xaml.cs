namespace FitApp.Views;

using FitApp.Models;
using FitApp.Repositories;
using FitApp.Views.Modals;
using System.Collections.ObjectModel;

public partial class AddWorkoutPage : ContentPage
{
    ObservableCollection<Workout> Workouts;
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

        // Subscribe to the message sent from the workout details modal
        
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        // Unsubscribe from the message to avoid memory leaks
        // if we unsubcribe in here the message wont come.
        // 
    }

    private void OnWorkoutDetailReceived(WorkoutDetailsModalPage sender, WorkoutDetail workoutDetail)
    {
        // Handle the received workout details (amount completed and intensity)
        string amountCompleted = workoutDetail.AmountCompleted;
        string intensity = workoutDetail.Intensity;

        if (amountCompleted != null && intensity != null)
        {
            Workout completedWorkout = new Workout(
                selectedWorkout.WorkoutID,
                selectedWorkout.Name,
                selectedWorkout.Type,
                selectedWorkout.Description,
                selectedWorkout.CaloriesBurntPer,
                amountCompleted
            );

            user.Workouts.Add(completedWorkout);
        }

        MessagingCenter.Unsubscribe<WorkoutDetailsModalPage, WorkoutDetail>(this, "WorkoutDetail");
        // Use the workout details as needed
        // For example, update the selected workout with the captured data
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
            MessagingCenter.Subscribe<WorkoutDetailsModalPage, WorkoutDetail>(this, "WorkoutDetail", OnWorkoutDetailReceived);
            selectedWorkout = workout;
            var workoutDetailsModalPage = new WorkoutDetailsModalPage();
            // Set the current page as the binding context to access its properties
            // workoutDetailsModalPage.BindingContext = this; 
            
            await Application.Current.MainPage.Navigation.PushModalAsync(workoutDetailsModalPage);
        }
    }
}
