using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

    /// <summary>
    /// This file consists of the class DiceDemonstration which can be used for testing the average roll of the fair dice vs the negatively- and positively biased dice.
    /// Generates a positively- and negatively biased dice, and set their bias degree to 100.
    /// Generates a fair dice. The DiceDemonstration class contains of a method that rolls each dice 500 times, and prints out the average result of these rolls.
    /// </summary>
    
    // Laver en ny klasse "DiceDemonstration"
    class DiceDemonstration
    {


        // Is containing three dice, positiviley- and negatively BiasedDice and a fair dice. There is used 3 doubles for testing.
        // Access modifieren er sat til private da brugeren ikke skal kunne læse eller sætte en værdi af terningen, men blot få vist resultatet af gennemsnitet af 500 terninger der ruller.
        // Kalder på klassen "Dice", og sætter properties til klassen så de kan kaldes på.

        #region Properties

        private Dice positivelyDiceBiased { get; set; }

        private Dice negativelyDiceBiased { get; set; }

        private Dice diceFair { get; set; }

        // "Double" er en grundlæggende datatype indbygger i kompilatoren og bruges til at definere numeriske variabler, der indeholder tal med decimaler. Access modifieren er sat til private. Properties er sat til de angivne navne f.eks. "Average positive"

        private double averagePositive { get; set; }

        private double averageNegative { get; set; }

        private double averageFair { get; set; }

        #endregion



        #region Constructor

        // Starts dice and the average of the doubles. The degree of the biased dice are set to 100. 
        // Access modifieren er sat til public. Kalder på propertiesne og laver nye terninger. Sætter værdierne til pos og neg biased dice. Sætter værdierne af average på terningerne til 0.
        public DiceDemonstration()
        {
            
            diceFair = new Dice();
            positivelyDiceBiased = new Dice();
            negativelyDiceBiased = new Dice();
            positivelyDiceBiased.SetBiased(true, 100);
            negativelyDiceBiased.SetBiased(false, 100);

            averagePositive = 0;
            averageNegative = 0;
            averageFair = 0;
        }

        #endregion

        // A method is used for rolling the pos, neg and fair dice 500 times and write out their average roll. Er en "Actual parameter", da der ikke angives nogen værdier i parantesen ().
        // Laver en metode ved navn "Test" og der kaldes på de forskellige properties der er angivet i constructoren.

        #region Public Methods

        public void Test()
        {
            for (int i = 0; i < 500; i++)
            {
                positivelyDiceBiased.Roll();
                averagePositive += positivelyDiceBiased.value;
                negativelyDiceBiased.Roll();
                averageNegative += negativelyDiceBiased.value;
                diceFair.Roll();
                averageFair += diceFair.value;
            }

            Console.WriteLine(string.Format("The average roll of the FairDice is: {0}\n" +
                "The average roll of the Positively BiasedDice is: {1}\n" +
                "The average roll of the Negatively BiasedDice is: {2}",
                averageFair / 500, averagePositive / 500, averageNegative / 500));
            Console.ReadLine();
        }

        #endregion
    }
}