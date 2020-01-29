using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Data;

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
                // Updates the table i the DB, if there is data available in API
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

        /// <summary>
        /// A table with a certain stock name is deleted and then created with column names.
        /// </summary>
        public void DeleteAndCreateTable(IDbConnection connection)
        {
            var sqlString = "DROP TABLE " + StockName + "1";
            connection.Execute(sqlString);
            var sqlString2 = "CREATE TABLE " + StockName + "1" + " (Date DateTime, [Close] float)";
            connection.Execute(sqlString2);
        }

        /// <summary>
        /// For every stock in the enum for stocks, this process is repeted.
        /// Get the ticker name from enum, call the API server for price data. Get the JSON price data convert it
        /// to class data, and open a database connection. Delete the previous table in database for that stock,
        /// and create a new one with new price and datetime data from class data.
        /// </summary>
        public async void GetAllStockData()
        {
            int i = 0;

            for (i = 0; i < ArrayEnumLenght(); i++)
            {
                try
                {
                    StockName = ArrayTickers()[i].ToString();
                    var _httpString = "https://financialmodelingprep.com/api/v3/historical-price-full/" + StockName +
                        "?serietype=line&serieformat=array";

                    // Getting one stock at a time
                    using (var httpClient = new HttpClient())
                    {
                        // Using a long time series over one stock
                        using (var request = new HttpRequestMessage(new HttpMethod("GET"), _httpString))
                        {
                            request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                            // Wait for the server response
                            var response = await httpClient.SendAsync(request);
                            // Gets the json structure
                            string json = response.Content.ReadAsStringAsync().Result;
                            // Stock class matches json structure
                            // Small or capital letters dont have to match between
                            // class properties and json properties
                            GetOneStockFromServer = JsonConvert.DeserializeObject<Stock>(json);

                            ExportChangeOneStockData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, string.Format("Stock: {0} and nbr: {1} in array failed the request", StockName, i));
                }
            }
            MessageBox.Show("The entire stocklist was downloaded!");
        }

        /// <summary>
        /// Get all one stock ticker from enum.
        /// </summary>
        private string GetStockNameFromEnum(int i)
        {
            var arrayOfTickers = (NasdaqStockTickers[])Enum.GetValues(typeof(NasdaqStockTickers));

            return arrayOfTickers[i].ToString();
        }

        /// <summary>
        /// Get all stock tickers as an array from enum,
        /// and returns the lenght of that array.
        /// </summary>
        /// <returns></returns>
        private int ArrayEnumLenght()
        {
            var array = (NasdaqStockTickers[])Enum.GetValues(typeof(NasdaqStockTickers));
            return array.Length;
        }

        /// <summary>
        /// Get all stock tickers as an array from enum.
        /// </summary>
        private NasdaqStockTickers[] ArrayTickers()
        {
            return (NasdaqStockTickers[])Enum.GetValues(typeof(NasdaqStockTickers));
        }
    }
}
