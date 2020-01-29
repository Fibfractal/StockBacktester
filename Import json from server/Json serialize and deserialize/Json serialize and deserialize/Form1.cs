using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;

namespace Json_serialize_and_deserialize
{
    public partial class Form1 : Form
    {
        private readonly string _path = $"C:\\Users\\Erik\\source\\repos\\GraphProject\\Json\\Customer.txt";
        private List<Customer> _customerList;
        private WebClient _webclient;

        public Form1()
        {
            InitializeComponent();
            _customerList = new List<Customer>();
            _webclient = new WebClient();
        }

        private void btn_CreateJsonfile_Click(object sender, EventArgs e)
        {

            try
            {
                var customer = CreateCustomer();
                var customer2 = CreateCustomer();
                _customerList.Add(customer);
                _customerList.Add(customer2);

                var jsonToFile = JsonConvert.SerializeObject(_customerList, Formatting.Indented);

                using (var writer  = new StreamWriter(_path))
                {
                    writer.WriteLine(jsonToFile);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ooops something went wrong!");
            }

        }



        
        private void btn_ImportJSon_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonFromFile;

                using (var reader = new StreamReader(_path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }

                var customer = JsonConvert.DeserializeObject<List<Customer>>(jsonFromFile);

                // EX. om du endast vill ha en del av datan, där  main är {} och temp inom
                // var part = customer[main][temp].ToString();

                var array = customer.ToArray();

                lbx_Customers.Items.AddRange(array);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ooops something went wrong!");
            }
        }

        private void btn_SMHI_Click(object sender, EventArgs e)
        {
            var urlSmhi = _webclient.DownloadString("https://opendata-download-metfcst.smhi.se/api/" +
                "category/pmp3g/version/2/geotype/point/lon/16.158/lat/58.5812/data.json");

            dynamic smhi = JsonConvert.DeserializeObject<dynamic>(urlSmhi);
            string dataType = smhi["geometry"]["type"].ToString();
            tbx_Smhi.Text = dataType;
        }

        private Customer CreateCustomer()
        {
            var customer = new Customer
            {
                FirstName = "Robert",
                LastName = "Nilsson",
                Age = 38,
                Myaddress = new Address
                {
                    City = "Höllviken",
                    Street = "Holländarevägen 24",
                    PostNbr = "23634"
                },
                Gender = "Male"
            };

            return customer;
        }

        private void Btn_Import_Stock_Data_Click(object sender, EventArgs e)
        {
            try
            {
                // Alternative 1
                // Import shorter time series of data, containing a lot of data per day
                /*
                string url = _webclient.DownloadString("https://financialmodelingprep.com/api/v3/historical-price-full/AAPL");
                var stockData = JsonConvert.DeserializeObject<dynamic>(url);
                var dataType = stockData["historical"][0]["close"].ToString();
                var dataType2 = stockData["historical"];
                foreach (var item in dataType2)
                {
                    lbx_Customers.Items.Add(item["close"].ToString());
                }

                tbx_Smhi.Text = dataType;
                */

                // Alternative 2
                //ContactServer();

                // Alternative 3
                ContactServerv2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ooops something went wrong!");
            }
        }

        public async void ContactServer()
        {
            using (var httpClient = new HttpClient())
            {
                // Using a long time series over apple
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://financialmodelingprep.com/api/v3/historical-price-full/AAPL?serietype=line&serieformat=array"))
                {
                    request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                    var response = await httpClient.SendAsync(request);
                    string json = response.Content.ReadAsStringAsync().Result;
                    var stockData = JsonConvert.DeserializeObject<dynamic>(json);
                    var dataType2 = stockData["historical"];
                    foreach (var item in dataType2)
                    {
                        lbx_Customers.Items.Add(item["close"].ToString());
                    }
                }
            }
        }

        // One try to directly convert all data in json to respektivly properties in Stock class
        // Match class hierarcy, so that class object is handled in the same way as usual
        public async void ContactServerv2()
        {
            using (var httpClient = new HttpClient())
            {
                // Using a long time series over apple
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://financialmodelingprep.com/api/v3/historical-price-full/AAPL?serietype=line&serieformat=array"))
                {
                    request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                    var response = await httpClient.SendAsync(request);
                    // Gets the json structure
                    string json = response.Content.ReadAsStringAsync().Result;
                    // Stock class matches json structure
                    var stockData = JsonConvert.DeserializeObject<Stock>(json);

                    lbx_Customers.Items.AddRange(stockData.historical);
                }
            }
        }
    }


}
