
Partial Class CustomErrorPages_profilenotfound
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HyperLink1.NavigateUrl = "~/employer/companyprofile.aspx"
    End Sub
End Class
