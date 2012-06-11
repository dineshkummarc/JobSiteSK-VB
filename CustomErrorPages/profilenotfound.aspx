<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="profilenotfound.aspx.vb" Inherits="CustomErrorPages_profilenotfound" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <asp:Label ID="Label14" runat="server" SkinID="FormHeading" Text="Company Profile Not Found!"></asp:Label><br /><br />
    <asp:Label ID="Label1" runat="server" Text="You can add job postings only after filling your company profile. Your company profile was not found. Please click on the following link to fill your company profile."></asp:Label><br /><br />
    <asp:HyperLink ID="HyperLink1" runat="server">Fill Company Profile</asp:HyperLink><br />
</center>    
</asp:Content>

