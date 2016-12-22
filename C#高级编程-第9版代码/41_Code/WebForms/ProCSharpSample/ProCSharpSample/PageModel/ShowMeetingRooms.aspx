<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowMeetingRooms.aspx.cs" Inherits="ProCSharpSample.PageModel.ShowMeetingRooms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownListMeetingRooms" runat="server">
            <asp:ListItem>Sacher</asp:ListItem>
            <asp:ListItem>Hawelka</asp:ListItem>
            <asp:ListItem>Hummel</asp:ListItem>
            <asp:ListItem>Prückel</asp:ListItem>
            <asp:ListItem>Landtmann</asp:ListItem>
            <asp:ListItem>Sperl</asp:ListItem>
            <asp:ListItem>Alt Wien</asp:ListItem>
            <asp:ListItem>Eiles</asp:ListItem>
        </asp:DropDownList>
    </div>
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/PageModel/MeetingRoomInformation.aspx" Text="Button" />
        <p>
            <asp:Button ID="Button2" runat="server" Text="Button" />
        </p>
    </form>
</body>
</html>
