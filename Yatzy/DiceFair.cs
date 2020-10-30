using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yatzy
{

    /// <summary>
    /// This file consists of a simple class for the dice that is fair.
    /// The purpose of this is to have an override for the Roll method.
    /// </summary>

    // Laver en klasse "DiceFair" som relaterer sig til den abstract class "DiceKind". Den abstrakte modifikator i en klassedeklaration indikerer, at en klasse kun er beregnet til at være en baseklasse af andre klasser, som ikke bliver igangsat på egen hånd.
    class DiceFair : DiceKind
    {

        // There is nothing happening here. Er en constructor af klasse DiceFair
        public DiceFair()
        {

        }

        // Is setting a value to a random number between 1 and 6.
        // Access modifier er sat til public, overrider DiceKind.Roll metoden, benytter sig af denne metode til at rulle terningen ved en FairDice. Sætter en lokal variabel "value" og returnerer værdien og kalder på propertien "rand" og metoden "next" (predefineret)
        public override int Roll()
        {
            int value = rand.Next(1, 7);
            return value;

        }
    }
}
