namespace APIGame.APIGame.API.Buildings
{
    public class Skyscraper : BasePublicBuilding
    {
        public int Elevators { get; set; }

        public Skyscraper()
        {
            Elevators = 4;
            Revenue = 20000; // Example revenue
        }

        public override decimal GenerateRevenue()
        {
            return Floors * Revenue;
        }

        public void GoToTopFloor()
        {
            Console.WriteLine("Going to the top floor.");
        }
    }
}