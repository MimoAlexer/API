namespace APIGame.APIGame.API.Entitys
{
    public class BaseMonster : BaseEntity
    {
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public BaseMonster()
        {
            Health = 100;
            AttackPower = 10;
        }

        public void Attack()
        {
            Console.WriteLine("The monster attacks!");
        }
    }
}