using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.Models
{
    internal class WorkoutDetail
    {
        public string AmountCompleted { get; set; }
        public float Weight { get; set; }

        public WorkoutDetail(string amountCompleted, float weight)
        {
            this.AmountCompleted = amountCompleted;
            this.Weight = weight;
        }
    }
}
