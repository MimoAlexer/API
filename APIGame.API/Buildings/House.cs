namespace APIGame.APIGame.API.Buildings
{
    public class House : BasePublicBuilding
    {
        public int Bedrooms { get; set; }

        public House()
        {
            Bedrooms = 3;
        }
    }
}