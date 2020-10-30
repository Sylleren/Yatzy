using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

    /// <summary>
    /// This file contains all dice related classes. It consists of the current value for the dice, what dice kind it is and if the dice is being held or not.
    /// The properties the class Dice consists of are: diceKind, held and value. These are set to be public to read, but set to private.
    /// Consists of public methods to roll the dice, changing the dice kind and for holding the dice.
    /// </summary>


    class Dice
    {

        #region Properties

        // This gives what kind of dice that can be used, either a fair or a biased dice. 
        //Access modifieren er sat til public så alle "get" er public at læse. Kalder på den "abstract class", DiceKind og laver en property "diceKind", så den kaldes senere ned i constructoren.
        // Get er sat til "public at læse", set er "private" så brugeren ikke kan assigne en ny værdi til terningen
        public DiceKind diceKind { get; private set; }


        // If the player is holding the roll or not, it can't be changed back as new the new dices are generated every turn.
        // Public at læse "get", bool = true/false, sætter en ny property "held", så den kan kaldes nede i constructoren, "set" er sat til private så det kun er muligt at holde den samme terning 1 gang pr. runde.
        public bool held { get; private set; }

        // Is giving the current value or the number of the dice.
        // Public at læse "get", integer = tal af terningen, sætter en ny property "value", "set" er private så det ikke er muligt at sætte værdien af ens terning. Oftest sættes "set" til private, når der kun skal læses fra brugerens side.
        public int value { get; private set; }

        #endregion

        #region Constructor 

        // Sets dice to default (Fair dice) and rolls it.
        // Access modifieren er sat til "public" så "Dice" klassen kan kaldes af brugeren. 
        public Dice()
        {
            // This is the default type for the dice. Kalder på propertien "diceKind", som er angivet ovenfor i properties, og sætter værdien "new DiceFair". Kalder på klassen "DiceFair", og laver en ny FairDice som default.
            diceKind = new DiceFair();

            // Not held as default. Held sættes til "false", som betyder at terningen ikke bliver holdt som default. Kalder på propertien "held" og angiver den som "false" som værende default.
            held = false;

            // Is rolling the dice. Kalder på metoden "Roll", som ruller terningen.
            Roll();
        }

        #endregion

        #region Public Methods

        // This override the ToString method. Access modifieren er sat til Public. Sætter den lokale variabel "result", og formatere string med "bla bla" og indsætter værdien af variablen "value" af terningen. 
        // Returner "result" til sidst. Er en "Actual parameter", da der ikke angives nogen værdier i parantesen ().

        public override string ToString()
        {
            string result = string.Format("The value of the dice is currently: {0}", value);
            
            return result;
        }

        // Is changing the DiceKind to a BiasedDice. Access modifieren er sat til Public. Void da metoden ikke returnere nogen værdi. Laver en metode "SetBiased" Dice.SetBiased og sætter nogen formelle parametre "better" og "degree". 
        // Kalder på propertien "diceKind" og kalder på klassen "DiceBiased", og laver en ny Biased Dice, med tilhørende parametre.
        public void SetBiased(bool better, int degree)
        {
            diceKind = new DiceBiased(better, degree);
        }

        // Is changing the DiceKind to a FairDice. Access modifieren er sat til Public. Void da metoden ikke returnere nogen værdi. Laver en metode "SetFair" Dice.SetFair. 
        // Tager propertien diceKind og kalder på klassen "DiceFair", og laver en ny Fair Dice. Er en "Actual parameter", da der ikke angives nogen værdier i parantesen ().
        public void SetFair()
             {
               diceKind = new DiceFair();
             }

        // Is rolling the dice if it is not being held. Access modifieren er sat til Public. Void da metoden ikke returnere nogen værdi. Laver en metode "Roll" Dice.Roll. If (!held) betyder hvis held = false, så rul terningerne der ikke er holdte. 
        // Propertien "value" som er værdien af terningen og "diceKind" som fortæller hvilken slags terning, og tager metoden "Roll" og ruller terningerne. Er en "Actual parameter", da der ikke angives nogen værdier i parantesen ().

        public void Roll()
             {
                 if (!held)
                 {
                value = diceKind.Roll();
                 }
             }

        // Is holding the Dice. Access modifieren er sat til Public. Void da metoden ikke returnere nogen værdi. Laver en metode "Hold" Dice.Hold, som holder terningen. Kalder på propertien "held" og sætter den til at være "true"
        public void Hold()
             {
                 held = true;
             }

             #endregion
    }
}

