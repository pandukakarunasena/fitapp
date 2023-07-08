using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.Models
{
    public class DataPoint
    {
        public DateTime Date { set; get; }
        public double Weight { set; get; }
        public string Type { set; get; }

        public DataPoint(DateTime date, double weight, string type)
        {
            Date = date;
            Weight = weight;
            Type = type;
        }
    }
}
