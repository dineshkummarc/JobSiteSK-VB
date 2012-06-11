<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NotAuthorized.aspx.vb" Inherits="CustomErrorPages_NotAuthorized" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<center>
    <asp:Label ID="Label14" runat="server" SkinID="FormHeading" Text="You are not authorized to view this page!"></asp:Label><br /><br />
    <asp:Label ID="Label1" runat="server" Text="You may not have appropriate access rights to view this page."></asp:Label><br /><br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/default.aspx">Go to Home Page</asp:HyperLink><br />
</center>    

</asp:Content>

