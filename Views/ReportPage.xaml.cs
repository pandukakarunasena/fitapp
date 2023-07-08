using System.Collections.ObjectModel;
using FitApp.Models;
using FitApp.Repositories;
using FitApp.Helpers;
using Syncfusion.Maui.Charts;

namespace FitApp.Views;

public partial class ReportPage : ContentPage
{
	ObservableCollection<DataPoint> Data;
	User user;
    DataGenerator dataGenerator;
    List<DataPoint> WorkoutData = new List<DataPoint>();
    List<DataPoint> CheatMealData = new List<DataPoint>();
    List<DataPoint> FullDataPointsList = new List<DataPoint>();


    public ReportPage()
    {
        InitializeComponent();
        user = UserRepository.GetUser();
        dataGenerator = new DataGenerator();
        WorkoutData = extractWorkoutDataPoints();
        CheatMealData = extractCheatMealtDataPoints();

        // Test data for workout data
        //WorkoutData.Add(new DataPoint(new DateTime(2023, 08, 10), 80, "W"));
        //WorkoutData.Add(new DataPoint(new DateTime(2023, 09, 15), 79.5, "W"));
        //WorkoutData.Add(new DataPoint(new DateTime(2023, 10, 20), 69.2, "W"));
        //WorkoutData.Add(new DataPoint(new DateTime(2023, 10, 23), 74.9, "W"));
        //WorkoutData.Add(new DataPoint(new DateTime(2023, 10, 25), 71.8, "W"));

        //CheatMealData.Add(new DataPoint(new DateTime(2023, 08, 10), 83, "C"));
        //CheatMealData.Add(new DataPoint(new DateTime(2023, 09, 15), 81.5, "C"));
        //CheatMealData.Add(new DataPoint(new DateTime(2023, 10, 20), 76.2, "C"));
        //CheatMealData.Add(new DataPoint(new DateTime(2023, 10, 23), 76.9, "C"));
        //CheatMealData.Add(new DataPoint(new DateTime(2023, 10, 25), 76.8, "C"));


        FullDataPointsList.AddRange(WorkoutData);
        FullDataPointsList.AddRange(CheatMealData);


        List<DataPoint> FilteredData = new List<DataPoint>();
        if (FullDataPointsList.Count > 0)
        {
            DateTime latestDate = WorkoutData[WorkoutData.Count - 1].Date;

            // Create a filtered list of workout data within one week of the latest date
            FilteredData = FullDataPointsList
                .Where(data => (latestDate - data.Date).TotalDays <= 7)
                .ToList();
        } 
      

        // Set the ItemsSource property of the LineSeries to the workout data collections
        LineSeries1.ItemsSource = WorkoutData;
        LineSeries2.ItemsSource = CheatMealData;

        WorkoutListView.ItemsSource = FilteredData;
    }

    private List<DataPoint> extractWorkoutDataPoints()
	{
        if (user.CompletedWorkouts.Count > 0)
        {
            return dataGenerator.generateWorkoutData(user.CompletedWorkouts);
        }

        return new List<DataPoint>();
    }

    private List<DataPoint> extractCheatMealtDataPoints()
    {
        if (user.CheatMeals.Count > 0)
        {
            return dataGenerator.generateCheatMealData(user.CheatMeals);
        }

        return new List<DataPoint>();
    }
}
