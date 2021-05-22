using System;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;

namespace WandsAndWarhammers
{
    

    class Program
    {

        //internet stuff
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;


        static void Main(string[] args)
        {

            //internet code to max screen
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            //Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n  WELCOME TO WANDS AND WARHAMMERS");
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("TWO CHAMPIONS ENTER A STRATEGIC AND OVER THE TOP FIGHT");
            Console.WriteLine("TO THE DEATH! CHOOSE YOUR CHARACTER AND ITEMS WISELY, AND MAKE");
            Console.WriteLine("SURE TO ALWAYS INPUT YOUR ATTACK CORRECTLY IF YOU WANT TO SURVIVE!\n");
            Console.WriteLine("STANDARD ATTACKS ARE LIGHT PUNCH (HITS OFTEN AND DOES LESS DAMAGE) AND HEAVY PUNCH (THE OPPOSITE)\n\n");
            bool aiMode = false;
            Console.WriteLine("Press P for 2-player mode or C to play against computer.");
            char inputConsole = GetChar();
            if (inputConsole == 'c' || inputConsole=='C')
            {
                aiMode = true;
            }
            ProgramMid(aiMode);
        }
        
        static void ProgramMid(bool aiMode)
        { 
            Random rand = new Random();

            Player playerOne = new Player();
            List<Attack> listAttacksPlayerOne = new List<Attack>()
            {
                new Attack() { AttackName = "Light Punch", StrengthModifier = -150, AccModifier = +100, SpeedModifier = +100, AmountUses = 999 },
                new Attack() { AttackName = "Heavy Punch", StrengthModifier = 0, AccModifier = -100, SpeedModifier = -100,  AmountUses = 999 },
            };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n  PLAYER 1 CHOOSE YOUR CHARACTER");
            Player.PlayerList();
            Player.GenerateStats(GetChar(), playerOne, listAttacksPlayerOne);
            Console.WriteLine($"  Player 1 {playerOne.fighterName} HP: {playerOne.Hp} strength: {playerOne.Strength}  accuracy: {playerOne.Accuracy}  dodge: {playerOne.Dodge}  speed: {playerOne.Speed}");
            Console.WriteLine($"\nPLAYER 1 CHOOSE YOUR FIRST ITEM");
            Item.ItemList();
            Player.GenerateItem(GetChar(), playerOne, listAttacksPlayerOne, 1);
            Console.WriteLine($"\n\n\n\n\nPLAYER 1 CHOOSE YOUR SECOND ITEM");
            Item.ItemList();
            Player.GenerateItem(GetChar(), playerOne, listAttacksPlayerOne, 2);

            Player playerTwo = new Player();
            List<Attack> listAttacksPlayerTwo = new List<Attack>()
            {
                new Attack() { AttackName = "Light Punch", StrengthModifier = -200, AccModifier = +100, SpeedModifier = +100,  AmountUses = 999 },
                new Attack() { AttackName = "Heavy Punch", StrengthModifier = 0, AccModifier = -50, SpeedModifier = -100,  AmountUses = 999 },
            };
            Console.WriteLine($"\n\n\n\n\n  PLAYER 2 CHOOSE YOUR CHARACTER");
            Player.PlayerList();
            if (aiMode == false)
            {
                Player.GenerateStats(GetChar(), playerTwo, listAttacksPlayerTwo);
                Console.WriteLine($"   Player 2 {playerTwo.fighterName} HP: {playerTwo.Hp} strength: {playerTwo.Strength}  accuracy: {playerTwo.Accuracy}  dodge: {playerTwo.Dodge}  speed: {playerTwo.Speed}\n");
                Console.WriteLine($"\nPLAYER 2 CHOOSE YOUR ITEM");
                Item.ItemList();
                Player.GenerateItem(GetChar(), playerTwo, listAttacksPlayerTwo, 1);
                Console.WriteLine($"\n\n\n\n\nPLAYER 2 CHOOSE YOUR SECOND ITEM");
                Item.ItemList();
                Player.GenerateItem(GetChar(), playerTwo, listAttacksPlayerTwo, 2);
            }
            else //ai mode
            {
                Thread.Sleep(500);
                IDictionary<int, char> PlayerNames = new Dictionary<int, char>();
                PlayerNames.Add(1, 'a'); 
                PlayerNames.Add(2, 'b');
                PlayerNames.Add(3, 'c');
                PlayerNames.Add(4, 'd');
                PlayerNames.Add(5, 'e');
                PlayerNames.Add(6, 'f');
                PlayerNames.Add(7, 'g');
                PlayerNames.Add(8, 'h');
                PlayerNames.Add(9, 'i');
                PlayerNames.Add(10, 'j');

                PlayerNames.Add(11, 'm');

                int charSelect = rand.Next(1,12);


                Player.GenerateStats(PlayerNames[charSelect], playerTwo, listAttacksPlayerTwo);
                Thread.Sleep(500);
                Console.WriteLine($"   Player 2 {playerTwo.fighterName} HP: {playerTwo.Hp} strength: {playerTwo.Strength}  accuracy: {playerTwo.Accuracy}  dodge: {playerTwo.Dodge}  speed: {playerTwo.Speed}\n");
                Console.WriteLine($"\nPLAYER 2 CHOOSE YOUR ITEM");
                Item.ItemList();
                charSelect = rand.Next(1, 12);
                Player.GenerateItem(PlayerNames[charSelect], playerTwo, listAttacksPlayerTwo, 1);
                Thread.Sleep(500);
                Console.WriteLine($"\n\n\n\n\nPLAYER 2 CHOOSE YOUR SECOND ITEM");
                Item.ItemList();
                charSelect = rand.Next(1, 12);
                Player.GenerateItem(PlayerNames[charSelect], playerTwo, listAttacksPlayerTwo, 2);
                Thread.Sleep(500);
            }

            Console.WriteLine($"\n\n\n\n\nPREPARE TO BATTLE: \nPLAYER 1: {playerOne.fighterName} WITH {playerOne.itemName} & {playerOne.itemNameTwo} \nVS. \nPLAYER 2: {playerTwo.fighterName} WITH {playerTwo.itemName} & {playerTwo.itemNameTwo} \n FIGHT BEGIN");
            Thread.Sleep(1500);
            Console.Write(".");
            Thread.Sleep(1500);
            Console.Write(".");
            Thread.Sleep(1500);
            Console.Write(".");
            Thread.Sleep(1500);
            Console.Write(".");
            Thread.Sleep(1500);
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.Gray;
            int turnCounter = 2;
            GameLoopPlayerOne(playerOne, listAttacksPlayerOne, playerTwo, listAttacksPlayerTwo, rand, turnCounter, aiMode);
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

        static void GameLoopPlayerOne(Player playerOne, List<Attack> listAttacksPlayerOne, Player playerTwo, List<Attack> listAttacksPlayerTwo, Random rand, int turnCounter, bool aiMode)
        {
            if (playerTwo.TurnSomethingHappens > 0)
            {
                playerTwo.TurnSomethingHappens -= 1;
                Attack.TurnSomethingHappens(playerTwo, playerOne);
            }
            if (playerOne.TurnSomethingHappens > 0)
            {
                playerOne.TurnSomethingHappens -= 1;
                Attack.TurnSomethingHappens(playerOne, playerTwo);
            }
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine($"\nPlayer 1 {playerOne.fighterName} Turn {turnCounter/2} Begin.\n");
            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Player 1 {playerOne.fighterName} HP: {playerOne.Hp} strength: {playerOne.Strength}  accuracy: {playerOne.Accuracy}  dodge: {playerOne.Dodge}  speed: {playerOne.Speed} \n  Player 2 {playerTwo.fighterName} HP: {playerTwo.Hp} strength: {playerTwo.Strength}  accuracy: {playerTwo.Accuracy}  dodge: {playerTwo.Dodge}  speed: {playerTwo.Speed}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            if (playerOne.Hp <1)
                {
                    GameOver(2, playerOne, playerTwo);
                   
                }
                else if (playerOne.IsParalyzed == true)
                {
                    Console.WriteLine("Player 1 Paralyzed.");
                    GameLoopPlayerTwo(playerOne, listAttacksPlayerOne, playerTwo, listAttacksPlayerTwo, rand, turnCounter, aiMode);
                }              
                else
                {
                    foreach (Attack attack in listAttacksPlayerOne)
                    {
                        Console.WriteLine($"{attack.AttackName}   uses: {attack.AmountUses}");
                    }
                    Console.WriteLine("Write which attack you want to use (with the correct spelling and capitalization!) then press enter.\n");
               
                //this stops opponent from pressing enter a lot
                string input = null;              
                input = Console.ReadLine();
                while (string.IsNullOrEmpty(input))
                {
                    input = Console.ReadLine();
                }


                    //when you attack
                    foreach (Attack attack in listAttacksPlayerOne)
                    {
                        if (input == attack.AttackName && attack.AmountUses > 0)
                        {
                            attack.AmountUses -= 1;
                            if (attack.AmountUses > 0)
                            {
                                Console.WriteLine($"{attack.AmountUses} attack uses left.");
                            }
                            if (attack.Special == true)
                            {
                            Attack.SpecialAttack(attack, playerOne, playerTwo);
                            }
                            int speedRandom = rand.Next(0, 801);
                            int playerSpeed = speedRandom + attack.SpeedModifier + playerOne.Speed;
                            if (playerSpeed > playerTwo.Speed)
                            {
                                bool isHit = Player.HitCalculation(rand, playerOne, playerTwo, attack);
                                if (isHit == true)
                                {
                                    Thread.Sleep(1500);
                                    int dmg = Player.DamageCalculation(rand, playerOne, playerTwo, attack);
                                if (dmg > 0)
                                {
                                    playerTwo.Hp -= dmg;
                                }
                            }
                            }
                            else
                            {
                                Console.WriteLine("Too slow to land the attack in time!");
                            }
                        }
                    }
                Thread.Sleep(2500);
                turnCounter++;
                GameLoopPlayerTwo(playerOne, listAttacksPlayerOne, playerTwo, listAttacksPlayerTwo, rand, turnCounter, aiMode);
            }         
        }

        static void GameLoopPlayerTwo(Player playerOne, List<Attack>listAttacksPlayerOne, Player playerTwo, List<Attack> listAttacksPlayerTwo, Random rand, int turnCounter, bool aiMode)
        {
            if (playerTwo.TurnSomethingHappens > 0)
            {
                playerTwo.TurnSomethingHappens -= 1;
                Attack.TurnSomethingHappens(playerTwo, playerOne);
            }
            if (playerOne.TurnSomethingHappens > 0)
            {
                playerOne.TurnSomethingHappens -= 1;
                Attack.TurnSomethingHappens(playerOne, playerTwo);
            }
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine($"\nPlayer 2 {playerTwo.fighterName} Turn {(turnCounter / 2)} Begin.\n");
            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"  Player 1 {playerOne.fighterName} HP: {playerOne.Hp} strength: {playerOne.Strength}  accuracy: {playerOne.Accuracy}  dodge: {playerOne.Dodge}  speed: {playerOne.Speed} \n  Player 2 {playerTwo.fighterName} HP: {playerTwo.Hp} strength: {playerTwo.Strength}  accuracy: {playerTwo.Accuracy}  dodge: {playerTwo.Dodge}  speed: {playerTwo.Speed}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            if (playerTwo.Hp < 1)
            {
                GameOver(1, playerOne, playerTwo);
               
            }
            else if (playerTwo.IsParalyzed == true)
            {
                Console.WriteLine("Player 2 Paralyzed.");
                GameLoopPlayerOne(playerOne, listAttacksPlayerOne, playerTwo, listAttacksPlayerTwo, rand, turnCounter, aiMode);
            }
            else if (aiMode == false)
            {
                foreach (Attack attack in listAttacksPlayerTwo)
                {
                    Console.WriteLine($"{attack.AttackName}   uses: {attack.AmountUses}");
                }
                Console.WriteLine("Write which attack you want to use (with the correct spelling and capitalization!) then press enter.\n");
                //new
                string inputTwo = null;
                inputTwo = Console.ReadLine();
                while (string.IsNullOrEmpty(inputTwo))
                {
                    inputTwo = Console.ReadLine();
                }
                foreach (Attack attack in listAttacksPlayerTwo)
                {
                    if (inputTwo == attack.AttackName && attack.AmountUses > 0)
                    {
                        attack.AmountUses -= 1;
                        if (attack.AmountUses > 0)
                        {
                            Console.WriteLine($"{attack.AmountUses} attack uses left.");
                        }
                        if (attack.Special == true)
                        {
                            Attack.SpecialAttack(attack, playerTwo, playerOne);
                        }
                        int speedRandom = rand.Next(0, 801);
                        int playerSpeed = speedRandom + attack.SpeedModifier + playerTwo.Speed;
                        if (playerSpeed > playerOne.Speed)
                        {
                            bool isHit = Player.HitCalculation(rand, playerTwo, playerOne, attack);
                            if (isHit == true)
                            {
                                Thread.Sleep(1500);
                                int dmg = Player.DamageCalculation(rand, playerTwo, playerOne, attack);
                                if (dmg > 0)
                                {
                                    playerOne.Hp -= dmg;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Too slow to land the attack in time!");
                        }
                    }
                }
                Thread.Sleep(1500);
                turnCounter++;
                GameLoopPlayerOne(playerOne, listAttacksPlayerOne, playerTwo, listAttacksPlayerTwo, rand, turnCounter, aiMode);
            }





            else //ai mode
            {
                int foreachCounter = 0;
                IDictionary<int, string> AiAttackNames = new Dictionary<int, string>();
                foreach (Attack attack in listAttacksPlayerTwo)
                    {
                        Console.WriteLine($"{attack.AttackName}   uses: {attack.AmountUses}");
                        if (attack.AmountUses > 0)
                        {
                            AiAttackNames.Add(foreachCounter, $"{attack.AttackName}");
                        }
                        foreachCounter++;
                }
                    Console.WriteLine("Write which attack you want to use (with the correct spelling and capitalization!) then press enter.\n");

                    int currentAiMoveChoiceNumber = rand.Next(0,AiAttackNames.Count);              
                    string inputAI = AiAttackNames[currentAiMoveChoiceNumber];
                    Thread.Sleep(1700);

                    char[] characters = $"{inputAI}".ToCharArray();
                    foreach( char ch in characters)
                    {
                        Console.Write($"{ch}");
                        int pause = rand.Next(60, 150);
                        Thread.Sleep(pause);
                        if (pause == 149)
                        {
                            Console.Write("h");
                            inputAI = "a";
                        }
                    }
                    Console.WriteLine("");
                    Thread.Sleep(900);
                    foreach (Attack attack in listAttacksPlayerTwo)
                    {
                        if (inputAI == attack.AttackName && attack.AmountUses > 0)
                        {
                            attack.AmountUses -= 1;
                            if (attack.AmountUses > 0)
                            {
                                Console.WriteLine($"\n{attack.AmountUses} attack uses left.");
                            }
                            if (attack.Special == true)
                            {
                                Attack.SpecialAttack(attack, playerTwo, playerOne);
                            }


                            int speedRandom = rand.Next(0, 801);
                            int playerSpeed = speedRandom + attack.SpeedModifier + playerTwo.Speed;
                            if (playerSpeed > playerOne.Speed)
                            {
                                bool isHit = Player.HitCalculation(rand, playerTwo, playerOne, attack);
                                if (isHit == true)
                                {
                                    Thread.Sleep(1500);
                                    int dmg = Player.DamageCalculation(rand, playerTwo, playerOne, attack);
                                    if (dmg > 0)
                                    {
                                        playerOne.Hp -= dmg;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Too slow to land the attack in time!");
                            }
                        }
                    }
                    Thread.Sleep(1500);
                    turnCounter++;
                    GameLoopPlayerOne(playerOne, listAttacksPlayerOne, playerTwo, listAttacksPlayerTwo, rand, turnCounter, aiMode);
            }
        }

                static void GameOver(int numberOfWinner, Player playerOne, Player playerTwo)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (numberOfWinner ==1)
            {
                Console.WriteLine($"\nPlayer 1, {playerOne.fighterName} wins!");
                Console.ReadLine();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"\nPlayer 2, {playerTwo.fighterName} wins!");
                Console.ReadLine();
                Console.ReadLine();
            }  
        }

    }
}


