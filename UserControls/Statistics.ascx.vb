Imports JobSiteStarterKit.BOL

Partial Class Statistics
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblCompanies.Text = Company.GetCompanyCount().ToString()
        lblJobs.Text = JobPosting.GetJobPostingCount().ToString()
        lblResumes.Text = [Resume].GetResumeCount().ToString()
    End Sub
End Class
