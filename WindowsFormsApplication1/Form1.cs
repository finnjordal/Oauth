using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Json;
using System.Threading.Tasks;
using System.Text;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private async void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (e.Url.Query.Contains("code="))
      {
        NameValueCollection coll = HttpUtility.ParseQueryString(e.Url.Query);
        string code = coll["code"];

        HttpClient client= new HttpClient();
        var fueColl = new Dictionary<string, string>();
        fueColl["client_id"] = "000000004C0D3000";
        fueColl["client_secret"]= "rJL6xgsGUN61hDkNVgASiEAdFTWL5LWy";
        fueColl["code"]= code;
        fueColl["grant_type"]= "authorization_code";
        fueColl["redirect_uri"]= "https://login.live.com/oauth20_desktop.srf";
        HttpContent content= new FormUrlEncodedContent(fueColl);
        HttpResponseMessage response = await client.PostAsync("https://login.live.com/oauth20_token.srf",content);
        bool statusOk= response.IsSuccessStatusCode;
        string responseBody= await response.Content.ReadAsStringAsync();
        JsonObject accessInfo = (JsonObject)JsonObject.Parse(responseBody);
        string accessToken = (string)accessInfo["access_token"];

        Task<HttpResponseMessage> task1 = client.GetAsync("https://apis.live.net/v5.0/me?access_token=" + accessToken);
        JsonObject share = new JsonObject();
        share["message"] = "Prøver Microsoft Live OAuth 2.0 implementation af";
        StringContent sharecontent= new StringContent(share.ToString(),Encoding.UTF8,"application/json");
        Task<HttpResponseMessage> task2 = client.PostAsync("https://apis.live.net/v5.0/me/share?access_token=" + accessToken, sharecontent);
        HttpResponseMessage response1 = await task1;
        HttpResponseMessage response2 = await task2;

        statusOk = response1.IsSuccessStatusCode;
        string responseBody1 = await response1.Content.ReadAsStringAsync();
        JsonObject userInfo = (JsonObject)JsonObject.Parse(responseBody1);
        MessageBox.Show("Dit navn: " + userInfo["name"]);

        statusOk = response2.IsSuccessStatusCode;
        string responseBody2 = await response2.Content.ReadAsStringAsync();
        JsonObject shareInfo = (JsonObject)JsonObject.Parse(responseBody2);
        MessageBox.Show("Share: " + shareInfo["message"]);

        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://login.live.com/oauth20_token.srf");
        //request.Method = "POST";
        //request.ContentType = "application/x-www-form-urlencoded";
        //StreamWriter w = new StreamWriter(request.GetRequestStream());
        //// Skal client_id og client_secret indlejres i koden? Eller hvor skal den komme fra?
        //string clientInfo = @"client_id=000000004C0D3000&client_secret=" + HttpUtility.UrlEncode("rJL6xgsGUN61hDkNVgASiEAdFTWL5LWy") + "&code=" + code + "&grant_type=authorization_code&redirect_uri=" + HttpUtility.UrlEncode("https://login.live.com/oauth20_desktop.srf");
        //w.Write(clientInfo);
        //w.Close();
        //WebResponse response = request.GetResponse();
        //JsonObject accessInfo = (JsonObject)JsonObject.Load(response.GetResponseStream());
        //string accessToken = (string)accessInfo["access_token"];

        //request = (HttpWebRequest)WebRequest.Create("https://apis.live.net/v5.0/me?access_token=" + accessToken);
        //response = request.GetResponse();
        //JsonObject userInfo = (JsonObject)JsonObject.Load(response.GetResponseStream());
        //MessageBox.Show("Dit navn: " + userInfo["name"]);

        //request = (HttpWebRequest)WebRequest.Create("https://apis.live.net/v5.0/me/share?access_token=" + accessToken);
        //request.Method = "POST";
        //request.ContentType = "application/json";
        //w = new StreamWriter(request.GetRequestStream());
        //JsonObject share = new JsonObject();
        //share["message"] = "Prøver Microsoft Live OAuth 2.0 implementation af";
        ////share["test"]= new JsonObject();
        ////share["test"]["test1"]= "TEst2";
        //share.Save(w);
        //string s= share.ToString();
        //w.Close();
        //response = request.GetResponse();
        //JsonObject shareInfo = (JsonObject)JsonObject.Load(response.GetResponseStream());
        //MessageBox.Show("Share: " + shareInfo["message"]);
        //MessageBox.Show("From: " + shareInfo["from"]["name"]);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      webBrowser1.Url = new Uri("https://login.live.com/oauth20_authorize.srf?client_id=000000004C0D3000&scope=wl.basic wl.share&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf");
    }
  }
}
