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

        private double _avgMaxDrawDownDemand = 20;
        private double _avgSharpRatioDemand = 0.8;
        private double _avgProfitfactorDemand = 2;
        private double _rewardRiskPerformance = 50;
        private double _profitableBacktests = 95;
        private int _nbrPass = 5;

        public MultipleBacktestDemand(MultipleBacktestAnalyser analyzer)
        {
            _analyzer = analyzer;
        }

        public double RewardRiskDemandRatio { get; set; }
        public double RewardRiskPerformance { get; set; }
        public bool PassOrFail { get; set; }
        public int NbrPass { get; set; }

        public void CalcDemands()
        {
            RewardRiskDemandRatio = CalcRewardRiskDemandRatio();
            RewardRiskPerformance = CalcRewardRiskPerformance();
            PassOrFail = CalcPassOrFail();
        }

        private double CalcRewardRiskDemandRatio() => (1.0 - _analyzer._AverageWinners / 100) / (_analyzer._AverageWinners / 100);
        private double CalcRewardRiskPerformance() => _analyzer._AverageAverageGainAverageLoss / RewardRiskDemandRatio * 100 - 100;

        private bool CalcPassOrFail()
        {
            int nbrPass = 0;
            if (RewardRiskPerformance >= _rewardRiskPerformance)
                nbrPass++;
            if (_analyzer._AverageGainLoss >= _avgProfitfactorDemand)
                nbrPass++;
            if (_analyzer._AverageSharpRatio >= _avgSharpRatioDemand)
                nbrPass++;
            if (_analyzer._AverageMaxDrawDown <= _avgMaxDrawDownDemand)
                nbrPass++;
            if (_analyzer._PercentProfitableBackTests >= _profitableBacktests)
                nbrPass++;

            NbrPass = nbrPass;

            return nbrPass == _nbrPass;
        }

        public string RewardRiskDemandString()
        {
            return string.Format("Demand:  {0, -5:N1} win%   gives   --->   {1,-5:N2} reward / risk ratio treshold", _analyzer._AverageWinners, RewardRiskDemandRatio);
        }

        public string RewardRiskPerfString()
        {
            var perfString = "";

            if (RewardRiskPerformance > 0)
                perfString = "% higher   --->   profitable";
            else
                perfString = "% lower  --->   not profitable";

            return string.Format("Actual:  {0, -5:N2} reward/risk ratio   gives   --->   {1,-5:N2}  " + perfString, _analyzer._AverageAverageGainAverageLoss, RewardRiskPerformance);
        }

        public string DemandNbrFilledString()
        {

            return string.Format("Pass or fail:  {0} of 5 demands passed   ---> ", NbrPass);
        }
    }
}
