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
        public string Intensity { get; set; }

        public WorkoutDetail(string amountCompleted, string intensity)
        {
            this.AmountCompleted = amountCompleted;
            this.Intensity = intensity;
        }
    }
}
