using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class is a helper class to the RSI class. The last
    /// average gain and loss needs to be stored for the RSI to
    /// be calculated. Objects of this class can be stored in 
    /// list.
    /// </summary>
    public class RsiManager
    {
        public double LastAverageGain { get; set; }
        public double LastAverageLoss { get; set; }
    }
}
