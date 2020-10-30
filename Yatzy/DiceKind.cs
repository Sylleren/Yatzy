using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

    /// <summary>
    /// This file consists of an abstract class for the different dice kinds which contains a Random object to RNG (Random Number Generator) for the different dice kinds.
    /// Fair dice and Biased dice is able to override.
    /// 
    /// </summary>

    // Laver en abstract class "DiceKind". En abstrakt klasse er en speciel type klasse, der ikke kan instantieres. En abstrakt klasse er designet til at blive arvet af underklasser, der enten implementerer eller "overrider" dens metoder
    abstract class DiceKind
    {
        #region Properties

        // This seed was found on Stackoverflow, it is a random generator used to roll the dice.
        // Access modifier er sat til protected. Kalder på klassen "Random" som er defineret ved System.Random og sætter propertien til "rand". Laver en ny "Random" og igangsætter en ny instans af "GUID" strukturen ved metoden (Guid.NewGuid), og returnere hash koden 
        // af instansen ved metoden (GetHashCode)
        protected Random rand = new Random(Guid.NewGuid().GetHashCode());

        #endregion

        #region Public Methods

        // If a dice is rolled with no specific DiceKind 1 is returned
        // Access modifier er sat til Public, virtual da det er en metode, der kan omdefineres i "derived" klasser, da der eksistere flere forskellige slags terninger.

        public virtual int Roll()
        {
            // Is returning 0 so that the Yatzy class can throw an exception if a dice doesn't have a DiceKind
            return 0;
        }

        #endregion
    }
}
