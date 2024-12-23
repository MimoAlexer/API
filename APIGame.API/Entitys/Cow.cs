namespace APIGame.APIGame.API.Entitys
{
    public class Cow : BaseEntity
    {
        public string Breed { get; set; }
        public double MilkProduction { get; set; }

        public Cow()
        {
            Breed = "Unknown";
            MilkProduction = 0.0;
        }

        public void Moo()
        {
            Console.WriteLine("The cow moos!");
        }
    }
}