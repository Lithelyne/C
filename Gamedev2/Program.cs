MeleeFighter meleeFighter = new MeleeFighter("John Wick");
RangedFighter rangedFighter = new RangedFighter("Goku");
MagicCaster magicCaster = new MagicCaster("Mash");


// Console.WriteLine("Melee Name: " + meleeFighter.Name);
// Console.WriteLine("Ranged Name: " + rangedFighter.Name);
// Console.WriteLine("Magic Name: " + magicCaster.Name);

meleeFighter.PerformAttack(rangedFighter, meleeFighter.AttackList[1]);
meleeFighter.Rage(magicCaster);
rangedFighter.PerformRangedAttack(meleeFighter, rangedFighter.AttackList[0]);
rangedFighter.Dash();
rangedFighter.PerformRangedAttack(meleeFighter, rangedFighter.AttackList[0]);
magicCaster.PerformAttack(meleeFighter, magicCaster.AttackList[0]); 
magicCaster.Heal(rangedFighter);
magicCaster.Heal(magicCaster);

rangedFighter.PerformAttack(meleeFighter, rangedFighter.AttackList[1]);
