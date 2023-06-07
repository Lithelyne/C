Attack attackOne = new Attack("Kamehameha", 15);
Attack attackTwo = new Attack("Spirit Bomb", 25);
Attack attackThree = new Attack("Solar Flare", 5);

Attack enemyAttackOne = new Attack("Death Beam", 15);
Attack enemyAttackTwo = new Attack("Punch", 10);
Attack enemyAttackThree = new Attack("Death Ball", 25);

Enemy enemyOne = new Enemy("Frieza");
enemyOne.AttackList = new List<Attack>()
{
    enemyAttackOne,
    enemyAttackTwo,
    enemyAttackThree
};

enemyOne.PerformRandomAttack();