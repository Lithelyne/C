public class Attack
{
    public string AttackName { get; set; }
    public int DamageAmount{ get; set;}

    public Attack(string attackName, int damageAmount) 
    {
        AttackName = attackName;
        DamageAmount = damageAmount;
    }

    public string AttackDescription()
    {
    return $"{AttackName}: it deals {DamageAmount}";
    }

}