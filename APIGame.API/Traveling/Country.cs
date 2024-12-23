namespace APIGame.APIGame.API.Traveling
{
    public class Country
    {
        public string Name { get; set; }
        public Continent Continent { get; set; }

        public Country(string name, Continent continent)
        {
            Name = name;
            Continent = continent;
        }
    }
}