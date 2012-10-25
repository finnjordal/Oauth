using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Net.Http;
using System.Json;

namespace GoogleInstalledApplication
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      webBrowser1.Url = new Uri("https://accounts.google.com/o/oauth2/auth?client_id=185454440685-6dfl2dqdonfcsstooncf7cps6qt2vs4p.apps.googleusercontent.com&scope=https://www.googleapis.com/auth/drive&response_type=code&redirect_uri=http://localhost");
    }

    private async void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {      
      if (e.Url.Query.Contains("code="))
      {
        NameValueCollection coll = HttpUtility.ParseQueryString(e.Url.Query);
        string code = coll["code"];
        string error = coll["error"];
        if (!String.IsNullOrEmpty(error))
        {
          MessageBox.Show("error: " + error);
        }
        else if (!String.IsNullOrEmpty(code))
        {
          MessageBox.Show("code: " + code);

          HttpClient client = new HttpClient();
          var fueColl = new Dictionary<string, string>();
          fueColl["client_id"] = "185454440685-6dfl2dqdonfcsstooncf7cps6qt2vs4p.apps.googleusercontent.com";
          fueColl["client_secret"] = "Xz4cQUFPX_feSETa3OWF_jSH";
          fueColl["code"] = code;
          fueColl["grant_type"] = "authorization_code";
          fueColl["redirect_uri"] = "http://localhost"; //"urn:ietf:wg:oauth:2.0:oob";
          HttpContent content = new FormUrlEncodedContent(fueColl);
          HttpResponseMessage response = await client.PostAsync("https://accounts.google.com/o/oauth2/token", content);
          bool statusOk = response.IsSuccessStatusCode;
          string responseBody = await response.Content.ReadAsStringAsync();
          MessageBox.Show("response: " + responseBody);
          JsonObject accessInfo = (JsonObject)JsonObject.Parse(responseBody);
          string accessToken = (string)accessInfo["access_token"];
          MessageBox.Show("access_token: " + accessToken);

          client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
          response = await client.GetAsync("https://www.googleapis.com/drive/v2/files");
          statusOk = response.IsSuccessStatusCode;
          string filesstring = await response.Content.ReadAsStringAsync();
          JsonObject files = (JsonObject)JsonObject.Parse(filesstring);
          JsonArray filelist = (JsonArray)files["items"];
          foreach (JsonObject file in filelist)
          {
            MessageBox.Show(file["title"].ToString());
          }
        }
        else
        {
          MessageBox.Show("Ukendt request");
        }
      }
    }
  }
}
