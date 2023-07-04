using FitApp.Views;

namespace FitApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
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
}

