using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      if (e.Url.Query.Contains("code=")) {
        NameValueCollection coll= HttpUtility.ParseQueryString(e.Url.Query);
        string code= coll["code"];
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      webBrowser1.Url = new Uri("https://login.live.com/oauth20_authorize.srf?client_id=000000004C0D3000&scope=wl.basic wl.share&response_type=code&redirect_uri=https://login.live.com/oauth20_desktop.srf");
    }
  }
}
