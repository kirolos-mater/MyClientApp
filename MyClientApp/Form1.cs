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
using System.Net.Http;
using System.Net.Http.Formatting;

namespace MyClientApp
{
    public partial class Form1 : Form
    {

        localhost.WebService1 proxy = new localhost.WebService1();
        HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void WebServicesSettings()
        {
            client.BaseAddress = new Uri("https://localhost:44376/WebService1.asmx/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //string countriesJson = proxy.Countries();

            //DataTable dtCountries = JsonConvert.DeserializeObject<DataTable>(countriesJson);

            //dataGridView1.DataSource = dtCountries;

            WebServicesSettings();

        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            HttpResponseMessage message = client.GetAsync("dataTableForUSers?id=" + textBoxID.Text + "").Result;

            string userJson = message.Content.ReadAsStringAsync().Result;

            MessageBox.Show(userJson);
        }
    }
}
