<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProCSharpAjaxSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Professional C# ASP.NET AJAX Sample</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <h1>Professional C# ASP.NET AJAX Sample</h1>
            This sample obtains a list of primes up to a maximum value.
      <br />
            Maximum:
      <asp:TextBox runat="server" ID="MaxValue" Text="2500" />
            <br />
            Result:
      <asp:UpdatePanel runat="server" ID="ResultPanel">
          <ContentTemplate>
              <asp:Button runat="server" ID="GoButton" Text="Calculate" OnClick="GoButtonClick" />
              <br />
              <asp:Label runat="server" ID="ResultLabel" />
              <br />
              <small>Panel render time: <%= DateTime.Now.ToLongTimeString() %>
              </small>
          </ContentTemplate>
      </asp:UpdatePanel>
            <asp:UpdateProgress runat="server" ID="UpdateProgress1">
                <ProgressTemplate>
                    <div style="position: absolute; left: 100px; top: 200px; padding: 40px 60px 40px 60px; background-color: lightyellow; border: black 1px solid; font-weight: bold; font-size: larger; filter: alpha(opacity=80);">
                        Updating.
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <small>Page render time: <%= DateTime.Now.ToLongTimeString() %></small>

        </div>
    </form>
</body>
</html>
