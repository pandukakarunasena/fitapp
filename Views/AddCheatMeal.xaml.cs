using FitApp.Repositories;
using FitApp.Models;
using System.Collections.ObjectModel;
using FitApp.Views.Modals;
using System.Xml.Linq;

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
                GenerateRandomId(),
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

    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var cheatMeal = button.BindingContext as CheatMeal;
        if (cheatMeal != null)
        {
            var selectedItem = CheatMealHistoryListView.SelectedItem;

            if (selectedItem is ConsumedCheatMeal consumedCheatMeal)
            {
                UserRepository.UpdateCheatMeal(consumedCheatMeal);
            }


            DisplayAlert("Update", "Entry updated successfully.", "OK");
        }
           
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Delete", "Are you sure you want to delete the consumed cheat meal?", "Yes", "No");

        if (answer)
        {
            var button = (Button)sender;
            var consumedCheatMeal = button.BindingContext as ConsumedCheatMeal;
            if (consumedCheatMeal != null)
            {

                UserRepository.RemoveCheatMeal(consumedCheatMeal);
                await DisplayAlert("Delete", "Consumed cheat meal deleted successfully.", "OK");
            }

            CheatMealHistoryListView.ItemsSource = user.CheatMeals;
        } 
    }

    private string GenerateRandomId()
    {
        Guid guid = Guid.NewGuid();
        string randomId = guid.ToString();
        return randomId;
    }

}
