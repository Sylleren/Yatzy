using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

    /// <summary>
    /// This file consists of the Prompt class which handles the player input in the settings menu. It has two children: HoldDice and SelectRoll.
    /// Contains a protected property for the players input, a dictionary for existings commands for playerInput and the opportunities the player has in the settings.
    /// Contains of two methods, one method to evaluate if the playerInput exists, and one method for executing the setting commands.
    /// </summary>


    // Laver klasen "Prompt"
    class Prompt
    {
        #region Properties

        // String that the player has typed in. 
        // Access modifier er protected, string betyder at værdien er tekst (tal og bogstaver), instans variabel er input som sørger for brugerens input, properties get og set.
        protected string input { get; set; }

        // The dictionary for existing settings commands that a player can type.
        // Access modifier er protected, laver et Dictionary bestående af string og int. Sætter instans variablen til "InputOportunitiesSettings", properties get og set.

        protected Dictionary<string, int> inputOpportunitiesSettings { get; set; }

        // The dictionary for existing general commands a player can type
        // Access modifier er protected, laver et Dictionary bestående af string og int. Sætter instans variablen til "InputOportunitiesPrime", properties get og set.

        protected Dictionary<string, int> inputOpportunitiesPrime { get; set; }


        #endregion



        #region Constructor

        // Is setting the player input and creates the dictionaries of commands available for the player
        // Laver en constructor af klassen "Prompt". Access modifier er public. Består af en string, hvor parameteret sættes til "i". Sætter lokal variablen til at parameteret skal være = i
        public Prompt(string i)
        {
            input = i;

            // Laver lokal variablen inputOpportunitiesPrime og laver et nyt dictionary med string og int indeholdende de primære kommandoer såsom settings og roll.
            inputOpportunitiesPrime = new Dictionary<string, int>();
            inputOpportunitiesPrime.Add("Settings", 0);
            inputOpportunitiesPrime.Add("Roll", 1);

            // Laver lokal variablen inputOpportunitiesSettings og laver et nyt dictionary med string og int indeholdende de kommandoer der kan tilgås i settings.
            inputOpportunitiesSettings = new Dictionary<string, int>();
            inputOpportunitiesSettings.Add("SetLimitRoll", 0);
            inputOpportunitiesSettings.Add("Set1Fair", 1);
            inputOpportunitiesSettings.Add("Set2Fair", 2);
            inputOpportunitiesSettings.Add("Set3Fair", 3);
            inputOpportunitiesSettings.Add("Set4Fair", 4);
            inputOpportunitiesSettings.Add("Set5Fair", 5);
            inputOpportunitiesSettings.Add("Set6Fair", 6);
            inputOpportunitiesSettings.Add("Set1Bias", 7);
            inputOpportunitiesSettings.Add("Set2Bias", 8);
            inputOpportunitiesSettings.Add("Set3Bias", 9);
            inputOpportunitiesSettings.Add("Set4Bias", 10);
            inputOpportunitiesSettings.Add("Set5Bias", 11);
            inputOpportunitiesSettings.Add("Set6Bias", 12);
            inputOpportunitiesSettings.Add("Back", 13);
        }

        #endregion

        #region Protected methods

        // Is checking wether the player input is an existing command or not, and performs it if the command does exist
        // Access modifier er protected, virtual da det er en metode, der kan omdefineres i "derived" klasser, retur typen VOID som specificere at metoden ikke returnerer en værdi. Laver metoden "EvaluateInput".

        protected virtual void EvaluateInput()
        {

            // Is checking wether or not the input is in the dictionary
            // Hvis inputOpportunitiesPrime indeholder Tkey og Tvalue som er specificeret i metoden "ContainsKey" stemmer overens med brugerens input
            if (inputOpportunitiesPrime.ContainsKey(input))

            {

                // Is performing the relevant command typed by the player
                // Hvis inputOpportunitiesPrime og brugerens input er == (equality operator) 0 (SetLimitRoll kommando), så benyt metoden "PerformSettings".
                if (inputOpportunitiesPrime[input] == 0)
                {
                    PerformSettings();
                }
                // Ellers hvis inputOpportunities og brugerens input er == (equality operator) 1 (Set1Fair kommando), så sæt klassen "Turn" og lokal variablen variablen "next" til at værende true.
                else if (inputOpportunitiesPrime[input] == 1)
                {
                    Turn.next = true;
                }
            }

            // Is the error message given to the player, if the command is not in the dictionary
            // Ellers skriv ud "Enter an existing command" hvis kommandoen ikke eksisterer i dictionary

            else

            {
                Console.WriteLine("Enter an existing command\n");
            }

            // "Return" afslutter udførelsen af ​​den metode, hvori den vises, og returnerer kontrol til opkaldsmetoden
            return;
        }

        // Is performing one of the settings command
        // Access modifier er protected. VIRTUAL da det er en metode, der kan omdefineres i "derived" klasser, retur typen VOID som specificere at metoden ikke returnerer en værdi. Laver metoden "PerformSettings"
        protected virtual void PerformSettings()
        {

            // Is checking if the input exist in the dictionary. Must doublecheck because this method can be called directly from HoldDice
            // Hvis inputOpportunitiesSettings (benytter metoden -->) ContainsKey (Tkey og Tvalue) ift. brugerens input
            if (inputOpportunitiesSettings.ContainsKey(input))
            {

                // Is performing the command that is called
                // Is performing the LimitRoll setting
                // Hvis inputOpportunitiesSettings [input] == 0 (SetLimitRoll kommando), så int, lokal variable "rolls" = 3 og bool, lokal variable "conversion" = false, mens
                if (inputOpportunitiesSettings[input] == 0)
                {
                    int rolls = 3;
                    bool conversion = false;

                    // Is prompting the new LimitRoll untill the player provides an int
                    // Mens ! er = (Unary ! (logical negation) operator) beregner logical negation af dens operand. Det vil sige, at operanten producere sandt hvis den er falsk, og falsk hvis operanden evalueres til sandt. EKSTRA (Er en null-forgiving operator).
                    // Lokal variabel conversion
                    while (!conversion)
                    {
                        // Console.WriteLine "What are the amount of..", string bestående af et tekst stykke, lokal variable "ind", Console.ReadLine (venter på input fra brugeren). Conversion = Int32 (Represents a 32-bit signed integer)
                        // Tager metoden TryParse som --> (Converts the string representation of a 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded). Tager den lokale variabel "ind", som modtager bruger inputtet
                        // og spytter (out) antal rolls (lokal variabel) ud brugeren har defineret.
                        Console.WriteLine("\nWhat are the amount of rolls you would like pr. turn?\n");
                        string ind = Console.ReadLine();
                        conversion = Int32.TryParse(ind, out rolls);
                    }
                    // Sætter Yatzy.LimitRoll til antal rolls brugeren har defineret pr. tur.
                    Yatzy.LimitRoll = rolls;

                    // Is printing the confirmation message of the LimitRoll command

                    Console.WriteLine("\nThe amount of rolls pr. turn is changed to " + rolls.ToString() + ".\n" + "\nYou now have the following opportunities:\n" + "\nIf you want to roll again, type: Roll\n" +
                          "If you want to hold a dice, type: Hold#\n" +
                          "If you want to change the settings again, type: Settings\n");

                }

                // Is performing the SetFair command
                // Ellers hvis brugerens input er mellem 1 && (AND) og 6 (SetFair kommando) så tag klassen "Turn" og variablen "ArrayOfDice" -1 ift. den terning der skal sættes til Fair

                else if ((inputOpportunitiesSettings[input] > 0) && (inputOpportunitiesSettings[input] < 7))
                {
                    Turn.ArrayOfDice[inputOpportunitiesSettings[input] - 1].SetFair();

                    // Is printing the confirmation message of the SetFair command

                    Console.WriteLine("\nDice #" + inputOpportunitiesSettings[input].ToString() + " is now set to a fair dice.\n" + "\nYou now have the following opportunities:\n" + "\nIf you want to roll again, type: Roll\n" +
                         "If you want to hold a dice, type: Hold#\n" +
                         "If you want to change the settings again, type: Settings\n");

                }

                // Is performing the SetBiased command
                // Ellers hvis brugerens input er mellem 7 && (AND) og 12 (SetBias kommando) så sæt bool værdierne "better" og "conversion" til at være false
                else if ((inputOpportunitiesSettings[input] > 6) && (inputOpportunitiesSettings[input] < 13))
                {
                    bool better = false;
                    bool conversion = false;

                    // Is prompting wether the BiasedDice should be positive or negative till the player provides a bool (true or false)
                    // Mens ! er = (Unary ! (logical negation) operator) beregner logical negation af dens operand. Det vil sige, at operanten producere sandt hvis den er falsk, og falsk hvis operanden evalueres til sandt. EKSTRA (Er en null-forgiving operator).

                    while (!conversion)
                    {
                        // Console.WriteLine "Do you want the dice to...", string bestående af et tekst stykke, lokal variable "ind", Console.ReadLine (venter på input fra brugeren). Conversion (lokal variabel). Bool (true or false statement)
                        // Tager metoden TryParse som --> (Tries to convert the specified string representation of a logical value to its bool equivelant. A return value indicates whether the conversion succeeded).
                        // Tager den lokale variabel "ind", som modtager bruger inputtet og spytter (out) better (som er en bool, og en lokal variabel) ud brugeren har defineret.
                        Console.WriteLine("\nDo you want the dice to do better (write 'true') or do you want the dice to do worse (write 'false')?\n");
                        string ind = Console.ReadLine();
                        conversion = bool.TryParse(ind, out better);
                    }

                    // Sætter degree (INT, tal) = 0, og conversion = false
                    int degree = 0;
                    conversion = false;

                    // Is prompting the degree of how bias the dice should be untill the player provides an int
                    // Mens ! er = (Unary ! (logical negation) operator) beregner logical negation af dens operand. Det vil sige, at operanten producere sandt hvis den er falsk, og falsk hvis operanden evalueres til sandt. EKSTRA (Er en null-forgiving operator).
                    while (!conversion)
                    {
                        // Tager den lokale variabel "ind", som modtager bruger inputtet og spytter (out) degree (som er en int, og en lokal variabel) ud brugeren har defineret.
                        Console.WriteLine("\nOn a scale from 1 to 100, which amount do you want the dice to do better or worse?\n");
                        string ind = Console.ReadLine();
                        conversion = Int32.TryParse(ind, out degree);
                    }

                    // Is changing dice kind to a biased dice, and prints confirmation message
                    // Kalder på klassen "Turn" og variablen "ArrayOfDice" samt InputOpportunitiesSettings og tager brugerens input og -6 ift. den terning der skal sættes til biased. Tager variablerne better og degree ift. hvad brugeren har angivet.

                    Turn.ArrayOfDice[inputOpportunitiesSettings[input] - 6].SetBiased(better, degree);
                    Console.WriteLine("\nDice #" + (inputOpportunitiesSettings[input] - 6).ToString() + " is now set to be a biased dice" + "\n\nYou now have the following opportunities:\n" + "\nIf you want to roll again, type: Roll\n" +
                "If you want to hold a dice, type: Hold#\n" +
                "If you want to change the settings again, type: Settings\n");

                }

                // Is printing the opportunities again if the player goes back
                // Ellers hvis input brugeren giver er = 13 (go back kommando), skriv de muligheder brugeren har ud der ligger i klassen HoldDice og metoden OpportunitiesHold

                else if (inputOpportunitiesSettings[input] == 13)
                {
                    Console.WriteLine(HoldDice.OpportunitiesHold());
                }
            }

            // An error message for when the player has not entered an existing command

            else
            {
                Console.WriteLine("Enter an existing command.\n");
                input = Console.ReadLine();
                PerformSettings();
            }
        }

        #endregion

    }
}
