using FitApp.Repositories;
using FitApp.Models;
using System.Collections.ObjectModel;
using FitApp.Views.Modals;

namespace FitApp.Views;

public partial class AddCheatMeal : ContentPage
{
    ObservableCollection<CheatMeal> CheatMeals;
    ObservableCollection<ConsumedCheatMeal> ConsumedCheatMeals;
    CheatMeal selectedCheatMeal;
    User user;

    public AddCheatMeal()
	{
		InitializeComponent();
        CheatMeals = new ObservableCollection<CheatMeal>(CheatMealRepository.GetAllCheatMeals());
        CheatMealListView.ItemsSource = CheatMeals;

        user = UserRepository.GetUser();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        loadContent();
    }

    private void loadContent()
    {
        ConsumedCheatMeals = new ObservableCollection<ConsumedCheatMeal>(user.CheatMeals);
        CheatMealHistoryListView.ItemsSource = ConsumedCheatMeals;
        CheatMealListView.ItemsSource = CheatMeals;
    }
    private void OnCheatMealSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // Deselect the item
        ((ListView)sender).SelectedItem = null;
    }
    private async void btnSelectCheatMeal_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var cheatMeal = button.BindingContext as CheatMeal;
        if (cheatMeal != null)
        {
            selectedCheatMeal = cheatMeal;
            MessagingCenter.Subscribe<CheatMealDetailsModal, string>(this, "CheatMealDetail", OnCheatMealDetailReceived);
            // Perform actions for the selected cheat meal
            var cheatMealDetailsModalPage = new CheatMealDetailsModal();
            // Set the current page as the binding context to access its properties
            cheatMealDetailsModalPage.BindingContext = this; 

            await Application.Current.MainPage.Navigation.PushModalAsync(cheatMealDetailsModalPage);
        }
    }

    private void OnCheatMealDetailReceived(CheatMealDetailsModal sender, string consumedAmount)
    {
        // Handle the received cheat meal details (amount completed and intensity)
        if (consumedAmount != null )
        {
            ConsumedCheatMeal consumedCheatMeal = new ConsumedCheatMeal(
                selectedCheatMeal.MealID,
                DateTime.Now,
                selectedCheatMeal.Name,
                selectedCheatMeal.Description,
                selectedCheatMeal.CaloriesPerHundredG,
                int.Parse(consumedAmount),
                user.Weight
            );

            user.CheatMeals.Add(consumedCheatMeal);
        }

        MessagingCenter.Unsubscribe<CheatMealDetailsModal, string>(this, "CheatMealDetail");
        // Use the cheat meal details as needed
        // For example, update the selected cheat meal with the captured data
    }
}
