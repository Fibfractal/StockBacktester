using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphProject
{
    public interface IAlgos 
    {
        bool AlgoBuy(List<DailyDataPoint> dataList, int index);
        bool AlgoSell(List<DailyDataPoint> dataList, int index);
    }
}
