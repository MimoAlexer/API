namespace APIGame.APIGame.API.Economy
{
    public class Economy
    {
        private List<IEconomicEntity> _entities;

        public Economy()
        {
            _entities = new List<IEconomicEntity>();
        }

        public void AddEntity(IEconomicEntity entity)
        {
            _entities.Add(entity);
        }

        public decimal CalculateTotalRevenue()
        {
            decimal totalRevenue = 0;
            foreach (var entity in _entities)
            {
                totalRevenue += entity.GenerateRevenue();
            }
            return totalRevenue;
        }
    }
}