Imports AjaxControlToolkit

Partial Class LatestJobs
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If GridView1.Rows.Count = 0 Then
            Panel1.Visible = False
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim popup As PopupControlExtender = CType(e.Row.FindControl("PopupControlExtender1"), PopupControlExtender)
            popup.DynamicServicePath = "~/webservice.asmx"
        End If
    End Sub
End Class
