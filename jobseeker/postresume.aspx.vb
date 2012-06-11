Imports JobSiteStarterKit.BOL

Partial Class postresume
    Inherits System.Web.UI.Page

    Private r As [Resume]

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("jobseekerrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
        If Not Page.IsPostBack Then
            If Not (Profile.JobSeeker.ResumeID = -1) Then
                r = [Resume].GetResume(Profile.UserName)
                txtJobTitle.Text = r.JobTitle
                txtCity.Text = r.City
                txtResume.Text = r.ResumeText
                txtCoveringLetter.Text = r.CoveringLetterText
            End If
            FillCountries()
            FillEduLevels()
            FillExpLevels()
            FillJobTypes()
            FillStates()
        End If
    End Sub

    Private Sub FillCountries()
        ddlCountry.DataSource = Country.GetCountries
        ddlCountry.DataTextField = "CountryName"
        ddlCountry.DataValueField = "CountryID"
        ddlCountry.DataBind()
        ddlRelocationCountry.DataSource = Country.GetCountries
        ddlRelocationCountry.DataTextField = "CountryName"
        ddlRelocationCountry.DataValueField = "CountryID"
        ddlRelocationCountry.DataBind()
        If Not (Profile.JobSeeker.ResumeID = -1) Then
            Dim li As ListItem
            li = ddlCountry.Items.FindByValue(r.CountryID.ToString)
            If Not (li Is Nothing) Then
                ddlCountry.ClearSelection()
                li.Selected = True
            End If
            li = ddlRelocationCountry.Items.FindByValue(r.RelocationCountryID.ToString)
            If Not (li Is Nothing) Then
                ddlRelocationCountry.ClearSelection()
                li.Selected = True
            End If
        End If
    End Sub

    Private Sub FillStates()
        r = [Resume].GetResume(Profile.UserName)

        ddlState.DataSource = State.GetStates(Integer.Parse(ddlCountry.SelectedValue))
        ddlState.DataTextField = "StateName"
        ddlState.DataValueField = "StateID"
        ddlState.DataBind()
        If Not (Profile.JobSeeker.ResumeID = -1) Then
            Dim li As ListItem
            li = ddlState.Items.FindByValue(r.StateID.ToString)
            If Not (li Is Nothing) Then
                ddlState.ClearSelection()
                li.Selected = True
            End If
        End If
    End Sub

    Private Sub FillJobTypes()
        ddlJobType.DataSource = JobType.GetJobTypes
        ddlJobType.DataTextField = "JobTypeName"
        ddlJobType.DataValueField = "JobTypeID"
        ddlJobType.DataBind()
        If Not (Profile.JobSeeker.ResumeID = -1) Then
            Dim li As ListItem
            li = ddlJobType.Items.FindByValue(r.JobTypeID.ToString)
            If Not (li Is Nothing) Then
                ddlJobType.ClearSelection()
                li.Selected = True
            End If
        End If
    End Sub

    Private Sub FillEduLevels()
        ddlEduLevel.DataSource = EducationLevel.GetEducationLevels
        ddlEduLevel.DataTextField = "EducationLevelName"
        ddlEduLevel.DataValueField = "EducationLevelID"
        ddlEduLevel.DataBind()
        If Not (Profile.JobSeeker.ResumeID = -1) Then
            Dim li As ListItem
            li = ddlEduLevel.Items.FindByValue(r.EducationLevelID.ToString)
            If Not (li Is Nothing) Then
                ddlEduLevel.ClearSelection()
                li.Selected = True
            End If
        End If
    End Sub

    Private Sub FillExpLevels()
        ddlExpLevel.DataSource = ExperienceLevel.GetExperienceLevels
        ddlExpLevel.DataTextField = "ExperienceLevelName"
        ddlExpLevel.DataValueField = "ExperienceLevelID"
        ddlExpLevel.DataBind()
        If Not (Profile.JobSeeker.ResumeID = -1) Then
            Dim li As ListItem
            li = ddlExpLevel.Items.FindByValue(r.ExperienceLevelID.ToString)
            If Not (li Is Nothing) Then
                ddlExpLevel.ClearSelection()
                li.Selected = True
            End If
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim r As [Resume] = New [Resume]
        r.City = txtCity.Text
        r.CountryID = Integer.Parse(ddlCountry.SelectedValue)
        r.CoveringLetterText = txtCoveringLetter.Text
        r.EducationLevelID = Integer.Parse(ddlEduLevel.SelectedValue)
        r.ExperienceLevelID = Integer.Parse(ddlExpLevel.SelectedValue)
        r.JobTitle = txtJobTitle.Text
        r.JobTypeID = Integer.Parse(ddlJobType.SelectedValue)
        r.RelocationCountryID = Integer.Parse(ddlRelocationCountry.SelectedValue)
        r.ResumeText = txtResume.Text
        r.StateID = Integer.Parse(ddlState.SelectedValue)
        r.UserName = Profile.UserName
        r.PostedDate = DateTime.Now
        If Not (Profile.JobSeeker.ResumeID = -1) Then
            r.ResumeID = Profile.JobSeeker.ResumeID
            [Resume].Update(r)
        Else
            Dim retval As Integer = [Resume].Insert(r)
            Profile.JobSeeker.ResumeID = retval
        End If
        lblMsg.Text = "Your resume is successfully updated!"
    End Sub

    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCountry.SelectedIndexChanged
        FillStates()
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/default.aspx")
    End Sub

End Class
