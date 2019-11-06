using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GraphProject
{
    public class ImportFromSql : IImportData
    {

        public List<DailyDataPoint> ImportData()
        {
            // var output = connection.Query<Person>("dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DBName")))
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                // Dapper cant Query Interfaces!! Throws argument exception.
                // Dapper cant Query other data types other than string, when using data procedures in SQL. That to prevent sql injection attack
                return connection.Query<DailyDataPoint>("select _Open,_High,_Low,_Close,_MilliSeconds from DataPointDaily").ToList();
                //return connection.Query<DailyDataPoint>("select _Close from RSI").ToList();
            }
        }

        public bool VerifyData(List<DailyDataPoint> dataList)
        {
            if (dataList.Count == 0)
            {
                throw new ArgumentNullException("The list is empty!");
            }
            
            bool flag = false;
            int nbrPoints = 0;
            int nbrOpen = 0;
            int nbrHigh = 0;
            int nbrLow = 0;
            int nbrClose = 0;
            int nbrMilliSeconds = 0;

            nbrPoints = dataList.Count;
            foreach (var item in dataList)
            {
                if (item._Open > 0)
                    nbrOpen++;
                if (item._High > 0)
                    nbrHigh++;
                if (item._Low > 0)
                    nbrLow++;
                if (item._Close > 0)
                    nbrClose++;
                if (item._MilliSeconds > 0)
                    nbrMilliSeconds++;
            }

            return flag = (nbrPoints == nbrOpen) && (nbrPoints == nbrHigh) && (nbrPoints == nbrLow)
                            && (nbrPoints == nbrClose) && (nbrPoints == nbrMilliSeconds);
        }
    }
}
