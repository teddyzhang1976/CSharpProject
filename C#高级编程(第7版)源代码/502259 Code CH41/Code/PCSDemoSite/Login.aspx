<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
  CodeFile="Login.aspx.cs" Title="Pro C# Demo Site - Login" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>
    Login Page</h2>
  <asp:LoginView ID="LoginView1" runat="server">
    <RoleGroups>
      <asp:RoleGroup Roles="Guest">
        <ContentTemplate>
          You are currently logged in as <b>
            <asp:LoginName ID="LoginName1" runat="server" />
          </b>.
          <br />
          <br />
          <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </ContentTemplate>
      </asp:RoleGroup>
      <asp:RoleGroup Roles="RegisteredUser,SiteAdministrator">
        <ContentTemplate>
          You are currently logged in as <b>
            <asp:LoginName ID="LoginName2" runat="server" />
          </b>.
          <br />
          <br />
          <asp:ChangePassword ID="ChangePassword1" runat="server">
          </asp:ChangePassword>
          <br />
          <br />
          <asp:LoginStatus ID="LoginStatus2" runat="server" />
        </ContentTemplate>
      </asp:RoleGroup>
    </RoleGroups>
    <AnonymousTemplate>
      <asp:Login ID="Login1" runat="server">
      </asp:Login>
      <asp:PasswordRecovery ID="PasswordRecovery1" runat="Server" />
    </AnonymousTemplate>
  </asp:LoginView>
</asp:Content>
