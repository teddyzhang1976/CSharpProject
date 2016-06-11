<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Default.aspx.cs"
  Title="Pro C# Demo Site - Configuration - Themes" inherits="Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
  <h2>Theme Configuration</h2>
  Select a theme:
  <br />
  <ul>
    <li>
    <asp:LinkButton Runat="server" ID="applyDefaultTheme" OnClick="applyDefaultTheme_Click"
      Text="Apply Default Theme" />
    </li>
    <li>
    <asp:LinkButton Runat="server" ID="applyBareTheme" OnClick="applyBareTheme_Click"
      Text="Apply Bare Theme" />
    </li>
    <li>
    <asp:LinkButton Runat="server" ID="applyLuridTheme" OnClick="applyLuridTheme_Click"
      Text="Apply Lurid Theme" />
    </li>
  </ul>
</asp:Content>
