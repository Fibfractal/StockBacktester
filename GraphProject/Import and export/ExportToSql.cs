using Dapper;
using System;
using System.Data;
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
        public Stock GetOneStockFromServer { get; set; }
        public string StockName { get; set; }

        public void ExportChangeOneStockData()
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("DBName")))
            {
                if (GetOneStockFromServer.historical != null)
                {
                    DeleteAndCreateTable(connection);
                    connection.Execute("INSERT INTO " + StockName + "1" + " VALUES (@Date, @Close) ", GetOneStockFromServer.historical);
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

        public async void ExportToDatabase()
        {
            int i;

            for (i = 0; i < ArrayEnumLenght(); i++)
            {
                try
                {
                    StockName = ArrayTickers()[i].ToString();
                    GetOneStockFromServer = await new Api().OneStockDataFromApi(StockName);
                    ExportChangeOneStockData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, string.Format("Stock: {0} and nbr: {1} in array failed the request", StockName, i));
                }
            }
            MessageBox.Show("The entire stocklist was downloaded!");
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
