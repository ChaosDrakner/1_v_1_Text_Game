using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// 1 v 1 battle Arena
/// Created by ChaosDrakner
/// A game in the making where the player goes against an ememy in one on one combat.
/// To Do add in a turn choice system for the player, currently the player and enemy just attack back and forth until someone reaches zero HP or less.
/// Add victory counter, maybe allow weapon changes.
/// 
/// </summary>
namespace _1_v_1_text_game
{
    class Program
    {

        static void Main(string[] args)
        {

            int weaponPick, minDMG, maxDMG, critMultiplier;
            Console.WriteLine("1: Dagger 4-8 dmg 4x Critical Multiplier");
            Console.WriteLine("2: Short Sword 6-12 3x Critical Multiplier ");
            Console.WriteLine("3: Long Sword 8-16 2x Critical Multiplier");
            Console.Write("Please choose your weapon: ");

            weaponPick = Convert.ToInt16(Console.ReadLine());

            //Weapon choice for the player, setting the minDMG, maxDMG, and crit Multiplier
            switch (weaponPick)
            {
                case 1:
                    minDMG = 4;
                    maxDMG = 8;
                    critMultiplier = 4;
                    Console.Write("You have chosen, Dagger! Good Luck!");
                    Console.ReadLine();
                    GamePlay(minDMG, maxDMG, critMultiplier);
                    break;

                case 2:
                    minDMG = 6;
                    maxDMG = 12;
                    critMultiplier = 3;
                    Console.Write("You have chosen, Short Sword! Good Luck!");
                    Console.ReadLine();
                    GamePlay(minDMG, maxDMG, critMultiplier);
                    break;

                case 3:
                    minDMG = 8;
                    maxDMG = 16;
                    critMultiplier = 2;
                    Console.Write("You have chosen, Long Sword! Good Luck!");
                    Console.ReadLine();
                    GamePlay(minDMG, maxDMG, critMultiplier);
                    break;

                default:
                    minDMG = 1;
                    maxDMG = 2;
                    critMultiplier = 1;
                    Console.Write("You have chosen, bare fists! Good Luck!");
                    Console.ReadLine();
                    GamePlay(minDMG, maxDMG, critMultiplier);
                    break;
            }

        }

        // Damage Caluclator Function, used for both Player and Enemy, currently 25% chance of a critical strick
        static int damage_calc(int min, int max, int critMultiplier)
        {
            int totalDmg, critCheck;
            Random rand = new Random();

            critCheck = rand.Next(1, 20);
            totalDmg = rand.Next(min, max);

            if (critCheck >= 15)
            {
                totalDmg = totalDmg * critMultiplier;
                Console.WriteLine("That was a critical strike! roll was " + critCheck);
                return totalDmg;
            }
            else
            {
                return totalDmg;
            }


        }
 
       static void GamePlay(int minDMG, int maxDMG, int critMultiplier) {
                int EnemyHP = 100;
                int PlayerHP = 100;
                int enemyDMG, playerDMG;
                bool GameOver = false;
                bool PlayerWin = false;


                ///Actual combat code, once it is done will tell the player if they won or lost.
                do
                {


                    playerDMG = damage_calc(minDMG, maxDMG, critMultiplier);
                    EnemyHP = EnemyHP - playerDMG;
                    Console.WriteLine("You delt " + playerDMG + " to the enemy. Enemy HP left " + EnemyHP);
                    enemyDMG = damage_calc(1, 10, 2);

                    PlayerHP = PlayerHP - enemyDMG;

                    Console.WriteLine("The enemy hit back for " + enemyDMG + " reducing you to " + PlayerHP);


                    if (EnemyHP <= 0 & PlayerHP >= 1)
                    {
                        GameOver = true;
                        PlayerWin = true;
                    }

                    else if (PlayerHP <= 0)
                    {
                        GameOver = true;
                    }



                } while (GameOver == false);


                // Statement that displays if the player won or not.
                if (PlayerWin == true)
                {

                    Console.WriteLine("You win!!!");
                    Console.ReadKey();
                }

                else if (PlayerWin == false)
                {
                    Console.WriteLine("You lose!");
                    Console.ReadKey();
                }
            }
    }
}
