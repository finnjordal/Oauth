<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="True"
  CodeBehind="default.aspx.cs" Inherits="OAuth._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <header id="home" class="jumbotron subhead">
    <div class="page-header">
      <h1>Introduktion</h1>
    </div>
  </header>
  <section>
    <div class='row'>
      <div class="span8">
        <p>Nærværende site indeholder en række eksperimenter med konkrete OAuth 2.0 implementationer.
          Det drejer sig om <a href="microsftlive.aspx">Microsoft Lives implementation</a> og <a href="googleapi.aspx">Google API's implementation</a>
        </p>
      </div>
    </div>
  </section>
  <script type="text/javascript">
    $('#topbar li').removeClass('active');
    var a = $("#topbar li a[href='default.aspx']")[0];
    var li = $(a).parent().addClass('active');
  </script>
</asp:Content>
