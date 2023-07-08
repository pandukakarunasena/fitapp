namespace FitApp.Models
{
    internal class CheatMealDetail
    {
        public string ConsumedAmount { get; set; }

        public CheatMealDetail(string consumedAmount)
        {
            this.ConsumedAmount = consumedAmount;
        }
    }
}