namespace APIGame.APIGame.API.Buildings
{
    public class ShoppingMall : BasePublicBuilding
    {
        public int Shops { get; set; }

        public ShoppingMall()
        {
            Shops = 50;
            Revenue = 10000; // Example revenue
        }

        public override decimal GenerateRevenue()
        {
            return Shops * Revenue;
        }

        public void OpenShops()
        {
            Console.WriteLine("All shops are now open.");
        }
    }
}