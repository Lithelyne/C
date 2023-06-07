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
    //generates random number
    Random random = new Random();

    //generates random index within this list
    int index = random.Next(AttackList.Count); 

    //retrieves attack
    Attack chosenAttack = AttackList[index]; 

    //will increase whatever attacks damage by 10
    chosenAttack.DamageAmount += 10;

    //passes information into our PerformAttack method from Enemy.cs
    PerformAttack(target, chosenAttack);
}


}
