<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PCSMVCMagicShop.Models.Product>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Edit</h2>
  <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>
  <% using (Html.BeginForm())
     {%>
  <fieldset>
    <legend>Fields</legend>
    <%= Html.Hidden("ProductId", Model.ProductId) %>
    <p>
      <label for="Name">
        Name:</label>
      <%= Html.TextBox("Name", Model.Name) %>
      <%= Html.ValidationMessage("Name", "*") %>
    </p>
    <p>
      <label for="Description">
        Description:</label>
      <%= Html.TextBox("Description", Model.Description) %>
      <%= Html.ValidationMessage("Description", "*") %>
    </p>
    <p>
      <label for="Cost">
        Cost:</label>
      <%= Html.TextBox("Cost", String.Format("{0:F}", Model.Cost)) %>
      <%= Html.ValidationMessage("Cost", "*") %>
    </p>
    <p>
      <input type="submit" value="Save" />
    </p>
  </fieldset>
  <% } %>
  <div>
    <%=Html.ActionLink("Back to List", "Index") %>
  </div>
</asp:Content>
