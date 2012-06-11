Imports JobSiteStarterKit.BOL

Partial Class viewjobposting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("jobseekerrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
        If Not Page.IsPostBack Then
            Dim postingid As Integer
            postingid = Integer.Parse(Request.QueryString("id"))

            Dim p As JobPosting = JobPosting.GetPosting(postingid)

            lblCity.Text = p.City
            lblCompany.Text = Company.GetCompanyName(p.CompanyID)

            btnViewProfile.CommandArgument = p.CompanyID.ToString()
            ModalPopupExtender1.DynamicContextKey = p.CompanyID.ToString()

            lblContactPerson.Text = p.ContactPerson
            lblCountry.Text = Country.GetCountryName(p.CountryID)
            lblDept.Text = p.Department
            lblDesc.Text = p.Description.Replace(vbCrLf, "<br>")
            lblEduLevel.Text = EducationLevel.GetEducationLevelName(p.EducationLevelID)
            lblJobCode.Text = p.JobCode
            lblJobType.Text = JobType.GetJobTypeName(p.JobTypeID)
            lblMaxSal.Text = p.MaxSalary.ToString("C")
            lblMinSal.Text = p.MinSalary.ToString("C")
            lblPostDt.Text = p.PostingDate.ToShortDateString
            lblState.Text = State.GetStateName(p.StateID)
            lblTitle.Text = p.Title
        End If

        Page.DataBind()
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/jobseeker/jobsearch.aspx")
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim j As MyJob = New MyJob
        j.PostingID = Integer.Parse(Request.QueryString("id"))
        j.UserName = Profile.UserName
        MyJob.Insert(j)
    End Sub

End Class
