using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitApp.Models;

using Accord.MachineLearning.VectorMachines;
using Accord.Statistics.Kernels;
using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Statistics.Models.Regression.Linear;
using Accord.Math;
using Accord.Statistics.Models.Regression;
using Accord.Statistics.Models.Regression.Fitting;
using MathNet.Numerics.LinearRegression;

namespace FitApp.Helpers
{
    public class DataGenerator
    {

        public List<DataPoint> generateCheatMealData(List<ConsumedCheatMeal> meals)
        {
            if (meals.Count <= 0 || meals == null)
            {
                throw new InvalidDataException();
            }

            List<DataPoint> dataPoints = new List<DataPoint>();

            foreach (var meal in meals)
            {
                DateTime date = meal.Date;
                double consumedAmount = meal.ConsumedAmount;
                double caloriesPerKG = meal.CaloriesPerHundredG;

                // Here the data point is considered as gained weight from a cheat meal.
                double weightGain = convertCaloriesToKG(consumedAmount, caloriesPerKG);
                double finalWeight = meal.CurrentWeightOfUser + weightGain;

                DataPoint dataPoint = new DataPoint(date, finalWeight, "C");
                dataPoints.Add(dataPoint);
            }

            return dataPoints;
        }

        public List<DataPoint> generateWorkoutData(List<CompletedWorkout> workouts)
        {
            if (workouts.Count <= 0 || workouts == null) 
            {
                throw new InvalidDataException();
            }

            List<DataPoint> dataPoints = new List<DataPoint>();

            foreach (var workout in workouts)
            {
                DateTime date = workout.Date;
                double weight = workout.WeightAfterWorkout;

                DataPoint dataPoint = new DataPoint(date, weight, "W");
                dataPoints.Add(dataPoint);
            }

            return dataPoints;
        }

        public double convertCaloriesToKG(double consumedAmount, double caloriesPerKilogram)
        {
            if (consumedAmount <= 0 || caloriesPerKilogram <= 0)
            {
                throw new InvalidDataException();
            }

            double kilograms = (consumedAmount + 200 * caloriesPerKilogram) % 1000;
            return kilograms;
        }

        public List<DataPoint> getCompleteOrderedDataPointList(List<CompletedWorkout> workouts, List<ConsumedCheatMeal> meals)
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            List<DataPoint> workoutData = this.generateWorkoutData(workouts);
            List<DataPoint> cheatMealData = this.generateCheatMealData(meals);

            dataPoints.AddRange(workoutData);
            dataPoints.AddRange(cheatMealData);

            List<DataPoint> sortedDataPoints = dataPoints.OrderBy(DataPoint => DataPoint.Date).ToList();
            return sortedDataPoints;
        }

        public List<DataPointPrediction> PredictNextDataPoints(List<DataPoint> existingData, int predictionCount, int intervalInWeeks)
        {
            var xData = new List<double>();
            var yData = new List<double>();

            foreach (var dataPoint in existingData)
            {
                xData.Add((double)dataPoint.Date.Ticks);
                yData.Add(dataPoint.Weight);
            }

            var line = SimpleRegression.Fit(xData.ToArray(), yData.ToArray());

            var predictions = new List<DataPointPrediction>();

            var predictionDate = existingData[existingData.Count - 1].Date;

            for (int i = 0; i < predictionCount; i++)
            {
                predictionDate = predictionDate.AddDays(intervalInWeeks * 7);

                var predictedWeight = line.A + line.B * predictionDate.Ticks;

                var prediction = new DataPointPrediction
                {
                    Date = predictionDate,
                    Weight = predictedWeight,
                    Type = existingData[0].Type
                };

                predictions.Add(prediction);
            }

            return predictions;
        }
    }
}
