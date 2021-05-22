using System;
using System.Collections.Generic;
using System.Text;

namespace WandsAndWarhammers
{
    class Player
    {
        private string _fighterName;
        private string _itemName;
        private string _itemNameTwo;
        private char _fighter;
        private char _item;
        private char _injuries;
        private bool _isParalyzed;
        private int _hp;
        private int _strength;
        private int _dodge;
        private int _turnSomethingHappens;
        private int _headArmor;
        private int _chestArmor;
        private int _legsArmor;
        private int _accuracy;
        private int _speed;
        private int _tempDamageModifier;

        public static bool HitCalculation(Random rand, Player attacker, Player defender, Attack attack)
        {
            bool hits = false;
            int random = rand.Next(0, 451);
            int result = attacker.Speed + (attacker.Accuracy * 2);         
            int enemyResult = defender.Dodge + (defender.Speed / 2) + random;  
            if (random < 40)
            {
                Console.WriteLine("\nMisses");
            }
                else if (result > enemyResult || random  > 415)
            {
                Console.WriteLine("\nHits");
                hits = true;
            }
            else
            {
                Console.WriteLine("\nMisses");
            }
            return hits;
        }

        public static int DamageCalculation(Random rand, Player attacker, Player defender, Attack attack)
        {
            int random = rand.Next(0, 101);
            int damage = (attacker.Strength/10) + (attack.StrengthModifier/10) + random;
            if (random < 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{defender.fighterName} is miraculously unharmed!");
                damage = 0;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (random > 97)
            {
                damage *= 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("CRITICAL HIT!"); 
            }
            if (damage > 0)
            {
                Console.WriteLine($"{attacker.fighterName} does {damage} damage to {defender.fighterName}!");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            return damage;
        }

        public string fighterName
        {
            get { return _fighterName; }
            set { _fighterName = value; }
        }

        public string itemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        public string itemNameTwo
        {
            get { return _itemNameTwo; }
            set { _itemNameTwo = value; }
        }
        public char Item
        {
            get { return _item; }   
            set { _item = value; }
        }

        public char Fighter
        {
            get { return _fighter; }
            set { _fighter = value; }
        }

        public char Injuries  
        { get; set; }

        public bool IsParalyzed { get; set; }

        public int Hp  
        { get; set; }

        public int TurnSomethingHappens
        { get; set; }

        public int Strength  
            { get; set; }

        public int Dodge
        { get; set; }

        public int HeadArmor
        { get; set; }

        public int ChestArmor
        { get; set; }

        public int LegsArmor
        { get; set; }

        public int Accuracy
        { get; set; }

        public int Speed
        { get; set; }

        public int TempDamageModifier
        { get; set; }

        //where I write about the players. 
        public static void PlayerList()
        {
            Console.WriteLine("  Type your character's letter then press enter.");
         

            Console.ForegroundColor = ConsoleColor.Blue;



            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---Balanced---");
            Console.WriteLine("D: Dwight the Dragonborn");
            Console.WriteLine("hp: 600  strength: 600  accuracy: 450  dodge: 400  speed: 450 (1 spl. attack)\n");
            Console.WriteLine("C: Catherine the Catgirl");
            Console.WriteLine("hp: 400  strength: 400  accuracy: 650  dodge: 600  speed: 550 (1 spl. attack)\n");
          

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---Damage---");
            Console.WriteLine("E: Epsilios the Eldritch God");
            Console.WriteLine("hp: 800  strength: 800  accuracy: 300  dodge: 300  speed: 275 (1 spl. attack)\n");
            Console.WriteLine("B: Braun the Barbarian");
            Console.WriteLine("hp: 600  strength: 700  accuracy: 400  dodge: 200  speed: 400 (1 spl. attack)\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---Tank---");
            Console.WriteLine("F: Frank the Farmer");
            Console.WriteLine("hp: 800  strength: 500  accuracy: 400  dodge: 400  speed: 300 (2 spl. attacks)\n");


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---Sniper---");
            Console.WriteLine("A: Arnaud the Archer");
            Console.WriteLine("hp: 300  strength: 300  accuracy: 700  dodge: 600  speed: 600 (1 spl. attack)\n");
            Console.ForegroundColor = ConsoleColor.Red;


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---Magenta---");
            Console.WriteLine("I: Irene the Witch of Illusion");
            Console.WriteLine("hp: 350  strength: 300  accuracy: 550  dodge: 700  speed: 600 (1 spl. attack)\n");
            Console.WriteLine("J: Jaundice the Joker");
            Console.WriteLine("hp: 200  strength: 200  accuracy: 600  dodge: 750  speed: 750 (1 spl. attack)\n");


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---Tactical---");
            Console.WriteLine("G: Gerhardt the Gel Creature");
            Console.WriteLine("hp: 650  strength: 600  accuracy: 400  dodge: 375  speed: 370 (4 spl. attacks)\n");
            Console.WriteLine("H: Hilgride the Hag");
            Console.WriteLine("hp: 400  strength: 300  accuracy: 500  dodge: 400  speed: 400 (2 spl. attack)\n");
            Console.WriteLine("M: Mold Spore Army");
            Console.WriteLine("hp: 250  strength: 50  accuracy: 400  dodge: 300  speed: 400 (1 spl. attack)\n");




            Console.ForegroundColor = ConsoleColor.Gray;

        }

        public static string ItemName(Player playerNumber)
        {
            string itemName = "b";
            switch (playerNumber.Item)
            {
                case 'a':
                    itemName = "Armband of Agility";
                    break;
                case 'b':
                    itemName = "Bracelet of True Sight";
                    break;
                default:
                    break;
            }
            return itemName;
        }


        // This seems to assign PLAYER info. 
        public static void GenerateStats(char fighterInput, Player playerNumber, List<Attack>listAttacks)
        {
            char newInput = char.ToLower(fighterInput);
            switch (newInput)
            {
                case 'a':
                    {
                        playerNumber.fighterName = "Arnaud the Archer";
                        playerNumber.Hp = 300;
                        playerNumber.Strength = 300;
                        playerNumber.Accuracy = 700;
                        playerNumber.Dodge = 600;
                        playerNumber.Speed = 600;
                        listAttacks.Add(new Attack() { AttackName = "Sure Shot", StrengthModifier = -50, AccModifier = +11100, SpeedModifier = +150, AmountUses = 2, Special = false });
                        break;
                    }
                case 'b':
                    {
                        playerNumber.fighterName = "Braun the Barbarian";
                        playerNumber.Hp = 600;
                        playerNumber.Strength = 700;
                        playerNumber.Accuracy = 400;
                        playerNumber.Dodge = 200;
                        playerNumber.Speed = 400;
                        listAttacks.Add(new Attack() { AttackName = "Wild Swing", StrengthModifier = +350, AccModifier = -100, SpeedModifier = 0, AmountUses = 2 });
                        break;
                    }                   
                case 'c':
                    {
                        
                        playerNumber.fighterName = "Catherine the Catgirl";
                        playerNumber.Hp = 400;
                        playerNumber.Strength = 350;
                        playerNumber.Accuracy = 650;
                        playerNumber.Dodge = 600;
                        playerNumber.Speed = 550;
                        listAttacks.Add(new Attack() { AttackName = "Purr", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 1, Special = true });
                        break;
                        
                    }
                case 'd':
                    {

                        playerNumber.fighterName = "Dwight the Dragonborn";
                        playerNumber.Hp = 600;
                        playerNumber.Strength = 600;
                        playerNumber.Accuracy = 450;
                        playerNumber.Dodge = 400;
                        playerNumber.Speed = 450;
                        listAttacks.Add(new Attack() { AttackName = "Breathe Fire", StrengthModifier = +420, AccModifier = -100, SpeedModifier = +10, AmountUses = 1, Special = false });
                        break;
                    }
                case 'e':
                    {

                        playerNumber.fighterName = "Epsilios the Eldritch God";
                        playerNumber.Hp = 800;
                        playerNumber.Strength = 800;
                        playerNumber.Accuracy = 300;
                        playerNumber.Dodge = 300;
                        playerNumber.Speed = 275;
                        listAttacks.Add(new Attack() { AttackName = "Sphere Morph", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 1, Special = true });
                        break;
                    }
                case 'f':
                    {

                        playerNumber.fighterName = "Frank the Farmer";
                        playerNumber.Hp = 800;
                        playerNumber.Strength = 500;
                        playerNumber.Accuracy = 400;
                        playerNumber.Dodge = 400;
                        playerNumber.Speed = 300;
                        listAttacks.Add(new Attack() { AttackName = "Farmer's Reactions", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 1, Special = true });
                        listAttacks.Add(new Attack() { AttackName = "Wild Swing", StrengthModifier = +350, AccModifier = -100, SpeedModifier = 0, AmountUses = 2 });
                        listAttacks.Add(new Attack() { AttackName = "Eat", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 5, Special = true }) ;
                        break;
                    }
                case 'g':
                    {
                        playerNumber.fighterName = "Gerhardt the Gel Creature";
                        playerNumber.Hp = 650;
                        playerNumber.Strength = 600;
                        playerNumber.Accuracy = 400;
                        playerNumber.Dodge = 375;
                        playerNumber.Speed = 375;
                        listAttacks.Add(new Attack() { AttackName = "Grow Arms", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 2, Special = true });
                        listAttacks.Add(new Attack() { AttackName = "Grow Legs", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 2, Special = true });
                        listAttacks.Add(new Attack() { AttackName = "Grow Torso", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 2, Special = true });
                        listAttacks.Add(new Attack() { AttackName = "Grow All", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 1, Special = true });
                        break;
                    }
                case 'h':
                    {
                        playerNumber.fighterName = "Hilgride the Hag";
                        playerNumber.Hp = 400;
                        playerNumber.Strength = 300;
                        playerNumber.Accuracy = 500;
                        playerNumber.Dodge = 400;
                        playerNumber.Speed = 400;
                        listAttacks.Add(new Attack() { AttackName = "Toxic Poison", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 1, Special = true });
                        listAttacks.Add(new Attack() { AttackName = "Wretched Mutation", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 1, Special = true });
                        break;
                    }
                case 'i':
                    {
                        playerNumber.fighterName = "Irene the Witch of Illusion";
                        playerNumber.Hp = 375;
                        playerNumber.Strength = 300;
                        playerNumber.Accuracy = 550;
                        playerNumber.Dodge = 700;
                        playerNumber.Speed = 600;
                        listAttacks.Add(new Attack() { AttackName = "Illusory Bomb", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 1, Special = true });
                        break;
                    }
                case 'j':
                    {
                        playerNumber.fighterName = "Jaundice the Joker";
                        playerNumber.Hp = 200;
                        playerNumber.Strength = 200;
                        playerNumber.Accuracy = 600;
                        playerNumber.Dodge = 750;
                        playerNumber.Speed = 750;
                        listAttacks.Add(new Attack() { AttackName = "Flower Acid Squirter", StrengthModifier = -50, AccModifier = +11100, SpeedModifier = +150, AmountUses = 2, Special = false });
                        break;
                    }
                case 'm':
                    {
                        playerNumber.fighterName = "Mold Spore Army";
                        playerNumber.Hp = 250;
                        playerNumber.Strength = 50;
                        playerNumber.Accuracy = 400;
                        playerNumber.Dodge = 300;
                        playerNumber.Speed = 400;
                        listAttacks.Add(new Attack() { AttackName = "Fungal Reinforcement", StrengthModifier = -50, AccModifier = +11100, SpeedModifier = +150, AmountUses = 2, Special = true });
                        break;
                    }           
                default:
                    {
                        break;
                    }
            }
            
        }

        //this is where the items actually have effects. 
        public static void GenerateItem(char itemInput, Player playerNumber, List<Attack> listAttacks, int itemNumber)
        {
            char newInput = char.ToLower(itemInput);
            switch (newInput)
            {
                case 'a':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Armband of Agility";
                        else
                            playerNumber.itemNameTwo = "Armband of Agility";
                        playerNumber.Dodge += 50;
                        break;
                    }
                case 'b':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Bracelet of True Sight";
                        else
                            playerNumber.itemNameTwo = "Bracelet of True Sight";

                        playerNumber.Accuracy += 50;                   
                        break;
                    }
                case 'c':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Circlet of Charisma";
                        else
                            playerNumber.itemNameTwo = "Circlet of Charisma";

                        playerNumber.Dodge += 25;
                        playerNumber.Speed += 25;
                        break;
                    }
                case 'd':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Dwarven Dagger";
                        else
                            playerNumber.itemNameTwo = "Dwarven Dagger";

                        listAttacks.Add(new Attack() { AttackName = "Backstab", StrengthModifier = +150, AccModifier = +100, SpeedModifier = +100, AmountUses = 2 });
                        break;
                    }
                case 'e':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Earth Elemental Earrings";
                        else
                            playerNumber.itemNameTwo = "Earth Elemental Earrings";
                        playerNumber.Dodge -= 25;
                        playerNumber.Hp += 75;
                        break;
                    }
                case 'f':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Flaming Sword";
                        else
                            playerNumber.itemNameTwo = "Flaming Sword";
                        playerNumber.Accuracy -= 25;
                        playerNumber.Strength += 75;
                        break;
                    }
                case 'g':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Gavel of Justice";
                        else
                            playerNumber.itemNameTwo = "Gavel of Justice";
                        listAttacks.Add(new Attack() { AttackName = "Gavel Smash", StrengthModifier = +550, AccModifier = -100, SpeedModifier = -50, AmountUses = 1 });
                        break;
                    }
                case 'h':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Hellish Hairband";
                        else
                            playerNumber.itemNameTwo = "Hellish Hairband";
                        listAttacks.Add(new Attack() { AttackName = "Deal With The Devil", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 1, Special = true}) ;
                        break;
                    }
                case 'i':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Iron Cleaver";
                        else
                            playerNumber.itemNameTwo = "Iron Cleaver";

                        listAttacks.Add(new Attack() { AttackName = "Butcher", StrengthModifier = -150, AccModifier = +100, SpeedModifier = +100, AmountUses = 2, Special = true });
                        break;
                    }
                case 'j':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Jelly";
                        else
                            playerNumber.itemNameTwo = "Jelly";
                        listAttacks.Add(new Attack() { AttackName = "Slippery", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 3, Special = true });
                        break;
                    }
                case 'm':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Mace of Mortation";
                        else
                            playerNumber.itemNameTwo = "Hellish Hairband";
                        listAttacks.Add(new Attack() { AttackName = "Mace Mortation", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 2, Special = true });
                        break;
                    }





                case 'o':
                    {
                        if (itemNumber == 1)
                            playerNumber.itemName = "Orb of Dysfunction";
                        else
                            playerNumber.itemNameTwo = "Hellish Hairband";
                        listAttacks.Add(new Attack() { AttackName = "Orb of Dysfunction", StrengthModifier = -10000, AccModifier = +11100, SpeedModifier = +550, AmountUses = 1, Special = true });
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

       

        public static void ActionMenu(Player playerNumber)
        {
            Console.WriteLine("A: Attack");
            Console.WriteLine("B: Light Attack");
            char input = GetChar();
            
        }


        static char GetChar()
        {
            bool validInput = false;
            char charInput = 'a';
            do
            {
                try
                {
                    charInput = char.Parse(Console.ReadLine());
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, you must enter a single character.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (!validInput);
            return charInput;
        }


    }


}
