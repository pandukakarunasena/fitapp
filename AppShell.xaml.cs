using FitApp.Views;

namespace FitApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(AddCheatMeal), typeof(AddCheatMeal));
        Routing.RegisterRoute(nameof(AddWorkoutPage), typeof(AddWorkoutPage));
        Routing.RegisterRoute(nameof(AddUserPage), typeof(AddUserPage));
        Routing.RegisterRoute(nameof(UserProfilePage), typeof(UserProfilePage));
        Routing.RegisterRoute(nameof(ReportPage), typeof(ReportPage));
        Routing.RegisterRoute(nameof(PredictionPage), typeof(PredictionPage));
    }
}
