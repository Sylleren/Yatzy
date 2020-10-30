using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

    /// <summary>
    /// The Yatzy class is the class that leads the overall structure of the game.
    /// 
    /// The Yatzy class consists of three public static properties: upperSection, LimitRoll and score. It also contains a private property: ongoingTurn.
    /// upperSection: Is keeping track of which section in the game that currently is being played (See the Yatzy and Turn files for more info).
    /// LimitRoll: Is the number of rolls pr. turn a player has. The default value for how many rolls the player has pr. turn is set to 3. The amount of rolls pr. turn can be changed through the settings at anytime of the game (See the Prompt file for more info).
    /// score: Is keeping track of the different score styles a player can score. It consists of three properties: points, label and locked (See the ScoreStyle file for more info). 
    /// ongoingTurn: Is keeping track of how many turns that has been played in each section. Plays 6 turns in the upper section of the game, and plays 9 turns in the lower section of the game (See the Turn file for more info).
    /// 
    /// The game is being played in the Yatzy constructor. It starts with setting the properties for the class to default values, and plays the six turns in the upper section of the game.
    /// If the player has a score of 63 or more points when the upper section ends after six turns, a bonus of 50 points will be added as the game switches to the lower section of the game.
    /// The lower section of the game consists of nine turns. When the nine turns in the lower section of the game has been played, the Yatzy game has been completed, and the players final score will be printed.
    /// 
    /// The Turn file consists of the turn class which accounts for a big portion of the game's functionality.
    /// It consists of an array of six diceKinds which can be either a fair or a biased dice. The fair dice is set to default, but the player can change and choose which diceKind to use throughout the entire game.
    /// It also consists of a property from the Prompt class, playerInput. PlayerInput keeps track of Hold and Select commands available to the users.
    /// Hold dice is used for holding one or more of the six dice available in the dice array. The player can also continue to roll and view the settings in this prompt (See the DiceHold file).
    /// Select roll is used for selecting which score of your current turn, you want put into the point table. While the player is being prompted to select a score, no other settings is available at this time (See the SelectRoll file).
    /// 
    /// The prompt file consists of the prompt class which contains of dictionaries for what playerInputs are available to the player. If the player writes an existing command for the current options available to them, the command will be executed.
    /// If the player types in a command that doesn't exist in the different dictionaries or if the command is not available in the current section of the game, the player gets an error message (See the Prompt file for more info).
    /// 
    /// All scores are calculated in the SelectRoll file. The SelectRoll class is calculating based on the static dice array in Turn (See SelectRoll file -> Private Methods -> Calculators).
    /// As explained above, the SelectRoll class informs the player of how many points that can be scored for each score style of the current turn, and which command to use to allot the points.
    /// </summary>

  
    class Yatzy

    {
        #region Properties

        //Is checking what section of the game that is currently happening

        public static bool upperSection { get; private set; }

        //The limit of rolls a player can do each turn

        public static int LimitRoll { get; set; }

        //PointTable

        public static Score score { get; set; }

        // The ongoing turn of the game

        private Turn ongoingTurn { get; set; }





        #endregion



        #region Constructor



        // Loads properties and starts the game
        public Yatzy()
        {


            score = new Score();
            LimitRoll = 3;
            upperSection = true;
            Console.WriteLine("Welcome, you are about to start a game of yatzy!\n\nPress any button and press enter to start the game...");
            Console.ReadLine();



            // Plays the six turns in the upper section

            for (int i = 0; i < 6; i++)
            {
                ongoingTurn = new Turn();
            }

            // Switches to play the lowerSection and adds 50 point if the player has 63 points or more when they have finished the upper section of the game

            upperSection = false;
            if (Score.CalculateScore() >= 63)
            {
                Score.pointTable[15].locked = true;
                Score.pointTable[15].points = 50;
            }

            // Plays the nine turns in the lower section

            for (int i = 0; i < 9; i++)
            {
                ongoingTurn = new Turn();
            }

            // Prints the final score of the game

            Console.Clear();
            Console.WriteLine("Hope you enjoyed the game!\n" + "\nYou have finished the game with the following scores:\n\n");
            Console.WriteLine(score.ToString());
            Console.WriteLine("\n\nPres any button to close the game...");
            Console.ReadLine();
        }


        #endregion


    }
}