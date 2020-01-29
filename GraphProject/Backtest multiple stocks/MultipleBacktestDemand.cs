using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    /// <summary>
    /// This class uses a general rule in trading to calculate the average gain / average loss ratio
    /// needed with a certain win ratio, for the algo to be profitable. It also gives the answer if 
    /// the algo is good enough to PASS your criteria of average of key numbers from all the backtest.
    /// The criterias with tresholds are set as properties of this class.
    /// </summary>
    public class MultipleBacktestDemand
    {
        private MultipleBacktestAnalyser _analyzer;

        // Demands to pass
        private double _AvgMaxDrawDownDemand = 20;
        private double _AvgSharpRatioDemand = 0.8;
        private double _AvgProfitfactorDemand = 2;
        private double _RewardRiskPerformance = 50;
        private double _ProfitableBacktests = 95;
        private int _nbrPass = 5;

        public double RewardRiskDemandRatio { get; set; }
        public double RewardRiskPerformance { get; set; }
        public bool PassOrFail { get; set; }
        public int NbrPass { get; set; }


        public MultipleBacktestDemand(MultipleBacktestAnalyser analyzer)
        {
            _analyzer = analyzer;
        }

        /// <summary>
        /// Calculates the demand of reward / risk ration needed to be profitable
        /// Calculates the actual reward / risk ratio
        /// Calculates if all demands are PASSES or FAILED
        /// </summary>
        public void CalcDemands()
        {
            RewardRiskDemandRatio = CalcRewardRiskDemandRatio();
            RewardRiskPerformance = CalcRewardRiskPerformance();
            PassOrFail = CalcPassOrFail();
        }

        private double CalcRewardRiskDemandRatio() => (1.0 - _analyzer._AverageWinners/100) / (_analyzer._AverageWinners/100) ;
        private double CalcRewardRiskPerformance() => _analyzer._AverageAverageGainAverageLoss / RewardRiskDemandRatio * 100 - 100;

        private bool CalcPassOrFail()
        {
            int nbrPass = 0;
            if (RewardRiskPerformance >= _RewardRiskPerformance)
                nbrPass++;
            if (_analyzer._AverageGainLoss >= _AvgProfitfactorDemand)
                nbrPass++;
            if (_analyzer._AverageSharpRatio >= _AvgSharpRatioDemand)
                nbrPass++;
            if (_analyzer._AverageMaxDrawDown <= _AvgMaxDrawDownDemand)
                nbrPass++;
            if (_analyzer._PercentProfitableBackTests >= _ProfitableBacktests)
                nbrPass++;

            NbrPass = nbrPass;

            return nbrPass == _nbrPass ? true : false;

        }

        public string RewardRiskDemandString()
        {
            return string.Format("Demand:  {0, -5:N1} win%   gives   --->   {1,-5:N2} reward / risk ratio treshold", _analyzer._AverageWinners, RewardRiskDemandRatio);
        }

        public string RewardRiskPerfString()
        {
            var perfString = "";

            if(RewardRiskPerformance > 0)
                perfString = "% higher   --->   profitable";
            else
                perfString = "% lower  --->   not profitable";

            return string.Format("Actual:  {0, -5:N2} reward/risk ratio   gives   --->   {1,-5:N2}  " +   perfString, _analyzer._AverageAverageGainAverageLoss, RewardRiskPerformance);
        }

        public string DemandNbrFilledString()
        {

            return string.Format("Pass or fail:  {0} of 5 demands passed   ---> ",NbrPass);
        }


    }
}
