using FitApp.Models;
using FitApp.Repositories;

namespace FitApp.Views;

public partial class AddUserPage : ContentPage
{
	public AddUserPage()
	{
		InitializeComponent();
	}

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        string name = nameEntry.Text;
        double height = double.Parse(heightEntry.Text);
        double weight = double.Parse(weightEntry.Text);
        string activityLevel = activityLevelPicker.SelectedItem as string;

        User userProfile = new User
        {
            Name = name,
            Height = height,
            Weight = weight,
            //ActivityLevel = (activityLevel)Enum.Parse(typeof(ActivityLevel), activityLevel)
        };

        // Save the user profile or perform any other required actions
        User owner = UserRepository.AddUser(userProfile);

        // Display a success message
        DisplayAlert("Success", "User profile saved successfully!", "OK");

		Shell.Current.GoToAsync(nameof(HomePage));
    }
}