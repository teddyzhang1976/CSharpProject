<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserInfo" %>
<asp:LoginView ID="LoginView1" runat="server">
  <LoggedInTemplate>
    You are logged in as <b>
      <asp:LoginName ID="LoginName1" runat="server" />
    </b>
    <br />
    <br />
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
  </LoggedInTemplate>
  <RoleGroups>
    <asp:RoleGroup Roles="Administrator">
      <ContentTemplate>
        You are logged in as <b>
          <asp:LoginName ID="LoginName1" runat="server" />
        </b>
        <br />
        <br />
        <i>You are an administrator!</i>
        <br />
        <br />
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
      </ContentTemplate>
    </asp:RoleGroup>
  </RoleGroups>
</asp:LoginView>
