using APIGame.APIGame.API.Buildings;
using APIGame.APIGame.API.Economy;

namespace APIGame.APIGame.API.Entitys
{
    public class Human : BaseEntity, IEconomicEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Income { get; set; }
        public House? Home { get; set; }

        public Human()
        {
            Name = "Unknown";
            Age = 0;
            Income = 0;
        }

        public decimal GenerateRevenue()
        {
            return Income;
        }

        public void Speak()
        {
            Console.WriteLine($"{Name} says hello!");
        }
    }
}