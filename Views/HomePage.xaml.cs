using FitApp.Repositories;
using FitApp.Models;

namespace FitApp.Views;

public partial class HomePage : ContentPage
{
   
    public HomePage()
    {
        InitializeComponent();
        User user = UserRepository.GetUser();
        lblName.Text = user.Name;
    }

    private void btnAddWorkout_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddWorkoutPage));
    }

    private void btnAddCheatMeal_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddCheatMeal));
    }

    private void btnToReport_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ReportPage));
    }

    private void btnToPredicates_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(PredictionPage));
    }
}
