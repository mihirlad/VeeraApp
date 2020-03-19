using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace VeeraApp
{
    public partial class BindJSONDataToGrid : System.Web.UI.Page
    {
        string apiUrl = "http://localhost:26404/api/CustomerAPI";

        protected void Page_Load(object sender, EventArgs e)
        {

            this.PopulateGridView();

            //WebRequest req = WebRequest.Create(_URL);
            //req.Credentials = CredentialCache.DefaultCredentials;
            //req.Method = "GET";
            //req.Headers.Add(ConfigurationManager.AppSettings["key"].ToString());
            //req.ContentType = "application/json; charset=utf-8";
            //WebResponse resp = req.GetResponse();
            //Stream stream = resp.GetResponseStream();
            //StreamReader re = new StreamReader(stream);
            //String json = re.ReadToEnd();
            //json = "{\"SalesPerson\":" + json + "}";
            //wrapper w = (wrapper)new JavaScriptSerializer().Deserialize(json, typeof(wrapper));
            //if (w.salesperson.Count > 0)
            //{
            //    GridView1.DataSource = w.salesperson;
            //    GridView1.DataBind();
            //}

        
        }


        private void PopulateGridView()
        {

            //object input = new
            //{
            //    Name = txtName.Text.Trim(),
            ////};
            //string inputJson = (new JavaScriptSerializer()).Serialize(input);

            //WebClient client = new WebClient();
            //client.Headers["Content-type"] = "application/json";
            //client.Encoding = Encoding.UTF8;
            //string json = client.UploadString(apiUrl);// + "/GetCustomers", inputJson);
            //GridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<GetJSONDataToBind>>(json);
            //GridView1.DataBind();
        }


        public class GetJSONDataToBind
        {
            public int id { get; set; }
            public string imei { get; set; }
            public string pver { get; set; }
            public string uid { get; set; }
            public string ukey { get; set; }
            public string dtm { get; set; }
            public string seq { get; set; }
            public string msgid { get; set; }
            public string mdev { get; set; }
            public string io { get; set; }
            public string di { get; set; }
            public string di1 { get; set; }
            public string di2 { get; set; }
            public string a1 { get; set; }
            public string a2 { get; set; }
            public string s1 { get; set; }
            public string dev { get; set; }
            public string sysv { get; set; }
            public string pfail { get; set; }
            public string sig { get; set; }

        }


    }
}