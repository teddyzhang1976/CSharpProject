<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="UserInfo.ascx" TagName="UserInfo" TagPrefix="uc4" %>
<%@ Register Src="DateSelectorControl.ascx" TagName="DateSelectorControl" TagPrefix="uc1" %>
<%@ Register Src="EventListControl.ascx" TagName="EventListControl" TagPrefix="uc2" %>
<%@ Register Src="LinksControl.ascx" TagName="LinksControl" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Web Parts Page</title>
  <style>
    .body {font-family: Verdana; background-color: #ddffdd;}
    .mainDiv {text-align: center;}
    .innerDiv {width: 649px; text-align: left;}
    .zoneDiv {width: 200px; float: left; border: blue 4px double; padding: 2px; 
      margin: 2px; background-color: #ffffcc;}
    .footerDiv {width: 632px; clear: both; border: blue 4px double; padding: 2px; 
      margin: 2px; background-color: #ffcc99;}
  </style>
</head>
<body class="body">
  <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server" OnDisplayModeChanged="WebPartManager1_DisplayModeChanged">
      <StaticConnections>
        <asp:WebPartConnection ID="dateConnection" ConsumerConnectionPointID="DateConsumer"
          ConsumerID="EventListControl1" ProviderConnectionPointID="DateProvider" ProviderID="DateSelectorControl1" />
      </StaticConnections>
    </asp:WebPartManager>
    <div class="mainDiv">
      <h1>Web Parts Page</h1>
      Display mode:
      <asp:DropDownList ID="displayMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="displayMode_SelectedIndexChanged" />
      <br />
      <asp:LinkButton runat="server" ID="resetButton" Text="Reset Layout" OnClick="resetButton_Click" />
      <br />
      <br />
      <div class="innerDiv">
        <div class="zoneDiv">
          <asp:WebPartZone ID="LeftZone" runat="server">
            <ZoneTemplate>
              <uc1:DateSelectorControl ID="DateSelectorControl1" runat="server" title="Date" />
            </ZoneTemplate>
          </asp:WebPartZone>
        </div>
        <div class="zoneDiv">
          <asp:WebPartZone ID="CenterZone" runat="server">
            <ZoneTemplate>
              <uc2:EventListControl ID="EventListControl1" runat="server" title="Events" />
            </ZoneTemplate>
          </asp:WebPartZone>
        </div>
        <div class="zoneDiv">
          <asp:WebPartZone ID="RightZone" runat="server">
            <ZoneTemplate>
              <uc4:UserInfo ID="UserInfo1" runat="server" title="User Info" />
            </ZoneTemplate>
          </asp:WebPartZone>
        </div>
        <asp:PlaceHolder runat="server" ID="editorPH" Visible="false">
          <div class="footerDiv">
            <asp:EditorZone ID="EditorZone1" runat="server">
              <ZoneTemplate>
                <asp:AppearanceEditorPart ID="AppearanceEditorPart1" runat="server" />
              </ZoneTemplate>
            </asp:EditorZone>
            <asp:CatalogZone ID="CatalogZone1" runat="server">
              <ZoneTemplate>
                <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />
                <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" runat="server">
                  <WebPartsTemplate>
                    <uc3:LinksControl ID="LinksControl1" runat="server" title="Links" />
                  </WebPartsTemplate>
                </asp:DeclarativeCatalogPart>
              </ZoneTemplate>
            </asp:CatalogZone>
          </div>
        </asp:PlaceHolder>
      </div>
    </div>
  </form>
</body>
</html>
