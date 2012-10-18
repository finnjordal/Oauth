using System;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Json;

namespace GetAccessToken
{
  class Program
  {
    static void Main(string[] args)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://login.live.com/oauth20_token.srf");
      request.Method = "POST";
      request.ContentType = "application/x-www-form-urlencoded";
      StreamWriter w = new StreamWriter(request.GetRequestStream());
      string clientInfo = @"client_id=00000000440D6853&client_secret="+HttpUtility.UrlEncode("drkuSjtt-lV0XBqFtFXxa8jhzFkBb3sA")+"&code=71f7baae-dc35-8d43-06b0-50795d8d909f&grant_type=authorization_code&redirect_uri="+HttpUtility.UrlEncode("http://oauth.jordal.dk/liveauthorizationcode/oauth2callback.ashx");
      w.Write(clientInfo);
      w.Close();
      WebResponse response= null;
      try
      {
        response = request.GetResponse();
      }
      catch (Exception ex)
      {
      }
      finally
      {
      }
      JsonObject accessInfo = (JsonObject)JsonObject.Load(response.GetResponseStream());
      string accessToken = (string)accessInfo["access_token"];       

    }
  }
}
