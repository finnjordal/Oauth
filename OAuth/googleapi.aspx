<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="True"
  CodeBehind="googleapi.aspx.cs" Inherits="OAuth.GoogleApi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <header id="home" class="jumbotron subhead">
    <div class="page-header">
      <h1>Google API's implementation</h1>
    </div>
  </header>
  <section>
    <div class='row'>
      <div class="span8">
      <h2>Web Server Application</h2>
      <p>Googles beskrivelse af <a href="https://developers.google.com/accounts/docs/OAuth2WebServer">"OAuth 2.0 for Web Server Applications"</a></p>
      <p><a href="http://oauth.jordal.dk/oauthgooglewebserverapplication">Web application, som anvender dette flow</a>.</p>
      <h2>Web Client Application</h2>
      <p>Googles beskrivelse af  <a href="https://developers.google.com/accounts/docs/OAuth2UserAgent">"OAuth 2.0 for Client-side Applications"</a></p>
      <p><a href="http://oauth.jordal.dk/oauthgooglewebclientapplication">Web application, som anvender dette flow</a>.</p>
      </div>
    </div>
  </section>
  <script type="text/javascript">
    $('#topbar li').removeClass('active');
    var a = $("#topbar li a[href='googleapi.aspx']")[0];
    var li = $(a).parent().addClass('active');
  </script>
</asp:Content>
