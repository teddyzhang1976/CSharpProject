<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Pro C# AJAX Library Demo</title>
</head>
<body>
  <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
      <Services>
        <asp:ServiceReference Path="~/SimpleService.asmx" />
      </Services>
    </asp:ScriptManager>
    
    <div>
      <h1>Pro C# AJAX Library Demo</h1>
      <input type="button" value="Test OOP Functionality" onclick="testOOP();" />
      <br />
      <asp:UpdatePanel runat="server" ID="UpdatePanel1" RenderMode="Inline">
        <ContentTemplate>
          <asp:Button runat="server" ID="testErrorDisplay" Text="Test Client-Side Error Display"
            OnClick="testErrorDisplay_Click" />
        </ContentTemplate>
      </asp:UpdatePanel>
      <span id="errorDisplay" style="color: Red;"></span>
      <br />
      <input type="button" value="Call Web Method" onclick="callWebMethod();" />
      <input type="text" id="xParam" value="32.7" style="width: 50px;" />
      x
      <input type="text" id="yParam" value="84.2" style="width: 50px;" />
      =
      <span id="webMethodResult" style="color: Blue;">Click button to calculate.</span>
    </div>
    <br />
    <div>
    </div>

    <script type="text/javascript" language="javascript">
    <!--
    
    ///////////////////////////
    // AJAX Library OOP code //
    ///////////////////////////
    
    // Register namespace.
    Type.registerNamespace("ProCSharp");
    
    // Define base class.
    ProCSharp.Shape = function(color, scaleFactor) {
      this._color = color;
      this._scaleFactor = scaleFactor;
    }

    ProCSharp.Shape.prototype = {

      get_Color : function() {
        return this._color;
      },
      
      set_Color : function(color) {
        this._color = color;
      },
      
      get_ScaleFactor : function() {
        return this._scaleFactor;
      },
      
      set_ScaleFactor : function(scaleFactor) {
        this._scaleFactor = scaleFactor;
      }
      
    }

    ProCSharp.Shape.registerClass('ProCSharp.Shape');

    // Define derived class.
    ProCSharp.Circle = function(color, scaleFactor, diameter) {
      ProCSharp.Circle.initializeBase(this, [color, scaleFactor]);
      this._diameter = diameter;
    }

    ProCSharp.Circle.prototype = {

      get_Diameter : function() {
        return this._diameter;
      },
      
      set_Diameter : function(diameter) {
        this._diameter = diameter;
      },
      
      get_Area : function() {
        return Math.PI * Math.pow((this._diameter * this._scaleFactor) / 2, 2);
      },
      
      describe : function() {
        var description = "This is a " + this._color + " circle with an area of " + this.get_Area();
        alert(description);
      }
    }

    ProCSharp.Circle.registerClass('ProCSharp.Circle',  ProCSharp.Shape);
    
    function testOOP()
    {
      // Test classes.
      var myCircle = new ProCSharp.Circle('red', 1.0, 4.4);
      myCircle.describe();
    }
    
    
    /////////////////////////
    // Error handling code //
    /////////////////////////
    
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    
    function EndRequestHandler(sender, args)
    {
       if (args.get_error() != undefined)
       {
           var errorMessage = args.get_error().message;
           args.set_errorHandled(true);
           $get('errorDisplay').innerHTML = errorMessage;
       }
    }
    
    
    //////////////////////////
    // Web method call code //
    //////////////////////////

    function callWebMethod()
    {
      SimpleService.Multiply(parseFloat($get('xParam').value), parseFloat($get('yParam').value), multiplyCallBack);
    }
    
    function multiplyCallBack(result)
    {
      $get('webMethodResult').innerHTML = result;
    }
    
    -->
    </script>

  </form>
</body>
</html>