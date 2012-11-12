<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="True"
  CodeBehind="microsoftlive.aspx.cs" Inherits="OAuth.MicrosoftLive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <header id="home" class="jumbotron subhead">
    <div class="page-header">
      <h1>Microsoft Lives implementation</h1>
    </div>
  </header>
  <section>
    <div class='row'>
      <div class="span8">
      <h2>Web Server Application</h2>
      <p>Microsoft benævner dette OAuth 2.0 flow: <a href="http://msdn.microsoft.com/en-us/library/live/hh243647#authcodegrant">"Authorization code grant flow"</a></p>
      <p><a href="http://oauth.jordal.dk/oauthmicrosoftwebserverapplication">Web application, som anvender dette flow</a>.</p>
      <h2>Web Client Application</h2>
      <p>Microsoft benævner dette OAuth 2.0 flow: <a href="http://msdn.microsoft.com/en-us/library/live/hh243647#implicitgrant">"Implicite grant flow"</a></p>
      <p><a href="http://oauth.jordal.dk/oauthmicrosoftwebclientapplication">Web application, som anvender dette flow</a>.</p>
      <h2>Installed Application</h2>
      <p>Microsofts beskrivelse af  <a href="http://msdn.microsoft.com/en-us/library/live/hh826529.aspx">"OAuth 2.0 for Installed Applications"</a></p>
      <p>Installed applications ligger ikke på webbet, men på min PC :)</p>
      </div>
    </div>
  </section>
  <script type="text/javascript">
    $('#topbar li').removeClass('active');
    var a = $("#topbar li a[href='microsoftlive.aspx']")[0];
    var li = $(a).parent().addClass('active');
  </script>
</asp:Content>
