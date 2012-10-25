<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
  CodeBehind="default.aspx.cs" Inherits="OAuth._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <header id="home" class="jumbotron subhead">
    <div class="page-header">
      <h1>
        Introduktion <small>Hvad er BAPI?</small></h1>
    </div>
  </header>
  <section>
    <div class='row'>
      <div class="span8">
        <p>
          DB2 Blob web API (BAPI) gør det enkelt og effektivt at læse og skrive blobs til
          DB2 på mainframe fra andre platforme. Blobs er typisk dokumenter af forskellige
          typer, som f.eks. Word, Excel, og foto. Platformen, som BAPI kan anvendes fra vil
          i vores situation være en .NET platform, men det kunne lige så godt være en anden,
          da BAPI er baseret på standarder.
        </p>
        <p>
          Du kan læse mere om web API programmeringsinterfacet på <a href="webapi.aspx">Web API-siden</a>.
          Kodeeksempler på brugen af BAPI kan du finde på <a href="kodeeksempler.aspx">Kodeeksempel-siden</a>.
          Her finder du også et <a href="download/DB2BlobsAPIKlient.zip">Visual Studio 2010 projekt, som anvender alle facetter af BAPI</a>.
        </p>
        <h2>
          Formål</h2>
        <p>
          Formålet med BAPI er flerhovedet:</p>
        <ul>
          <li>I forbindelse med undersøgelsen af hvorvidt DB2 Connect skal være en del af .NET
            TDM'erne, er det vigtigt at vurdere DB2 Connect ud fra praktiske erfaringer med
            produktet. BAPI er lavet for at få disse erfaringer.</li>
          <li>I forbindelse med indføringen af REST baserede web services(web API'er) som alternativ
            til de SOAP baserede i .NET TDM'erne er det væsentligt at få praktiske erfaringer,
            således at behovet for infrastruktur og retningslinjer kan vurderes. BAPI er lavet
            som en del af dette arbejde</li>
          <li>Forretningsområderne har ytret ønske om at kunne anvende en anden mekanisme end
            KWS/Zsrør til at læse og skrive blobs til DB2 på mainframen. BAPI kan ses som en
            prototype på en sådan mekanisme, som kan anvendes til at få viden om fordele og
            ulemper ved et sådant alternativ til KWS/Zsrørs blobsupport. </li>
        </ul>
      </div>
    </div>
  </section>
  <script type="text/javascript">
    $('#topbar li').removeClass('active');
    var a = $("#topbar li a[href='default.aspx']")[0];
    var li = $(a).parent().addClass('active');
  </script>
</asp:Content>
