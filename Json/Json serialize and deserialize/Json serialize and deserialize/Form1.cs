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
using IGWebApiClient;
using dto.endpoint.auth.session.v2;
using IGWebApiClient.Common;

namespace Json_serialize_and_deserialize
{
    public partial class Form1 : Form
    {
        private readonly string _path = $"C:\\Users\\Erik\\source\\repos\\GraphProject\\Json\\Customer.txt";
        private List<Customer> _customerList;
        private WebClient _webclient;

        // IG
        private HttpClient _httpClient;
        private IgRestService _igRestService;
        private IgRestApiClient _igRestApiClient;
        

        // IG logging info
        private string _userName = "fibfractal";
        private string _password = "Q/0C/ZBdNhbpv76jPcdtFWUOVC2L2vg4xuGnjIvvJaU06ivUMy8osQcT+q+zUJZYHXWq/hYR+EmIYCV/HfwAQKScuo+B/E/Jw8HfyJS/6AWmxat5Dux1DpaPOI5aAc8uQxyQaGyB9XAzHAmLmccLDMDE0WgCcdG/su0lTtBvdTdmzzdTkvoUgzSANZ2b7+9WsAX6KaFXTxFugWUucX1wEQ3jwIMlHRBJs6cWhV22JJQomrh/SBO8rSM7yfIflrcZM3HA6gX0LE0dK5UaQUQNs2YLSMc8Wn9i+kEQK6V0RXN5uB1/5EvIglLjCXgN6TVALQysqNcuA9qgSxCGNp2Q0w==";
        private string _apiKey = "b26f4be1174e5d59bbbc2019a761ad53e16bb31c";
        private string _uri = "/gateway/deal/session";

        public Form1()
        {
            InitializeComponent();
            _customerList = new List<Customer>();
            _webclient = new WebClient();

            _httpClient = new HttpClient();
            // Hm, denna med null kan vara fel
            _igRestService = new IgRestService(null);
            _igRestApiClient = new IgRestApiClient("demo",null); // demo och null? ---> IGrestService, har "demo" förvalt. EventDispatcher är vald som null
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

        private void btn_Import_IG_Click(object sender, EventArgs e)
        {
            ConnectToIgMarkets();

        }

        private async void ConnectToIgMarkets()
        {
            var authRequest = new AuthenticationRequest();
            authRequest.identifier = _userName;
            authRequest.password = _password;
            var authResponse = await _igRestApiClient.SecureAuthenticate(authRequest, _apiKey);

            var httpMethod = new HttpMethod("POST");
            var serviceRequest = _igRestService.RestfulService(_uri, httpMethod, "2", _igRestApiClient.GetConversationContext(), null);
            // Unsure about T --> string, method returns json object
            var serviceResponse = _igRestService.RestfulService<string>(_uri, httpMethod, "2", _igRestApiClient.GetConversationContext(), null);
            tbx_IG.Text = serviceResponse.ToString();
        }

        /*
        public AuthenticationResponse Authenticate(string username, string password, string apikey, string baseurl)
        {
            _userName = username;
            _password = password;
            _apiKey = apikey;
            _baseUrl = baseurl;

            var conversationContext = new ConversationContext(null, null, _apiKey);

            // Encrypt the password
            string encpassword = EncryptPassword(_password);

            // create new httpclient
            HttpClient client = new HttpClient();
            SetDefaultRequestHeaders(client, conversationContext, "2");

            // create Authentication Request
            AuthenticationRequest req = new AuthenticationRequest();
            req.identifier = _userName;
            req.password = encpassword;
            req.encryptedPassword = true;

            // convert Authentication request to JSON
            var json = new StringContent(JsonConvert.SerializeObject(req));
            json.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // get Response
            HttpResponseMessage response = client.PostAsync(_baseUrl + "/session", json).Result;
            ParseHeaders(conversationContext, response.Headers);

            // convert response to AuthenticationResponse object
            string jsonString = response.Content.ReadAsStringAsync().Result;
            AuthenticationResponse aresp = JsonConvert.DeserializeObject(jsonString);
            return aresp;
        }
        */
    }
}
