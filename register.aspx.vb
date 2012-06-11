
Partial Class register
    Inherits System.Web.UI.Page

    Protected Sub CreateUserWizard1_ContinueButtonClick(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("~/default.aspx")
    End Sub

    Protected Sub CreateUserWizard1_NextButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
        If CreateUserWizard1.ActiveStep.ID = "WizardStep2" Then
            Dim t As TextBox = CType(CreateUserWizard1.ActiveStep.FindControl("TextBox1"), TextBox)
            ViewState("firstname") = t.Text
            t = CType(CreateUserWizard1.ActiveStep.FindControl("TextBox2"), TextBox)
            ViewState("lastname") = t.Text
        End If
        If CreateUserWizard1.ActiveStep.ID = "WizardStep1" Then
            Dim objUser As MembershipUser = Membership.GetUser
            Dim ddl As DropDownList = CType(CreateUserWizard1.ActiveStep.FindControl("DropDownList1"), DropDownList)
            If Not (ddl Is Nothing) Then
                Roles.AddUserToRole(objUser.UserName, ddl.SelectedValue)
            End If
            Profile.UserName = objUser.UserName
            Profile.Email = objUser.Email
            Profile.FirstName = ViewState("firstname").ToString()
            Profile.LastName = ViewState("lastname").ToString()
            Profile.JobSeeker.ResumeID = -1
            Profile.Employer.CompanyID = -1
        End If
    End Sub

    Protected Sub CreateUserWizard1_ActiveStepChanged(ByVal sender As Object, ByVal e As EventArgs)
        If CreateUserWizard1.ActiveStep.ID = "WizardStep1" Then
            Dim ddl As DropDownList = CType(CreateUserWizard1.ActiveStep.FindControl("DropDownList1"), DropDownList)
            If Not (ddl Is Nothing) Then
                Dim li1 As ListItem = New ListItem("Job Seeker", ConfigurationManager.AppSettings("jobseekerrolename"))
                Dim li2 As ListItem = New ListItem("Employer", ConfigurationManager.AppSettings("employerrolename"))
                ddl.Items.Add(li1)
                ddl.Items.Add(li2)
            End If
        End If
    End Sub

End Class
