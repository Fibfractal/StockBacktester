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
            var personList = new List<Person>
            {
                new Person { FirstName = "Robert", Age = 10},
                new Person {FirstName = "Fredrik", Age = 15}
            };

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DBName")))
            {
                //connection.Execute("dbo.People_Insert @FirstName @Age", personList);
                connection.Execute("INSERT INTO Person")
            }

            /*
            var dataPoints = _dataTextFile.ImportData();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DBName")))
            {
                connection.Execute("dbo.DataPoint_Insert @_Open @_High @_Low @_Close @_MilliSeconds", dataPoints);
            }
            */
        }
    }
}
