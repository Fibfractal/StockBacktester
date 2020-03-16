using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphProject
{
    /// <summary>
    /// This class imports data from an API and exports it to SQL.
    /// The stocklist to import is from an Enum.
    /// The names in the stocklist is requested from the API one by one, and a
    /// new table with that stockname is created each time, and previous is deleted.
    /// After, the date and price fills the table in SQL. The process is repeated untill entire
    /// list is done. To be aware of is that the process uses asyncroned methods, so methods
    /// within that method dependent on await must be placed after await, for objects not get 
    /// null references.
    /// </summary>
    public class ExportToSql
    {
        public Stock OneStockFromApi { get; set; }
        public string StockName { get; set; }

        public void ExportOneStockToSql()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SqlDataBase")))
            {
                if (OneStockFromApi.historical != null)
                {
                    DeleteAndCreateTable(connection);
                    connection.Execute("INSERT INTO " + StockName + "1" + " VALUES (@Date, @Close) ", OneStockFromApi.historical);
                }
                else
                {
                    MessageBox.Show(string.Format("The API didn't return any value for the stock {0}  at {1}"
                        , StockName, DateTime.Now.TimeOfDay));
                }
            }
        }

        public void DeleteAndCreateTable(IDbConnection connection)
        {
            var sqlString = "DROP TABLE " + StockName + "1";
            connection.Execute(sqlString);
            var sqlString2 = "CREATE TABLE " + StockName + "1" + " (Date DateTime, [Close] float)";
            connection.Execute(sqlString2);
        }

        public async Task ExportToDatabase()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < ArrayEnumLenght(); i++)
            {
                try
                {
                    StockName = ArrayTickers()[i].ToString();
                    OneStockFromApi = await new Api().OneStockDataFromApi(StockName);
                    ExportOneStockToSql();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, string.Format("Stock: {0} and nbr: {1} in array failed the request", StockName, i));
                }
            }

            watch.Stop();
            var minutes = watch.Elapsed.TotalMinutes;
            var seconds = (minutes - (int)minutes) * 60;
            MessageBox.Show($"The entire stocklist was downloaded in {minutes:N0} min and {seconds:N0} s.");
        }

        private int ArrayEnumLenght()
        {
            var array = (NasdaqStockTickers[])Enum.GetValues(typeof(NasdaqStockTickers));
            return array.Length;
        }

        private NasdaqStockTickers[] ArrayTickers()
        {
            return (NasdaqStockTickers[])Enum.GetValues(typeof(NasdaqStockTickers));
        }
    }
}
