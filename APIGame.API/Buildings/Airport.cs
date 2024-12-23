using APIGame.APIGame.API.Traveling;

namespace APIGame.APIGame.API.Buildings
{
    public class Airport : BasePublicBuilding
    {
        public int Runways { get; set; }
        public List<Airplane> Airplanes { get; set; }

        public Airport()
        {
            Runways = 1;
            Airplanes = new List<Airplane>();
        }

        public void LandPlane(Airplane airplane)
        {
            Airplanes.Add(airplane);
            Console.WriteLine("A plane has landed.");
        }
    }
}