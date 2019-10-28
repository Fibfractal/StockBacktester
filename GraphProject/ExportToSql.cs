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
                connection.Execute("dbo.Insert_OMX_Data @Open @High @Low @Close @MilliSeconds", dataPoints);
            }
        }
    }
}
