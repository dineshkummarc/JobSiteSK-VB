Imports JobSiteStarterKit.BOL

Partial Class viewresume
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("employerrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
        Dim r As [Resume] = [Resume].GetResume(Integer.Parse(Request.QueryString("id")))
        Dim p As ProfileCommon = Profile.GetProfile(r.UserName)
        lblName.Text = "Full Name : " + p.FirstName + " " + p.LastName
        lblEducation.Text = "Education Level : " + EducationLevel.GetEducationLevelName(r.EducationLevelID)
        lblExperience.Text = "Experience Level : " + ExperienceLevel.GetExperienceLevelName(r.ExperienceLevelID)
        lblCoveringLetter.Text = r.CoveringLetterText.Replace(vbCrLf, "<br>")
        lblResume.Text = r.ResumeText.Replace(vbCrLf, "<br>")
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/employer/resumesearch.aspx")
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim r As MyResume = New MyResume
        r.ResumeID = Integer.Parse(Request.QueryString("id"))
        r.UserName = Profile.UserName
        MyResume.Insert(r)
    End Sub

End Class
