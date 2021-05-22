using System;
using System.Collections.Generic;
using System.Text;

namespace WandsAndWarhammers
{
    class Item
    {
      

        //this is where I write about the items
        public static void ItemList()
        {
            Console.WriteLine("A: Armband of Agility");
            Console.WriteLine("+50 to dodging");

            Console.WriteLine("\nB: Bracelet of True Sight");
            Console.WriteLine("+50 to accuracy");

            Console.WriteLine("\nC: Circlet of Charisma");
            Console.WriteLine("+25 to dodge  +25 to speed");

            Console.WriteLine("\nD: Dwarven Dagger");
            Console.WriteLine("adds Backstab attack");

            Console.WriteLine("\nE: Earth Elemental Earrings");
            Console.WriteLine("+75HP -25 dodge");

            Console.WriteLine("\nF: Flaming Sword");
            Console.WriteLine("+75 strength -25 accuracy");

            Console.WriteLine("\nG: Gavel of Justice");
            Console.WriteLine("adds Gavel Smash attack");

            Console.WriteLine("\nH: Hellish Hairband");
            Console.WriteLine("1/2 chance of damaging user or boosting strength & HP");
            //new
            Console.WriteLine("\nI: Iron Cleaver");
            Console.WriteLine("adds Butcher attack");

            Console.WriteLine("\nJ: Jelly");
            Console.WriteLine("adds Slippery special attack");

            Console.WriteLine("\nM: Mace of Mortation");
            Console.WriteLine("Always does 100 damage");
            //end new
            Console.WriteLine("\nO: Orb of Dysfunction");
            Console.WriteLine("Temporarily reduces both players' strength");

        }
    }
}
