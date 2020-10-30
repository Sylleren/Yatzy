using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yatzy
{

    /// <summary>
    /// This file consists of two dictionaries available during the upper- and lowersection of the game for selecting the players roll to a ScoreStyle.
    /// The player will at the end of every turn be prompted to select which score they want selected to the point table. While selecting a score, no other commands are available for the player.
    /// Is inheriting playerInput and methods from the prompt file. It overrides the methods.
    /// The SelectRoll class contains what ScoreStyles you can score with your current roll and the calculators for each of these ScoreStyles. 
    ///
    /// </summary>
    
    class SelectRoll : Prompt
    {
        #region Properties

        // This is the dictionary for existing commands in the upper section
        private Dictionary<string, int> inputOpportunitiesSelectUpper = new Dictionary<string, int>();


        // This is the dictionary for existing commands in the lower section
        private Dictionary<string, int> inputOpportunitiesSelectLower = new Dictionary<string, int>();

        #endregion

        #region Constructor 

        // This starts the dictionaries and adds existing commands and calls EvaluateInput which is overrided in this class
        public SelectRoll(string i) : base(i)
        {
            inputOpportunitiesSelectUpper.Add("Select1", 0);
            inputOpportunitiesSelectUpper.Add("Select2", 1);
            inputOpportunitiesSelectUpper.Add("Select3", 2);
            inputOpportunitiesSelectUpper.Add("Select4", 3);
            inputOpportunitiesSelectUpper.Add("Select5", 4);
            inputOpportunitiesSelectUpper.Add("Select6", 5);

            inputOpportunitiesSelectLower.Add("Select7", 6);
            inputOpportunitiesSelectLower.Add("Select8", 7);
            inputOpportunitiesSelectLower.Add("Select9", 8);
            inputOpportunitiesSelectLower.Add("Select10", 9);
            inputOpportunitiesSelectLower.Add("Select11", 10);
            inputOpportunitiesSelectLower.Add("Select12", 11);
            inputOpportunitiesSelectLower.Add("Select13", 12);
            inputOpportunitiesSelectLower.Add("Select14", 13);
            inputOpportunitiesSelectLower.Add("Select15", 14);

            EvaluateInput();

        }

        #endregion


        #region Protected Methods

        // This is a overrided method from Prompt. It adds the dictionary for the current section of the game, showing existing commands
        // Checks to see if the command exists and performs it

        protected override void EvaluateInput()
        {
            // Checks to see if the game is in the upper section
            // If the game is in the upper section, performs existing commands that is in the dictionary
            if (Yatzy.upperSection == true && inputOpportunitiesSelectUpper.ContainsKey(input))
            {
                PerformSelectUpper();
            }

            // Checks to see if the game is in the lower section
            // If the game is in the lower section, perform existing commands that is in the dictionary
            else if (Yatzy.upperSection == false && inputOpportunitiesSelectLower.ContainsKey(input))
            {
                PerformSelectLower();
            }

            // Is printing an error message if command doesn't exist
            else
            {
                Console.WriteLine("Enter an existing command.\n");
            }
        }

        #endregion
        
        

        #region Public Methods

        public static string UpperSectionOpportunities()
        {
            string result = "This is the points you can score with the following roll:\n\n" +
                "Command     Score              Points   \n ";
            for (int k = 0; k < 6; k++)
            {
                if (Score.pointTable[k].locked == false)
                {
                    string label = Score.pointTable[k].label;
                    for (int g = 0; g < 20 - Score.pointTable[k].label.Length; g++)
                    {
                        label += " ";
                    }

                    result += "---------+----------------------+------------\n";
                    string sum = string.Format("Select{0}  | {1} | {2}", (k + 1).ToString(), label, CalculateSingles(k + 1).ToString() + "\n");
                    result += sum;

                }
            }
            return result;
        }

        public static string LowerSectionOpportunities() 
        {
            string result = "This is the points you can score with the following roll:\n\n" +
                "Command     Score              Points\n";
            for (int k = 6; k < 15; k++)
            {
                if (Score.pointTable[k].locked == false)
                {
                    string label = Score.pointTable[k].label;
                    for (int g = 0; g < 20 - Score.pointTable[k].label.Length; g++)
                    {
                        label += " ";
                    }
                    string score = "";

                    switch (k+1)
                    {
                        case 7:
                            score = CalculatePair().ToString();
                            break;

                        case 8:
                            score = CalculateTwoPair().ToString();
                            break;

                        case 9:
                            score = CalculateThreeOAK().ToString();
                            break;

                        case 10:
                            score = CalculateFourOAK().ToString();
                            break;

                        case 11:
                            if (HasSmallStraight() == true)
                            {
                                score = "15";
                            }
                            else
                            {
                                score = "0";
                            }
                            break;

                        case 12:
                            if (HasLargeStraight() == true)
                            {
                                score = "20";
                            }
                            else
                            {
                                score = "0";
                            }
                            break;

                        case 13:
                            score = CalculateHouse().ToString();
                            break;

                        case 14:
                            score = CalculateChance().ToString();
                            break;

                        case 15:
                            score = CalculateYatzy().ToString();
                            break;

                        default:
                            Console.WriteLine("An unexpected thing has happen.");
                            break;

                      
                    }

                    result += "-----------+-----------------+------------\n";
                    string cmd = "";
                    if (k+1 >= 10)
                    {
                        cmd = (k + 1).ToString();
                    }
                    else
                    {
                        cmd = (k + 1).ToString() + " ";
                    }
                    string sum = string.Format("Select{0} | {1} |  {2}", cmd, label, score + "\n");
                    result += sum;

                }
            }

            return result;
        }

        #endregion

        #region Private Methods

        // Is performing a command in the UpperSection

        private void PerformSelectUpper()
        {
            // Is checking that the score of this hand is not already locked
            if (Score.pointTable[inputOpportunitiesSelectUpper[input]].locked != true)
            {
                // Is calculating the points and selects the score
                Score.pointTable[inputOpportunitiesSelectUpper[input]].locked = true;
                Score.pointTable[inputOpportunitiesSelectUpper[input]].points = CalculateSingles(inputOpportunitiesSelectUpper[input] + 1);

                // Is proceeding to the next turn
                Turn.next = true;

            }


            // Is printing an error message if the score has already been locked
            else
            {
                Console.WriteLine("Select your roll to a score that hasn't already been locked.\n");
            }
           
        }

        
        // Is performing an existing command in the lower section
        
        private void PerformSelectLower()
        {

            // Is checking that the score of this hand is not already locked
            if (Score.pointTable[inputOpportunitiesSelectLower[input]].locked != true)
            {

                // Is calculating the points and selects the score
                switch (inputOpportunitiesSelectLower[input])
                {
                    case 6:
                        Score.pointTable[inputOpportunitiesSelectLower[input]].points = CalculatePair();
                        break;

                    case 7:
                        Score.pointTable[inputOpportunitiesSelectLower[input]].points = CalculateTwoPair();
                        break;

                    case 8:
                        Score.pointTable[inputOpportunitiesSelectLower[input]].points = CalculateThreeOAK();
                        break;

                    case 9:
                        Score.pointTable[inputOpportunitiesSelectLower[input]].points = CalculateFourOAK();
                        break;

                    case 10:
                        if (HasSmallStraight() == true)
                        {
                            Score.pointTable[inputOpportunitiesSelectLower[input]].points = 15;
                        }
                        else
                        {
                            Score.pointTable[inputOpportunitiesSelectLower[input]].points = 0;
                        }
                        
                        break;

                    case 11:
                        if (HasLargeStraight() == true)
                        {
                            Score.pointTable[inputOpportunitiesSelectLower[input]].points = 20;
                        }
                        else
                        {
                            Score.pointTable[inputOpportunitiesSelectLower[input]].points = 0;
                        }

                        break;

                    case 12:
                        Score.pointTable[inputOpportunitiesSelectLower[input]].points = CalculateHouse();
                        break;

                    case 13:
                        Score.pointTable[inputOpportunitiesSelectLower[input]].points = CalculateChance();
                        break;

                    case 14:
                        Score.pointTable[inputOpportunitiesSelectLower[input]].points = CalculateYatzy();
                        break;

                    default:
                        Console.WriteLine("An unexpected thing has happen.");
                        break;
                }

                Score.pointTable[inputOpportunitiesSelectLower[input]].locked = true;

                // Is continueing to the next turn
                Turn.next = true;
            }

            // Is printing an error message if the score has already been locked
            else
            {
                Console.WriteLine("Select your roll to a score that hasn't already been locked.\n");
            }

        }

        #region Calculators

        // Is the amount of instances of a specific side or roll
        private static int AmountOf(int side)
        {
            int sum = 0;
            for (int i = 0; i < Turn.ArrayOfDice.Length; i++)
            {
                if (Turn.ArrayOfDice[i].value == side) { sum++; }
            }
            return sum;

        }

        // Is calculating the sum of dices showing a specific side

        private static int CalculateSingles(int side)
        {
            int sum = AmountOf(side) * side;
            return sum;
        }

        // Is calculating the highest available pair for the roll, returns zero if no pair has been rolled

        private static int CalculatePair()
        {
            int sum = 0;
            for (int i = 1; i < 7; i++)
            {
                if (AmountOf(i) >= 2)
                {
                    sum = 2 * i;
                }
            }
            return sum;

        }

        // Is calculating the highest available two pairs for the roll, returns zero if no pair has been rolled
        private static int CalculateTwoPair()
        {
            int firstPair = CalculatePair();
            int secondPair = 0;

            for (int i = 1; i < firstPair / 2; i++)
            {
                if (AmountOf(i) >= 2)
                {
                    secondPair = 2 * i;
                }
                    
            }

            int sum = firstPair + secondPair;
            return sum;
        }

        // Is calculating the highest value for three of a kind for the roll, return zero if no ThreeOAK (Three of a kind)
        private static int CalculateThreeOAK()
        {
            int sum = 0;
            for (int i = 1; i < 7; i++)
            {
                if (AmountOf(i) >= 3)
                {
                    sum = 3 * i;

                }
            }

            return sum;
        }

        // Is calculating the highest value for four of a kind for the roll, return zero if no FourOAK (Four of a kind)
        private static int CalculateFourOAK()
        {
            int sum = 0;
            for (int i = 1; i < 7; i++)
            {
                if (AmountOf(i) >= 4)
                {
                    sum = 4 * i;
                }
                
            }

            return sum;
        }

      

        // Is checking if the player has a small straight
        private static bool HasSmallStraight()
        {
            bool result = true;
            for (int i = 1; i < 6; i++)
            {
                if (AmountOf(i) < 1)
                {
                    result = false;
                }
            }
            return result;
        }

        // Is checking if the player has a large straight
        private static bool HasLargeStraight()
        {
            bool result = true;
            for (int i = 2; i < 7; i++)
            {
                if (AmountOf(i) < 1)
                {
                    result = false;
                }
            }
            return result;
        }


        // Is calculating the highest available housevalue and returns zero if no house has been rolled
        private static int CalculateHouse()
        {
            int sum = 0;
            int threeOf = 0;
            int twoOf = 0;

            // Is finding the highest three of a kind that has been rolled
            for (int i = 1; i < 7; i++)
            {
                if (AmountOf(i) >=3)
                {
                    threeOf = i;
                }
            }

            // Is finding the highest pair that is different from the three of a kind that has been rolled
            for (int i = 1; i < 7; i++)
            {
                if (AmountOf(i) >=2 && i != threeOf)
                {
                    twoOf = i;
                }
            }

            // If two of a kind and three of a kind is different from zero, calculate house and return sum
            if (twoOf != 0 && threeOf != 0)
            {
                sum = threeOf * 3 + twoOf * 2;
            }

            return sum;

        }

        // Is calculating the sum of all the dices
        private static int CalculateChance()
        {
            int sum = 0;
            for (int i = 0; i < Turn.ArrayOfDice.Length; i++)
            {
                sum += Turn.ArrayOfDice[i].value;
            }

            return sum;
        }

        // Is calculating the value of yatzy, either returns the sum or zero if no yatzy has been rolled
        private static int CalculateYatzy()
        {
            int sum = 0;
            for (int i = 1; i < 7; i++)
            {
                if (AmountOf(i) >=6)
                {
                    sum = i * 6;
                }
            }
            return sum;
        }

        #endregion


        #endregion

    }
}