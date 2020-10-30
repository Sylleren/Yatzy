using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{

    /// <summary>
    /// This file keeps track of every ScoreStyle.
    /// The properties of ScoreStyle consists of: points, label and locked  
    /// The default value of points is set to zero and locked is set to false in the constructor.
    /// </summary>
     // Laver en ny klasse "ScoreStyle"
    class ScoreStyle
    {

        #region Properties

        // How many points that has been scored in the style
        // Access modifier er public, int (tal), laver en property "Points", properties get og set er public
        public int points { get; set; }

        // The label of the style in the point table
        // Access modifier er sat til public, består af en string, laver en property "Label", properties get er public og set er private
        public string label { get; private set; }

        // A bool that tells if the score has been scored or not, making it possible to "drop" styles and give them a zero score
        // Access modifier er sat til public, består af en bool værdi (true eller false), laver en property "Locked", hvor propertisne get og set er public.
        public bool locked { get; set; }

        #endregion

        #region Constructor

        // Is setting the label to the parameter l and the default values of locked and points is set.
        // Laver en constructor af klassen "ScoreStyle", sætter label's parametere til at være "l", locked som værende falske, og points være lig 0 som default values (alle sammen properties, label, locked, points).
        public ScoreStyle(string l)
        {
            label = l;
            locked = false;
            points = 0;
        }

        #endregion

        #region Public methods

        // This Overrides ToString
        // Access modifier er sat til public. Override string metoden. Returnere propertien "Label"
        public override string ToString()
        {
            return label;
        }

        #endregion
    }
}