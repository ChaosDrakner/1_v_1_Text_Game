using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// 1 v 1 battle Arena
/// Created by ChaosDrakner
/// A game in the making where the player goes against an ememy in one on one combat.
/// 
/// </summary>
namespace _1_v_1_text_game
{
    class Program
    {
        static void Main(string[] args)
        {
            //int playerStreak = 0;
            Start_Menu(0);
        }
        static void Start_Menu(int playerStreak)
        {

            string weaponPick;
            int minDMG, maxDMG, critMultiplier;
            Console.WriteLine("1: Dagger 4-8 dmg 4x Critical Multiplier");
            Console.WriteLine("2: Short Sword 6-12 3x Critical Multiplier ");
            Console.WriteLine("3: Long Sword 8-16 2x Critical Multiplier");
            Console.Write("Please choose your weapon: ");

            weaponPick = Console.ReadLine();

            //Weapon choice for the player, setting the minDMG, maxDMG, and crit Multiplier
            switch (weaponPick)
            {
                case "1":
                    minDMG = 4;
                    maxDMG = 8;
                    critMultiplier = 4;
                    Console.Write("You have chosen, Dagger! Good Luck!");
                    Console.ReadLine();
                    GamePlay(minDMG, maxDMG, critMultiplier, playerStreak);
                    break;

                case "2":
                    minDMG = 6;
                    maxDMG = 12;
                    critMultiplier = 3;
                    Console.Write("You have chosen, Short Sword! Good Luck!");
                    Console.ReadLine();
                    GamePlay(minDMG, maxDMG, critMultiplier, playerStreak);
                    break;

                case "3":
                    minDMG = 8;
                    maxDMG = 16;
                    critMultiplier = 2;
                    Console.Write("You have chosen, Long Sword! Good Luck!");
                    Console.ReadLine();
                    GamePlay(minDMG, maxDMG, critMultiplier, playerStreak);
                    break;

                default:
                    minDMG = 1;
                    maxDMG = 2;
                    critMultiplier = 1;
                    Console.Write("You have chosen, bare fists! Good Luck!");
                    Console.ReadLine();
                    GamePlay(minDMG, maxDMG, critMultiplier, playerStreak);
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
                if (critCheck == 20) //Adding this in do give a natural 20 something extra.
                {
                    critMultiplier = critMultiplier * critMultiplier;
                    totalDmg = totalDmg * critMultiplier;
                    Console.WriteLine("That was a critical strike! roll was a NAT 20!");
                    return totalDmg;
                }
                else
                {
                    totalDmg = totalDmg * critMultiplier;
                    Console.WriteLine("That was a critical strike! roll was " + critCheck);
                    return totalDmg;
                }
            }
            else
            {
                return totalDmg;
            }


        }
 
       static void GamePlay(int minDMG, int maxDMG, int critMultiplier, int playerStreak) {
                int EnemyHP = 100;
                int PlayerHP = 100;
                int enemyDMG, playerDMG;
                string playerChoice;
                bool GameOver = false, PlayerWin = false;
            Random rand = new Random();
            int enemyMin = rand.Next(1, 8);
            int enemyMax = rand.Next(6, 15);


                ///Gameplay block starts here.
                do
                {
                Console.Write("Please Select an action. 1: Attack 2: Defend  ");
                playerChoice = Console.ReadLine();

                switch (playerChoice)
                {
                    case "1": // Case 1 if the player choses this will attack as normal.
                        playerDMG = damage_calc(minDMG, maxDMG, critMultiplier);
                        EnemyHP = EnemyHP - playerDMG;
                        Console.WriteLine("You delt " + playerDMG + " to the enemy. Enemy HP left " + EnemyHP);
                        enemyDMG = damage_calc(enemyMin, enemyMax, 2);
                        PlayerHP = PlayerHP - enemyDMG;
                        Console.WriteLine("The enemy hits you for " + enemyDMG + " reducing you to " + PlayerHP);
                        break;

                    case "2": // Case 2 if the player chooses this, will take half damage from the enemy
                        Console.WriteLine("You prepare to dodge the attack!");
                        enemyDMG = damage_calc(enemyMin, enemyMax, 2);
                        enemyDMG = enemyDMG / 2; //Dividing the damage in half to start. Might chance it to be random later
                        PlayerHP = PlayerHP - enemyDMG;
                        Console.WriteLine("The enemy hits you for " + enemyDMG + " reducing you to " + PlayerHP);
                        break;


                    default:// Player fails to make a vaild choice they just stand there and take the hit.
                        Console.WriteLine("You just stand there and take the attack.");
                        enemyDMG = damage_calc(enemyMin, enemyMax, 2);
                        PlayerHP = PlayerHP - enemyDMG;
                        Console.WriteLine("The enemy hits you for " + enemyDMG + " reducing you to " + PlayerHP);
                        break;
                }


                    if (EnemyHP <= 0 & PlayerHP >= 1)
                    {
                        GameOver = true;
                        PlayerWin = true;
                    playerStreak++;
                     
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
                    Console.ReadLine();
                    ContinuePick(playerStreak);
                }

                else if (PlayerWin == false)
                {
                    Console.WriteLine("You lose!");
                    Console.ReadLine();
                    ContinuePick(0);
            }
            }
        static void ContinuePick(int playerStreak)
        {
            string playerPick = " ";
            Console.WriteLine("Current Victory Streak: " + playerStreak);
            Console.Write("Would you like to continue? Y/N: ");
            playerPick = Console.ReadLine();

            if (playerPick == "y" || playerPick == "Y")
            {
                Console.WriteLine("Your winning streak is currently at " + playerStreak);
                Start_Menu(playerStreak);
            }

            else if (playerPick == "n" || playerPick == "N")
            {
                Console.WriteLine("See you next time! Total win streak was " + playerStreak);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid response please try again.");
                Console.ReadLine();
                ContinuePick(playerStreak);
            }

        }
    }
}
