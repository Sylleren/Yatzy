using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

    /// <summary>
    /// Go to the Yatzy file to see a complete summary of the game.
    /// 
    /// Can be used for testing the average roll of a fair dice VS a positively/negatively biased dice.
    /// Calls the class "DiceDemonstration" and the method "Test"
    /// There is two static void, Main01 and Main. Exchange Main01 with Main and vice versa to run the DiceDemonstration.
    /// </summary>


    // Laver en ny class "Program" som indeholder to static void.
    // STATIC En statisk metode i C # er en metode, der kun opbevarer en kopi af metoden på Type-niveau, ikke objektniveau. Det betyder, at alle forekomster af klassen deler den samme kopi af metoden og dens data. 
    // Den sidst opdaterede værdi af metoden deles mellem alle objekter af den type.

    // VOID Retur typen specificere at metoden ikke returnerer en værdi. Og da en metode der er erklæret med en "void" retur type ikke kan give nogen argumenter
    // til nogen statements de indeholder, er det en void.

    // Metoden "Main" nedenfor er indgangspunktet for et eksekverbart program; det er her programstyringen starter og slutter.
    // Main erklæres inden for en klasse eller struktur. Main skal være statisk, og den behøver ikke være offentlig.

    class Program
    {

        // Is testing the BiasedDice and FairDice and changing dicetype on run-time
        // Forklaring af static og void ovenover. Laver metoden "Main01". 
        // Nøgleordet "var" bruges til at erklære en variabel af typen, som i dette tilfælde bliver kaldt "demo". Laver en ny instans af DiceDemonstration, og kalder på den variablen "Demo" der lige er blevet lavet, og kalder på metoden "Test".
        static void Main01(string[] args)
        {
            var demo = new DiceDemonstration();
            demo.Test();
        }


        // Forklaring af static void øverst. Lavet metoden "Main".
        // "Try" indeholder den beskyttede kode, der kan forårsage undtagelsen. Blokken udføres, indtil en undtagelse kastes, eller den er afsluttet med succes.
        // "Catch" Når en undtagelse kastes, søger common language runtime (CLR) efter catch statement, der håndterer denne undtagelse.
        static void Main(string[] args)
        {
            // Starts a Yatzy game. If any exceptions are given the player is prompted to restart the yatzy game.
            try
            {
                var game = new Yatzy();
            }
            catch
            {
                Console.WriteLine("An unexpected error has occured. Please restart the game.");
                Console.ReadLine();
            }
        }
    }
}



