<%@ Page Language="VB" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="false" CodeFile="ExperienceLevelManager.aspx.vb" Inherits="ExperienceLevelManager_aspx" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
<div align=center>
    <asp:Label ID="Label14" Runat="server" SkinID="FormHeading" Text="Experience Levels Manager"></asp:Label><br />
    <br />
    <asp:DetailsView ID="DetailsView1" Runat="server" DataSourceID="ObjectDataSource1"
        AllowPaging="True" AutoGenerateRows="False" GridLines="None" CellPadding="5" DataKeyNames="ExperienceLevelID" SkinID="AdminEntry" OnDataBound="DetailsView1_DataBound" OnDataBinding="DetailsView1_DataBinding">
        <PagerSettings Mode="NumericFirstLast"></PagerSettings>
        <CommandRowStyle HorizontalAlign="Left"></CommandRowStyle>
        <Fields>
            <asp:CommandField ButtonType="Image" ShowDeleteButton="True" ShowInsertButton="True"
                ShowEditButton="True" CancelImageUrl="~/Images/CancelButton.gif" 
                DeleteImageUrl="~/Images/DeleteButton.gif" 
                EditImageUrl="~/Images/EditButton.gif" InsertImageUrl="~/Images/SaveButton.gif" 
                NewImageUrl="~/Images/AddButton.gif" UpdateImageUrl="~/Images/SaveButton.gif"></asp:CommandField>
            <asp:BoundField ReadOnly="True" HeaderText="Experience Level ID :" InsertVisible="False"
                DataField="experiencelevelid">
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Experience Level Name :" DataField="experiencelevelname">
                <ItemStyle HorizontalAlign="Left"></ItemStyle>
            </asp:BoundField>
        </Fields>
        <FieldHeaderStyle HorizontalAlign="Right"></FieldHeaderStyle>
        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
        <EditRowStyle HorizontalAlign="Left"></EditRowStyle>
    </asp:DetailsView><br />
    <asp:ObjectDataSource ID="ObjectDataSource1" Runat="server" TypeName="JobSiteStarterKit.BOL.ExperienceLevel" DataObjectTypeName="JobSiteStarterKit.BOL.ExperienceLevel"
        DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetExperienceLevels"
        UpdateMethod="Update" OnSelected="ObjectDataSource1_Selected">
    </asp:ObjectDataSource>
    
    </div>
    
    </asp:Content>
