<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Target.aspx.cs" Inherits="Target" %>

<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
    <asp:PlaceHolder ID="targetParameterPlaceholder" runat="server">
        targetparameter = <asp:Label runat="server" Text="<%$ RouteValue:targetparameter %>" />
        <asp:Label runat="server" ID="yesnomatch" />
        <br />
    </asp:PlaceHolder>
    <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>
</asp:Content>

