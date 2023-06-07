public class RangedFighter : Enemy
{
    public int Distance { get; set; } = 5;

    public RangedFighter(string name) : base(name)
    {
        Health = 120;
        AttackList = new List<Attack>
        {
            new Attack("Shoot an Arrow", 20),
            new Attack("Throw a Knife", 15)
        };
    }

    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"{Name} dashes, setting Distance to {Distance}.");
    }

    public void PerformRangedAttack(Enemy target, Attack chosenAttack)
    {
        if (Distance >= 10)
        {
            PerformAttack(target, chosenAttack);
        }
        else
        {
            Console.WriteLine($"{Name} is too close to perform a ranged attack!");
        }
    }
}