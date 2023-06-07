public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public List<Attack> AttackList { get; set; } = new List<Attack>();


    public Enemy(string name) 
    {
        Name = name; 
    }

public void PerformRandomAttack()
{
    Random random = new Random();
    int randomIndex = random.Next(AttackList.Count);
    Attack randomAttack = AttackList[randomIndex];

    Console.WriteLine($"{Name} performs {randomAttack.AttackName} attack and deals {randomAttack.DamageAmount} damage.");
}


}

