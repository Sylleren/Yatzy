using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yatzy
{

	/// <summary>
	/// This file consists of a biased dice which can either be positively- or negatively biased.
	/// It contains a property for if the dice is positively (true) or negatively (false) biased, and a property for the degree of how positively- or negatively biased the dice is.
	/// </summary>

    // Laver en ny klasse "DiceBiased" som relatere sig til klassen "DiceKind". 
	class DiceBiased : DiceKind
    {
		#region Properties

		// Is showing the degree of how biased the dice is. 
		// Access modifieren er sat til Public da brugeren både skal kunne læse og sætte værdien af "degree". Integer, dvs. at den kræver et tal fra brugeren. Sætter propertien til = "Degree"
		public int degree { get; set; }

		//  Is true if the dice is positively biased and is false if the dice is negatively biased. 
		// Access modifieren er sat til Public da brugeren både skal kunne læse og sætte værdien af "better". 
		// Bool da DiceBiased enten er "positively (true)" eller "negatively (false)" biased. Sætter en property = "Better"
		public bool better { get; set; }

		#endregion

		#region Constructor

		// Starts the properties of the given value set by the player. True makes the dice positively biased and false makes it negatively biased. The degree can be set from 1-100, where 100 is "max" biased.
		// Access modifieren er sat til Public da brugeren både skal kunne læse og sætte værdien af "better" og "degree", better bliver sat til parameteret "b", og degree bliver sat til parameteret "d".
		public DiceBiased(bool b, int d)
        {
			better = b;
			degree = d;
        }

		#endregion

		#region Public Methods

		// Access modifieren er sat til Public. "Override" da terningen er biased og skal implementeres af et "member" der er arvet fra en "base class". Er en "Actual parameter", da der ikke angives nogen værdier i parantesen ().
		public override int Roll()
        {
			// Is rolling the dice. 
			// Int da det er et tal. Sætter en lokal variabel "result" og genererer en værdi af terningen eller terningerne mellem 1 og 6. Kalder på propertien "rand" og metoden "next" (prædefineret)

			int result = rand.Next(1, 7);

			// If the dice is positively biased, and the roll is 3 or below, there is a chance of this method redoing
			if (better && result <=3)
            {
				if (rand.Next(1, 26)*result < degree)
                {
					result = Roll();
                }

            }

			// Is doing the same as above. If the dice is negatively biased, and the dice rolls 4 or above, there is a chance of this method redoing
			else if (!better && result >= 4)
			{
				if (rand.Next(1, 26) * (result-3) < degree)
                {
					result = Roll();
                }
			}

			return result;

		}
        #endregion 
    }
}



