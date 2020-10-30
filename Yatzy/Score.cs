using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

	/// <summary>
	/// This file keeps track of the players score and has an array of the available score styles the player can score, e.g. Large straight.
	/// </summary>
	
	class Score
	{

		#region Properties

		// Public static array of ScoreStyles (Is static because only one point table can exist per game)
		// Access modifier er sat til public. Er statisk fordi kun et scoreboard kan eksistere pr. spil. Kalder på klassen "ScoreStyle" og definerer propertien pointTable til at læse og skrive
		public static ScoreStyle[] pointTable { get; set; }

		#endregion


		#region Constructor

		//Loads the point Table and adds the fifteen score styles
		// Laver en constructor af klassen "Score", tager propertien pointTable og definere at der skal være 16 ny ScoreStyles. Efter bliver de 16 nye ScoreStyles defineret.
		public Score()
		{
			pointTable = new ScoreStyle[16]
				{
				new ScoreStyle("Ones"),
			new ScoreStyle("Twos"),
			new ScoreStyle("Threes"),
			new ScoreStyle("Fours"),
			new ScoreStyle("Fives"),
			new ScoreStyle("Sixes"),
			new ScoreStyle("One pair"),
			new ScoreStyle("Two pairs"),
			new ScoreStyle("Three of a kind"),
			new ScoreStyle("Four of a kind"),
			new ScoreStyle("Small straight"),
			new ScoreStyle("Large straight"),
			new ScoreStyle("Full house"),
			new ScoreStyle("Chance"),
			new ScoreStyle("Yatzy"),
			new ScoreStyle("Bonus")
				};
		}


		#endregion


		#region Public methods

		// Overrides ToString, and prints each style if they have been scored, and prints the sum at the end
		// Access modifier er public, override ToString metoden, string består af en tekst
		public override string ToString()
		{
			// String (tekststykke) og definerer den lokale variabel result til at være tom
			string result = "";

			// Prints every score if they have already been scored
			// For hver "ScoreStyle", lokal variabel "r" in "pointabel" (property).
			foreach (ScoreStyle r in pointTable)
			{
				//  ÍF r.locked (property) = true, så tag result (lokal variabel) += (Addition assignment operator (Compound operators)) og string formater r (Lokal variabel til ScoreStyle) med label (lokal variabel) på plads 0 og r (Lokal variabel) med points på plads 1.
				if (r.locked == true)
				{
					result += string.Format("{0}: {1}\n", r.label, r.points);
				}
				// Else/ELLERS string formater r (lokal variabel til scorestyle) til label ift. ScoreStyle
				else
				{
					result += string.Format("{0}: \n", r.label);
				}
			}

			// Is adding the sum of the score
			// Tager result += (Addition assignment operator (Compound operators)) og sæt på plads 0 og sæt resultatet ind i summen as scoren
			result += string.Format("-------------------- \nSum: {0}", CalculateScore());
			return result;
		}

		// Is calculating the total sum of the scores in the point table
		// Access modifier er public, static da der kun eksisterer en form for scorer i hvert scoreboard, int da det er et tal. Laver metoden "CalculateScore"
		public static int CalculateScore()
		{
			// Int da det er et tal, definerer en lokal variabel "result" og definerer standard værdien til at være 0. 
			int result = 0;
			// FOREACH /for hver "ScoreStyle"(klasse) r(definerer lokal variabel til ScoreStyle) in "pointTable"(variabel til Score)
 			foreach (ScoreStyle r in pointTable)
			{
				// IF/hvis r (lokal variabel som vi har defineret over) er "locked" (bool, property) == (equal to) "true" så tag "result" (lokal variabel) += (Addition assignment operator (Compound operators)) r (lokal variabel) med r.points og returner result
				if (r.locked == true)
				{
					result += r.points;
				}
			}

			return result;
		}

		#endregion
	}
}


