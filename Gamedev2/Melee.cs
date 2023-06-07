public class MeleeFighter : Enemy
{
    public MeleeFighter(string name) : base(name)
    {
        Health = 120;
        AttackList = new List<Attack>
        {
            new Attack("Punch", 20),
            new Attack("Kick", 15),
            new Attack("Tackle", 25)
        };
    }

    public void Rage(Enemy target)
{
    Random random = new Random();
    int index = random.Next(AttackList.Count); 

    Attack chosenAttack = AttackList[index]; 

    chosenAttack.DamageAmount += 10;

    PerformAttack(target, chosenAttack);
}


}
