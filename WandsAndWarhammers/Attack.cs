using System;
using System.Collections.Generic;
using System.Text;

namespace WandsAndWarhammers
{
    class Attack
    {
        private string _attackName;
        private int _strengthModifier;
        private int _accModifier;
        private int _speedModifier;
        private int _amountUses;
        private bool _special;

        public string AttackName
        { get; set; }

        public int StrengthModifier
        { get; set; }

        public int AccModifier
        { get; set; }

        public int SpeedModifier
        { get; set; }

        public bool Special
        { get; set; }

        public int AmountUses
        {
            get
            {

                return _amountUses;
            }
            set { _amountUses = value; }
        }

        //turn something happens

        public static void TurnSomethingHappens(Player playerThatCastedSpell, Player enemyPlayer)
        {
            switch (playerThatCastedSpell.fighterName)
            {
                case "Gerhardt the Gel Creature":
                    {
                        playerThatCastedSpell.Hp += 10;
                        playerThatCastedSpell.Speed += 10;
                        playerThatCastedSpell.Dodge += 10;
                        playerThatCastedSpell.Strength += 10;
                        break;
                    }
                case "Hilgride the Hag":
                    {
                        enemyPlayer.Hp -= 5;
                        enemyPlayer.Speed -= 5;
                        enemyPlayer.Dodge -= 5;
                        enemyPlayer.Strength -= 5;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            switch (playerThatCastedSpell.itemName)
            {
                case "Orb of Dysfunction":
                    {
                        if (playerThatCastedSpell.TurnSomethingHappens == 1)
                        {
                            enemyPlayer.Strength += 1500;
                            playerThatCastedSpell.Strength += 1500;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            switch (playerThatCastedSpell.itemNameTwo)
            {
                case "Orb of Dysfunction":
                    {
                        if (playerThatCastedSpell.TurnSomethingHappens == 1)
                        {
                            enemyPlayer.Strength += 1500;
                            playerThatCastedSpell.Strength += 1500;
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }



        //the special attack list

            public static void SpecialAttack(Attack attack, Player attacker, Player defender)
            {
                switch (attack.AttackName)
                {
                    case "Eat":
                        {
                            Console.WriteLine("Ate a ham and restored 80HP.");
                            attacker.Hp += 80;
                            break;
                        }
                    case "Purr":
                        {
                            Console.WriteLine("Purring helps heal Catherine and she restores 160HP.");
                            attacker.Hp += 160;
                            break;
                        }
                    case "Grow Arms":
                        {
                            Console.WriteLine("Gerhardt grows pseudopod arms, increasing his strength by 50.");
                            attacker.Strength += 50;
                            break;
                        }
                    case "Grow Legs":
                        {
                            Console.WriteLine("Legs shoot out of Gerhardt the gel, increasing his dodge skill by 50.");
                            attacker.Dodge += 50;
                            break;
                        }
                    case "Grow Torso":
                        {
                            Console.WriteLine("Gerhardt increases in size, gaining 180HP and slowing down by 50.");
                            attacker.Hp += 180;
                            attacker.Speed -= 50;
                            break;
                        }
                    case "Grow All":
                        {
                            Console.WriteLine("Gerhardt slowly increases in size over the next 3 turns!");
                            attacker.TurnSomethingHappens = 3;
                            break;
                        }
                    case "Orb of Dysfunction":
                        {
                            Console.WriteLine("Both champions lose their strength for 4 turns!");
                            attacker.Strength -= 1500;
                            defender.Strength -= 1500;
                            attacker.TurnSomethingHappens = 6;
                            break;
                        }
                    case "Wretched Mutation":
                        {
                            Console.WriteLine("Hilgride heals and convulses, growing deformed limbs, metamorphosing into a demonic abomination!");
                            attacker.Hp = 400;
                            attacker.Strength = 525;
                            attacker.Accuracy = 375;
                            attacker.Dodge = 300;
                            attacker.Speed = 400;
                            break;
                        }
                    case "Fungal Reinforcement":
                        {
                            Console.WriteLine("One damaged mold monster is swapped for a fresh(?) one.");
                            attacker.Hp = 250;
                            attacker.Strength = 50;
                            attacker.Accuracy = 400;
                            attacker.Dodge = 300;
                            attacker.Speed = 400;                    
                            break;
                        }                    
                    case "Toxic Poison":
                        {
                            Console.WriteLine("Hilgride poisons her enemy for 6 turns!");
                            attacker.TurnSomethingHappens = 6;
                            break;
                        }
                    case "Illusory Bomb":
                        {
                            Console.WriteLine("Irene glows brightly then explodes in a blinding glow, doing 250 damage to her enemy!");
                            attacker.Hp += 25;
                            attacker.Strength += 25;
                            attacker.Accuracy += 25;
                            attacker.Dodge += 25;
                            attacker.Speed += 25;
                            break;
                        }
                    case "Deal With The Devil":
                        {
                            Random devil = new Random();
                            Console.WriteLine("The Devil appears...");
                            int chance = devil.Next(0, 2);
                            if (chance == 0)
                            {
                                Console.WriteLine("and smites you furiously!");
                                attacker.Hp -= 100;
                            }
                            else
                            {
                                Console.WriteLine("and blesses you with unholy might!");
                                attacker.Strength += 75;
                                attacker.Hp += 75;
                            }
                            break;
                        }
                    case "Sphere Morph":
                        {
                            Console.WriteLine("Epsilios implodes himself into a protected sphere!");
                            attacker.Strength -= 200;
                            attacker.Dodge += 200;
                            attacker.Hp += 80;
                            break;
                        }
                    case "Farmer's Reactions":
                        {
                            Console.WriteLine("Frank focuses, increasing his speed and agility and the expense of strength.");
                            attacker.Strength -= 150;
                            attacker.Dodge += 100;
                            attacker.Speed += 100;
                            break;
                        }
                    case "Butcher":
                        {
                            Console.WriteLine("The champion hacks into the meat of their opponent, reducing strength & dodge!");
                            defender.Strength -= 25;
                            defender.Dodge -= 25;
                            break;
                        }
                    case "Slippery":
                        {
                            Console.WriteLine("The champion applies slippery jelly to themselves, making them hard to hit.");
                            attacker.Dodge += 25;
                            attacker.Speed += 25;
                            break;
                        }
                    case "Mace Mortation":
                        {
                            Console.WriteLine("The champion smites their opponent, doing 100 damage!");
                            defender.Hp -= 100;
                            break;
                        }                    
                    default:
                        {
                            break;
                        }
                }
            }



        }
    }
