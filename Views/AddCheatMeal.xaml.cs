using FitApp.Repositories;
using FitApp.Models;
using System.Collections.ObjectModel;

namespace FitApp.Views;

public partial class AddCheatMeal : ContentPage
{

    ObservableCollection<CheatMeal> CheatMeals;
    public AddCheatMeal()
	{
		InitializeComponent();
        CheatMeals = new ObservableCollection<CheatMeal>(CheatMealRepository.GetAllCheatMeals());
        CheatMealListView.ItemsSource = CheatMeals;
    }

    private void OnCheatMealSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Deselect the item
        ((ListView)sender).SelectedItem = null;
    }
    private void btnSelectCheatMeal_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var cheatMeal = button.BindingContext as CheatMeal;
        if (cheatMeal != null)
        {
            // Perform actions for the selected workout
            DisplayAlert("Clicked", $"Cheat Meal '{cheatMeal.Name}' clicked!", "CLOSE");
        }
    }
}
