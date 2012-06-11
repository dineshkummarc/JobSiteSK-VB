Imports JobSiteStarterKit.BOL
Imports System.Data

Partial Class jobsearch
    Inherits System.Web.UI.Page

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim b As ImageButton = CType(e.Row.Cells(4).Controls(0), ImageButton)
            b.CommandName = "viewdetails"
            b.CommandArgument = GridView1.DataKeys(e.Row.RowIndex).Value.ToString
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "viewdetails" Then
            Response.Redirect("~/jobseeker/viewjobposting.aspx?id=" + e.CommandArgument.ToString())
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("jobseekerrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
        If Not Page.IsPostBack Then
            FillCountries()
            FillStates()
            lblJobCount.Text = "(Currently we have " + JobPosting.GetJobPostingCount.ToString() + " jobs!!!)"
            If Not (Request.QueryString("mysearchid") Is Nothing) Then
                Dim s As MySearch = MySearch.GetMySearch(Integer.Parse(Request.QueryString("mysearchid")))
                txtSkills.Text = s.Criteria
                txtCity.Text = s.City
                ddlCountry.SelectedIndex = s.CountryID
                FillStates()
                Dim li As ListItem = ddlState.Items.FindByValue(s.StateID.ToString)
                If Not (li Is Nothing) Then
                    ddlState.ClearSelection()
                    li.Selected = True
                End If
                Exit Sub
            End If
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

    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCountry.SelectedIndexChanged
        FillStates()
        txtCity.Enabled = False
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        BindGrid()
    End Sub

    Private Sub BindGrid()
        Dim countryid As Integer = -1
        Dim stateid As Integer = -1
        If Not (ddlCountry.SelectedItem Is Nothing) Then
            countryid = Integer.Parse(ddlCountry.SelectedValue)
        End If
        If Not (ddlState.SelectedItem Is Nothing) Then
            stateid = Integer.Parse(ddlState.SelectedValue)
        End If
        Dim ds As DataSet
        ds = JobPosting.SearchJobs(txtSkills.Text, countryid, stateid, txtCity.Text)
        GridView1.DataSource = ds
        GridView1.DataBind()

        If GridView1.Rows.Count <= 0 Then
            lblMsg.Text = "No records found!"
        Else
            lblMsg.Text = ""
        End If

        UpdatePanel2.Update()
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub

    Protected Sub ImageButton3_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim s As MySearch = New MySearch
        s.Criteria = txtSkills.Text
        s.CountryID = Integer.Parse(ddlCountry.SelectedValue)
        s.StateID = Integer.Parse(ddlState.SelectedValue)
        s.City = txtCity.Text
        s.UserName = Profile.UserName
        MySearch.Insert(s)
    End Sub

    Protected Sub ddlState_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlState.SelectedIndexChanged
        If ddlState.SelectedIndex > 0 Then
            txtCity.Enabled = True
        Else
            txtCity.Enabled = False
        End If
    End Sub
End Class
