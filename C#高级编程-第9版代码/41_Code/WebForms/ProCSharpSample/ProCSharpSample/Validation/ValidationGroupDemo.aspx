<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationGroupDemo.aspx.cs" Inherits="ProCSharpSample.Validation.ValidationGroupDemo" %>

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
                            ErrorMessage="Name required" ValidationGroup="Register">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="TextEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" ControlToValidate="TextEmail" Display="Dynamic"
                            ErrorMessage="Email required" ValidationGroup="Register">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                            runat="server" ControlToValidate="TextEmail" Display="Dynamic"
                            ErrorMessage="Please enter an email"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Register" ValidationGroup="Register" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
                <div>
            <table class="auto-style1">
                <tr>
                    <td>Event:</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server" ControlToValidate="TextName"
                            ErrorMessage="Name required" ValidationGroup="Event"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Date:</td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                            runat="server" ControlToValidate="TextEmail" Display="Dynamic"
                            ErrorMessage="Date required" ValidationGroup="Event"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Submit" ValidationGroup="Event" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
