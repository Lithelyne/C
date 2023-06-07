public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public List<Attack> AttackList { get; set; } = new List<Attack>();


    public Enemy(string name) 
    {
        Name = name; 
    }



// Inside of the Enemy class
public void PerformAttack(Enemy target, Attack chosenAttack)
{
    target.Health -= chosenAttack.DamageAmount;

    Console.WriteLine($"{Name} attacks {target.Name} with {chosenAttack.AttackName}, dealing {chosenAttack.DamageAmount} damage and reducing {target.Name}'s health to {target.Health}!!");
}




}

