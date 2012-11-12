
using System;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Json;
using System.Collections.Generic;
//using System.Threading.Tasks;

public class oauth2callback : IHttpHandler
{


  public void ProcessRequest(HttpContext context)
  {

    switch (context.Request.HttpMethod)
    {
      case "GET":
        GetPage(context);
        break;
      default:
        context.Response.StatusCode = 405;
        break;
    }
  }

  // problemer med det asynkrone i forholde til httphandlere. Anvend webrequest som i microsoft udgaven
  public void GetPage(HttpContext context)
  {
    context.Response.ContentType = "text/html; charset=utf-8";
    HttpWriter sw = (HttpWriter)context.Response.Output;
    sw.Write("<!DOCTYPE html><html><head>");
    sw.Write("<title>Google web server application</title>");
    sw.Write("</head><body><h1>Google web server application</h1>");

    try
    {
      string error = context.Request.QueryString["error"];
      string code = context.Request.QueryString["code"];
      if (!String.IsNullOrEmpty(error))
      {
        sw.Write("<p>error: " + error + "</p>");
      }
      else if (!String.IsNullOrEmpty(code))
      {
        sw.Write("<p>code: " + code + "</p>");

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        StreamWriter w = new StreamWriter(request.GetRequestStream());
        string clientInfo = @"client_id=185454440685.apps.googleusercontent.com&client_secret=" + HttpUtility.UrlEncode("bgHAL45erk_QC-F-wEGfRmbl") + "&code=" + code + "&grant_type=authorization_code&redirect_uri=" + HttpUtility.UrlEncode("http://oauth.jordal.dk/oauthgooglewebserverapplication/oauth2callback.ashx");
        w.Write(clientInfo);
        w.Close();
        WebResponse response = request.GetResponse();
        JsonObject accessInfo = (JsonObject)JsonObject.Load(response.GetResponseStream());
        string accessToken = (string)accessInfo["access_token"];
        sw.Write("<p>access_token: " + accessToken + "</p>");

        //HttpClient client = new HttpClient();
        //var fueColl = new Dictionary<string, string>();
        //fueColl["client_id"] = "185454440685.apps.googleusercontent.com";
        //fueColl["client_secret"] = "bgHAL45erk_QC-F-wEGfRmbl";
        //fueColl["code"] = code;
        //fueColl["grant_type"] = "authorization_code";
        //fueColl["redirect_uri"] = "http://oauth.jordal.dk/oauthgooglewebserverapplication/oauth2callback.ashx";
        //HttpContent content = new FormUrlEncodedContent(fueColl);
        //HttpResponseMessage response = await client.PostAsync("https://accounts.google.com/o/oauth2/token", content);
        //bool statusOk = response.IsSuccessStatusCode;
        //string responseBody = await response.Content.ReadAsStringAsync();
        //sw.Write("<p>response: " + responseBody + "</p>");
        //JsonObject accessInfo = (JsonObject)JsonObject.Parse(responseBody);
        //string accessToken = (string)accessInfo["access_token"];
        //sw.Write("<p>access_token: " + accessToken + "</p>");


        request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/drive/v2/files");
        request.Headers.Add("Authorization", "Bearer " + accessToken);
        response = request.GetResponse();
        JsonObject files = (JsonObject)JsonObject.Load(response.GetResponseStream());
        JsonArray filelist = (JsonArray)files["items"];
        foreach (JsonObject file in filelist)
        {
          sw.Write("<p>" + file["title"].ToString() + "</p>");
        }

        //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        //response = await client.GetAsync("https://www.googleapis.com/drive/v2/files");
        //statusOk = response.IsSuccessStatusCode;
        //string filesstring = await response.Content.ReadAsStringAsync();
        //JsonObject files = (JsonObject)JsonObject.Parse(filesstring);
        //JsonArray filelist = (JsonArray)files["items"];
        //foreach (JsonObject file in filelist)
        //{
        //  sw.Write("<p>" + file["title"].ToString() + "</p>");
        //}


      }
      else
      {
        sw.Write("<p>Ukendt request</p>");
      }
    }
    catch (Exception ex)
    {
      sw.Write("<p>Exception: " + ex.Message+"</p>");
    }
    sw.Write("</body></html>");
  }

  public bool IsReusable
  {
    get
    {
      return false;
    }
  }
}

