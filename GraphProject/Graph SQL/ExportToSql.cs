using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace GraphProject
{
    public class ExportToSql
    {
        private ImportFromTextFile _dataTextFile;

        public ExportToSql()
        {
            _dataTextFile = new ImportFromTextFile();
        }

        public void ExportData()
        {
            
            var dataPoints = _dataTextFile.ImportData();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DBName")))
            {
                //connection.Execute("dbo.DataPoint_Insert @_Open @_High @_Low @_Close @_MilliSeconds", dataPoints);

                // Here I dont use stored procedures, since only string type works, not double (float) works.
                connection.Execute("INSERT INTO DataPointDaily VALUES (@_Open, @_High, @_Low, @_Close, @_MilliSeconds) ", dataPoints);
            }
            
        }
    }
}
