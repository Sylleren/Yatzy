using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

    /// <summary>
    /// This file consists of the flow of a turn, a prompt for playerInput and an array of the six dice.
    /// The Turn class also contains of private methods for rolling all the dice and for the program flow for the upper- and lower section.
    /// </summary>
    
    class Turn
    {
        #region Properties

        // This is the dice used to play the turn
        public static Dice[] ArrayOfDice { get; set; }

        // Bool that is being used by the prompt, indicating the player may continue the program flow

        public static bool next { get; set; }

        // The prompt used for when a player input is needed, is always generated as a new Prompt when it is used

        private Prompt playerInput { get; set; }

        #endregion


        #region Constructor

        // Generates the dice and plays the relevant turn
        public Turn()
        {
            next = false;

            // Starts the dice array
            ArrayOfDice = new Dice[6];
            for (int i = 0; i < ArrayOfDice.Length; i++)
            {
                ArrayOfDice[i] = new Dice();
            }


            // Plays the turn
            TurnProcess();
        }

        #endregion


        #region Public methods

        //ToString override
        public override string ToString()

        {

            string sum = "Your rolls are:\n" +
                "Dice number | 1 | 2 | 3 | 4 | 5 | 6 |\n" +
                "------------+---+---+---+---+---+---+\n" +
                "Dice value  |";
            for (int i = 0; i < ArrayOfDice.Length; i++)
            {
                if (ArrayOfDice[i].held == true)
                {
                    sum += "[" + ArrayOfDice[i].value + "]|";
                }
                else
                {
                    sum += " " + ArrayOfDice[i].value + " |";
                }
            }
            return sum;
        }

        #endregion

        #region Private methods

        // Is rerolling the dice
        private static void Roll()
        {

            for (int i = 0; i < ArrayOfDice.Length; i++)

            {
                ArrayOfDice[i].Roll();
            }
        }

        // The Program flow of an upperSection turn
        private void TurnProcess()
        {
            string input;
            

            // Rolls a time according to the limit roll from the Yatzy file. All dices will be rolled from the beginning when they are created, meaning that the first roll of every turn is an auto roll..
            for (int i = 1; i <Yatzy.LimitRoll; i++)

            {
                // Is printing the current status of the turn in Console
                int rollsLeft = Yatzy.LimitRoll - i;
                Console.Clear();
                Console.WriteLine(Yatzy.score.ToString() + "\n");
                Console.WriteLine(this.ToString() + "\n");
                Console.WriteLine("You have " + rollsLeft.ToString() + " rolls left.\n");
                Console.WriteLine(HoldDice.OpportunitiesHold());

                // Is Prompting the player for input till Prompt playerInput changes next to true
                while (!next)

                {
                    input = Console.ReadLine();
                    playerInput = new HoldDice(input);
                }
                Roll();
                next = false;
            }

            // Is printing the current status of the turn and shows the player their opportunities for what score they can choose to score
            Console.Clear();
            Console.WriteLine(Yatzy.score.ToString() + "\n");
            Console.WriteLine(this.ToString() + "\n");
            Console.WriteLine("You have 0 rolls left.\n");

            if (Yatzy.upperSection == true)

            {
                Console.WriteLine(SelectRoll.UpperSectionOpportunities());
            }
            else
            {
                Console.WriteLine(SelectRoll.LowerSectionOpportunities());
            }

            // Is Prompting the player for input till Prompt playerInput changes next to true
            while (!next)

            {
                input = Console.ReadLine();
                playerInput = new SelectRoll(input);
            }
            next = false;
        }

        #endregion
    }
}