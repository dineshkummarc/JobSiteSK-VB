Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Public Class ExperienceLevelManager_aspx
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("adminrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
        If DetailsView1.Rows.Count < 1 Then
            DetailsView1.DefaultMode = DetailsViewMode.Insert
        Else
            DetailsView1.DefaultMode = DetailsViewMode.ReadOnly
        End If
    End Sub

    Protected Sub DetailsView1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Protected Sub ObjectDataSource1_Selected(ByVal sender As Object, ByVal e As ObjectDataSourceStatusEventArgs)
    End Sub

    Protected Sub DetailsView1_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
    End Sub
End Class