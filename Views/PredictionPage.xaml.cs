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

    public PredictionPage() {
        InitializeComponent();

        user = UserRepository.GetUser();
        List<DataPoint> existingData = new List<DataPoint>();

        if (user.CheatMeals.Count > 0 || user.CompletedWorkouts.Count > 0)
        {
            existingData = new DataGenerator().getCompleteOrderedDataPointList(
            user.CompletedWorkouts, user.CheatMeals);
        }
        

        var dataGenetors = new DataGenerator();

        //test data to generate the prediction.
        //var existingData = new List<DataPoint>{
        //    new DataPoint(new DateTime(2023, 08, 10), 80, "W"),
        //    new DataPoint(new DateTime(2023, 09, 15), 79.5, "W"),
