<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
  CodeFile="Default.aspx.cs" Title="Pro C# Demo Site - Meeting Room Booker" Inherits="Default" %>

<%@ Register TagPrefix="uc1" TagName="MRB" Src="MRB.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>
    Meeting Room Booker</h2>
  <uc1:mrb id="MRB1" runat="server">
  </uc1:mrb>
</asp:Content>
