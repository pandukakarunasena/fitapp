using FitApp.Models;

namespace FitApp.Views.Modals;

public partial class WorkoutDetailsModalPage : ContentPage
{
	public WorkoutDetailsModalPage()
	{
		InitializeComponent();
	}

    private void OnSaveClicked(object sender, EventArgs e)
    {

        float weight = float.Parse(weightEntry.Text);
        string completedAmount = amountEntry.Text;

        // Pass the captured workout details back to the previous page or process it as needed
        MessagingCenter.Send<WorkoutDetailsModalPage, WorkoutDetail>
            (this, "WorkoutDetail", new WorkoutDetail(completedAmount, weight));

        // Dismiss the modal page
        Application.Current.MainPage.Navigation.PopModalAsync();
    }
}