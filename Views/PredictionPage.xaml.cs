namespace FitApp.Views;

using FitApp.Models;
using FitApp.Helpers;
using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearRegression;
using FitApp.Repositories;
using FitApp.Helpers;
using Syncfusion.Maui.Charts;

public partial class PredictionPage : ContentPage
{
    List<DataPoint> PredictionsList = new List<DataPoint>();
    User user;

    public PredictionPage()
    {
        InitializeComponent();

        user = UserRepository.GetUser();
        List<DataPoint> existingData = new List<DataPoint>();

        if (user.CheatMeals.Count > 0 || user.CompletedWorkouts.Count > 0)
        {
            existingData = new DataGenerator().getCompleteOrderedDataPointList(
            user.CompletedWorkouts, user.CheatMeals);
        }


        var dataGenerator = new DataGenerator();
        List<DataPointPrediction> predictedData = new List<DataPointPrediction>();

        if (existingData.Count > 10)
        {
            predictedData = dataGenerator.PredictNextDataPoints(existingData, 5, 1);
        }

        PredictionsView.ItemsSource = predictedData;
    }
}
