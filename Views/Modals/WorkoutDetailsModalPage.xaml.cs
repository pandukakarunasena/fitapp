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
        string amountCompleted = amountEntry.Text;
        string intensity = intensityPicker.SelectedItem as string;

        // Pass the captured workout details back to the previous page or process it as needed
        MessagingCenter.Send<WorkoutDetailsModalPage, WorkoutDetail>
            (this, "WorkoutDetail", new WorkoutDetail(amountCompleted,intensity));

        // Dismiss the modal page
        Application.Current.MainPage.Navigation.PopModalAsync();
    }
}