<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
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
      <p>Microsoft gen benævnelse: <a href="http://msdn.microsoft.com/en-us/library/live/hh243647#authcodegrant">"Authorization code grant flow"</a></p>
      <p><a href="http://oauth.jordal.dk/liveauthorizationcode/">Web application, som anvender dette flow</a>.</p>
      </div>
    </div>
  </section>
  <script type="text/javascript">
    $('#topbar li').removeClass('active');
    var a = $("#topbar li a[href='microsoft.live.aspx']")[0];
    var li = $(a).parent().addClass('active');
  </script>
</asp:Content>
