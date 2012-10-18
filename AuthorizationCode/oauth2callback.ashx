<%@ WebHandler Language="C#" Class="oauth2callback" %>

using System;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Json;

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

  public void GetPage(HttpContext context)
  {    
    string code = context.Request.QueryString["code"];
    // if (String.IsNullOrEmpty(code)) {
      
    context.Response.ContentType = "text/html; charset=utf-8";
    HttpWriter sw = (HttpWriter)context.Response.Output;
    sw.Write("<!DOCTYPE html><html><head>");
    sw.Write("<title>Live info</title>");
    sw.Write("</head><body><h1>Live info</h1>");
    sw.Write("<p>code: " + code + "</p>");

    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://login.live.com/oauth20_token.srf");
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    StreamWriter w = new StreamWriter(request.GetRequestStream());
    string clientInfo = @"client_id=00000000440D6853&client_secret=" + HttpUtility.UrlEncode("drkuSjtt-lV0XBqFtFXxa8jhzFkBb3sA") + "&code="+code+"&grant_type=authorization_code&redirect_uri=" + HttpUtility.UrlEncode("http://oauth.jordal.dk/liveauthorizationcode/oauth2callback.ashx");
    w.Write(clientInfo);
    w.Close();  
    WebResponse response = request.GetResponse();
    JsonObject accessInfo = (JsonObject)JsonObject.Load(response.GetResponseStream());
    string accessToken = (string)accessInfo["access_token"];
    sw.Write("<p>access_token: " + accessToken + "</p>");

    request = (HttpWebRequest)WebRequest.Create("https://apis.live.net/v5.0/me?access_token=" + accessToken);
    response = request.GetResponse();
    JsonObject userInfo = (JsonObject)JsonObject.Load(response.GetResponseStream());
    sw.Write("<p>Dit navn: " + userInfo["name"] + "</p>");

    request = (HttpWebRequest)WebRequest.Create("https://apis.live.net/v5.0/me/share?access_token=" + accessToken);
    request.Method = "POST";
    request.ContentType = "application/json";
    w = new StreamWriter(request.GetRequestStream());
    JsonObject share = new JsonObject();
    share["message"] = "Prøver Microsoft Live OAuth 2.0 implementation af";
    share.Save(w);
    w.Close();
    response = request.GetResponse();
    JsonObject shareInfo = (JsonObject)JsonObject.Load(response.GetResponseStream());
    sw.Write("<p>Share: " + shareInfo["message"] + "</p>");
    sw.Write("<p>From: " + shareInfo["from"]["name"] + "</p>");
    
    
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