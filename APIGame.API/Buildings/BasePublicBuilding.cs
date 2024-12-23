using APIGame.APIGame.API.Economy;
using APIGame.APIGame.API.Traveling;

namespace APIGame.APIGame.API.Buildings
{
    public class BasePublicBuilding : IEconomicEntity
    {
        public string Address { get; set; }
        public int Floors { get; set; }
        public decimal Revenue { get; set; }
        public Country? Country { get; set; }
        public Continent? Continent { get; set; }

        public BasePublicBuilding()
        {
            Address = "Unknown";
            Floors = 1;
            Revenue = 0;
        }

        public virtual decimal GenerateRevenue()
        {
            return Revenue;
        }

        public void Open()
        {
            Console.WriteLine("The building is now open.");
        }
    }
}