
Partial Class jobpostings
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("employerrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "edit" Then
            Response.Redirect("~/employer/addeditposting.aspx?id=" + e.CommandArgument.ToString())
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim b As ImageButton = CType(e.Row.Cells(4).Controls(0), ImageButton)
            b.CommandName = "edit"
            b.CommandArgument = GridView1.DataKeys(e.Row.RowIndex).Value.ToString
        End If
    End Sub

End Class
