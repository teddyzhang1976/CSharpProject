<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationDemo.aspx.cs" Inherits="ProCSharpSample.Validation.ValidationDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table class="auto-style1">
        <tr>
          <td>Name:</td>
          <td>
            <asp:TextBox ID="TextName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
              runat="server" ControlToValidate="TextName" 
              ErrorMessage="Name required">*</asp:RequiredFieldValidator>
          </td>
        </tr>
        <tr>
          <td>Email:</td>
          <td>
            <asp:TextBox ID="TextEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
              runat="server" ControlToValidate="TextEmail" Display="Dynamic" 
              ErrorMessage="Email required">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
              runat="server" ControlToValidate="TextEmail" Display="Dynamic" 
              ErrorMessage="Please enter an email" 
              ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Button ID="Button1" runat="server" Text="Register" />
          </td>
          <td>&nbsp;</td>
        </tr>
      </table>

    </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    </form>
</body>
</html>
