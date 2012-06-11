Imports System.Data
Imports JobSiteStarterKit.BOL

Partial Class resumesearch
    Inherits System.Web.UI.Page

    Private Sub BindGrid()
        Dim countryid As Integer = -1
        Dim stateid As Integer = -1
        If Not (ddlCountry.SelectedItem Is Nothing) Then
            countryid = Integer.Parse(ddlCountry.SelectedValue)
        End If
        If Not (ddlState.SelectedItem Is Nothing) Then
            stateid = Integer.Parse(ddlState.SelectedValue)
        End If
        Dim ds As DataSet = [Resume].SearchResumes(txtSkills.Text, countryid, stateid, txtCity.Text)
        GridView1.DataSource = ds
        GridView1.DataBind()

        If GridView1.Rows.Count <= 0 Then
            lblMsg.Text = "No records found!"
        Else
            lblMsg.Text = ""
        End If

        UpdatePanel2.Update()

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim b As ImageButton = CType(e.Row.Cells(4).Controls(0), ImageButton)
            b.CommandName = "viewdetails"
            b.CommandArgument = GridView1.DataKeys(e.Row.RowIndex).Value.ToString

            e.Row.Cells(1).Text = EducationLevel.GetEducationLevelName(Integer.Parse(e.Row.Cells(1).Text))
            e.Row.Cells(2).Text = ExperienceLevel.GetExperienceLevelName(Integer.Parse(e.Row.Cells(2).Text))

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("employerrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
        If Not Page.IsPostBack Then
            FillCountries()
            FillStates()
            lblResumeCount.Text = "(Currently we have " + [Resume].GetResumeCount.ToString() + " resumes !!!)"
        End If
    End Sub

    Private Sub FillCountries()
        ddlCountry.DataSource = Country.GetCountries
        ddlCountry.DataTextField = "CountryName"
        ddlCountry.DataValueField = "CountryID"
        ddlCountry.DataBind()
    End Sub

    Private Sub FillStates()
        ddlState.DataSource = State.GetStates(Integer.Parse(ddlCountry.SelectedValue))
        ddlState.DataTextField = "StateName"
        ddlState.DataValueField = "StateID"
        ddlState.DataBind()
    End Sub

    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        FillStates()
        txtCity.Enabled = False
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "viewdetails" Then
            Response.Redirect("~/employer/viewresume.aspx?id=" + e.CommandArgument.ToString())
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub ddlState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlState.SelectedIndexChanged
        If ddlState.SelectedIndex > 0 Then
            txtCity.Enabled = True
        Else
            txtCity.Enabled = False
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        BindGrid()
    End Sub

End Class
