<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
  CodeFile="Default.aspx.cs" Inherits="Default" Title="Pro C# Demo Site - About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>
    About</h2>
  <p>
    This is the about page for the site. There's not much to say really - it's an example
    site for Chapter 29 of Professional C# that illustrates several techniques for building
    ASP.NET web sites.
  </p>
  <h3>
    Master Pages</h3>
  <p>
    The site has a single master page, stored in MasterPage.master. This page includes
    the header, navigation, and content divs as well as linking to StyleSheet.css which
    includes size and positioning information for various site elements.
  </p>
  <h3>
    Security</h3>
  <p>
    A login system is in place whereby anonymous users are not permitted to view the
    site; instead they are redirected to a login page. The following roles are configured:
  </p>
  <ul>
    <li>Guest</li>
    <li>RegisteredUser</li>
    <li>SiteAdministrator</li>
  </ul>
  <p>
    The following users are also configured:
  </p>
  <ul>
    <li>Guest (Password: Guest!!; Roles: Guest)</li>
    <li>User1 (Password: User1!!; Roles: RegisteredUser)</li>
    <li>Admin (Password: Admin!!; Roles: RegisteredUser, SiteAdministrator)</li>
  </ul>
  <p>
    In all cases the user passwords are the same as the user names.
  </p>
  <h3>
    Navigation</h3>
  <p>
    Both a breadcrumb trail and menu are provided by using a site map, stored in Web.sitemap.
    A custom provider for the sitemap information is supplied in Web.config, since there
    is a user system in place and certain nodes of the site map are only viewable by
    certain users.
  </p>
  <h3>
    Themes</h3>
  <p>
    Users in the RegisteredUser or SiteAdministrator roles can modify the theme that
    the site is viewed in, either a default theme, a "bare" scheme, or a brightly colored
    theme. Both CSS stylesheets and control skinning is used to achieve this affect,
    and the current theme is stored in session state.
  </p>
  <p>
    To facilitate session information being used to dynamically choose the theme to
    use on each page, a custom page base class is used, MyPageBase.
  </p>
  <h3>
    User Controls</h3>
  <p>
    The Meeting Room Booker sample from Chapter 28 has been converted into a user control
    and appears on its own page, accessible via the site menu. Additional styling has
    been applied to this user control in order to tie into the themes system.
  </p>
</asp:Content>
