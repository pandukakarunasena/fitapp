using FitApp.Models;

namespace FitApp.Views.Modals;

public partial class CheatMealDetailsModal : ContentPage
{
	public CheatMealDetailsModal()
	{
		InitializeComponent();
	}

    private void OnSaveClicked(object sender, EventArgs e)
    {
        string consumedAmount = consumedEntry.Text;

        // Pass the captured cheat meal details back to the previous page or process it as needed
        MessagingCenter.Send<CheatMealDetailsModal, string>
            (this, "CheatMealDetail", consumedAmount);

        // Dismiss the modal page
        Application.Current.MainPage.Navigation.PopModalAsync();
    }
}