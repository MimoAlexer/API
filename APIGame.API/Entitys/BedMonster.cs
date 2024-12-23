namespace APIGame.APIGame.API.Entitys
{
    public class BedMonster : BaseMonster
    {
        public string ScareLevel { get; set; }

        public BedMonster()
        {
            ScareLevel = "High";
        }

        public void Scare()
        {
            Console.WriteLine("The bed monster scares you!");
        }
    }
}