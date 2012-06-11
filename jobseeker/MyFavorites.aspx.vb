
Partial Class MyFavorites
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("jobseekerrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
    End Sub
End Class
