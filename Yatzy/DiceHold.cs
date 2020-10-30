using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

    /// <summary>
    /// This file consists of a new dictionary for handling the HoldDice commands.
    /// It's also handling the prompts in between rolls, with the exception of when a player needs to select the roll from their turn and assign it to their point board (See SelectRoll file for this).
    /// Is inheriting input and methods from the Prompt file but is overriding the methods.
    /// </summary>
    
        // Laver en ny klasse "HoldDice" som relaterer sig til klassen "Prompt".
    class HoldDice : Prompt
    {
        #region Properties

        // The dictionary for the Hold commands. 
        // Angiver et nyt protected dictionary med propertien "inputOpportunitiesHold" som består af en string og en int. 
        // Access modifieren er sat til "protected", dvs. koden kun kan tilgås i den samme klasse eller struktur eller i den "Derrived class"
        protected Dictionary<string, int> inputOpportunitiesHold { get; set; }

        #endregion




        #region Constructor

        // This defines the Hold dictonary. Takes EvaluateInput which is overrided by prompt. 
        // Access modifieren er sat til public. Constructor "HoldDice" bliver lavet. Angiver parameteret "i" til string og base. Laver et nyt "Dictionary" til "Hold" funktionerne. 
        // EvaluateInput som er en "void" metode, da det er en metode som ikke returnere noget, bliver overridet af prompt.

        public HoldDice(string i) : base(i)
        {
            inputOpportunitiesHold = new Dictionary<string, int>();
            inputOpportunitiesHold.Add("Hold1", 1);
            inputOpportunitiesHold.Add("Hold2", 2);
            inputOpportunitiesHold.Add("Hold3", 3);
            inputOpportunitiesHold.Add("Hold4", 4);
            inputOpportunitiesHold.Add("Hold5", 5);
            inputOpportunitiesHold.Add("Hold6", 6);

            EvaluateInput();
        }


        #endregion

        #region Protected methods

        // This overrides the Prompt as commands from the Hold dictionary are valid here
        // Access modifieren er sat til protected, overrides "Prompt" da kommandoer fra mit "Hold dictionary" er valide her. Er en "Actual parameter", da der ikke angives nogen værdier i parantesen ().

        protected override void EvaluateInput()
        {

            // This checks if the command exists in the Prime dictionary
            // If.. else if.. else.. statement. Den første "If" checker om kommandoerne eksistere i Prime dictionary. Tager metoden "ContainsKey" som er predefineret med "Tkey, Tvalue", og checker ift. det input spilleren angiver.
            if (inputOpportunitiesPrime.ContainsKey(input))
            {


                // Continues the turn if the player wants to roll
                // Fortsætter turen hvis spilleren vil "rulle" terningerne ved at benytte "==" (equality) operatoren, så hvis inputoptionsprime == 1 (Roll kommando), kan brugeren fortsætte ved "Roll" kommandoen. Kalder på klassen "Turn" med variablen "next"
                // som er en bool value, og sætter den til at være "true" som så fortsætter turen
                if (inputOpportunitiesPrime[input] == 1)
                {
                    Turn.next = true;
                }


                // Is showing the settings
                // Viser settings brugeren har adgang til ved at benytte "==" (equality) operatoren, så hvis inputoptionsprime == 0 (Settings kommando), viser programmet de settings brugeren har adgang til (F.eks. SetFair, SetBiased,SetLimitRoll) ved metoden PromptSettings
                else if (inputOpportunitiesPrime[input] == 0)
                {
                    PromptSettings();
                }
            }


            // Is checking wether the command exists or not in the Hold dictionary and performs it
            // checker om kommandoerne eksistere i Hold dictionary. Tager metoden "ContainsKey" som er predefineret med "Tkey, Tvalue", og checker ift. det input spilleren angiver. Hvis kommanden eksisterer udføres den igennem metoden "PerformHoldInput"
            else if (inputOpportunitiesHold.ContainsKey(input))
            {
                PerformHoldInput();
            }


            // Sends an error message if input doesn't exist in dictionary
            else
            {
                Console.WriteLine("Enter an existing command. \n");
            }

        }


        #endregion


        #region Public Methods

        // Is returning a string with the opportunities for a HoldRoll prompt
        // Access modifier er sat til public, static da den relaterer sig til selve typen, snarere end et eksempel af typen, string da værdien er tekst. Laver en metode "OpportunitiesHold" med teksten af strengen. Returnere sum til sidst.
        // Er en "Actual parameter", da der ikke angives nogen værdier i parantesen ().
        public static string OpportunitiesHold()
        {
            string sum = "This is the opportunities you have. The # needs to be exchanged with the dice you want to interact with: \n\n" +
                "If you want to roll again, type: Roll\n" +
                "If you want to hold a dice, type: Hold#\n" +
                "If you want to change the settings, type: Settings\n";
            return sum;
        }



        #endregion

        #region Private Methods

        // Is printing the opportunities available for the player in settings, and asks for new input and performs it
        // Access modifier er sat til private, void da metoden ikke returnere nogen værdi, laver metoden "PromptSettings" igennem en console.WriteLine. Er en "Actual parameter", da der ikke angives nogen værdier i parantesen ().
        private void PromptSettings()
        {
            Console.WriteLine("\nThis is the settings. The # needs to be exchanged with the dice you want to interact with:\n\n" +
                "If you want a dice to be a fair dice, type: Set#Fair\n" +
                "If you want a dice to be a biased dice, type: Set#Bias\n" +
                "If you want to change the limit of rolls pr. turn, type: SetLimitRoll\n" +
                "If you want to go back, type: Back\n");

            // Læser brugerens input
            input = Console.ReadLine();


            // Is performing the command as a setting
            // Kalder på metoden PerformSettings
            PerformSettings();
        }


        // Is performing a Hold command from playerInput
        // Access modifier er sat til private, void da metoden ikke returnere nogen værdi. Er en "Actual parameter", da der ikke angives nogen værdier i parantesen(). Kalder på klassen "Turn" og variablen "ArrayOfDice" og tager inputOpportunitiesHold og
        // minuser med -1 (- substraction operator), dvs. ternings 1 navn reelt er 0, men brugeren ser det som terning 1, og kalder på "Hold" metoden. 
        private void PerformHoldInput()
        {
            Turn.ArrayOfDice[inputOpportunitiesHold[input] - 1].Hold();
            Console.WriteLine("Dice #" + (inputOpportunitiesHold[input]).ToString() + " is being held.\n");
        }

        #endregion



    }
}    