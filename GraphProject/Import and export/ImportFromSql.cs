using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GraphProject
{
    /// <summary>
    /// This class imports data from SQL.
    /// Methods can import a list of objects with price and date from one stock at a time.
    /// </summary>
    public class ImportFromSql
    {
        public List<DailyDataPoint> ImportStockData(string stockTicker)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DBName")))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    return connection.Query<DailyDataPoint>("select date,[close] from " + stockTicker + "1").ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong during import from SQL");
                return null;
            }
        }

        public bool VerifyData(List<DailyDataPoint> dataList)
        {
            if (dataList.Count == 0)
                throw new ArgumentNullException("The list is empty!");

            int nbrClose = 0;
            int nbrDateTime = 0;
            int nbrPoints = dataList.Count;

            foreach (var item in dataList)
            {
                if (item.Close > 0)
                    nbrClose++;
                if (item.Date != null)
                    nbrDateTime++;
            }

            return (nbrPoints == nbrClose) && (nbrPoints == nbrDateTime);
        }
    }
}
