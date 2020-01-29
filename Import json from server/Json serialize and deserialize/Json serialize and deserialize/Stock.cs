using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_serialize_and_deserialize
{
    public class Stock
    {
        //public string StockName { get; set; }
        public string symbol { get; set; }
        //public double open { get; set; }
        //public double high { get; set; }
        //public double low { get; set; }
        public StockData[] historical { get; set; }
        //public double volume { get; set; }
        //public double unadjustedVolume { get; set; }
        //public double change { get; set; }
        //public double changePercent { get; set; }
        //public double vwap { get; set; }
        //public double label { get; set; }
        //Spublic double changeOverTime { get; set; }



        /*
         * "date": "2014-12-09",
        "open": 110.19,
        "high": 114.3,
        "low": 109.35,
        "close": 114.12,
        "volume": 60208000,
        "unadjustedVolume": 60208000,
        "change": -3.93,
        "changePercent": -3.567,
        "vwap": 112.59,
        "label": "December 09, 14",
        "changeOverTime": -0.03567
         * 
         */
    }
}
