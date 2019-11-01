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
                return connection.Query<DailyDataPoint>("select _Open,_High,_Low,_Close,_MilliSeconds from DataPointDaily").ToList();
                //return connection.Query<DailyDataPoint>("select _Close from RSI").ToList();
            }
            
        }
    }
}
