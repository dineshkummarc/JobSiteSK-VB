Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports JobSiteStarterKit.BOL

Partial Class companyprofile
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("employerrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
        If Not Page.IsPostBack Then
            ddlCountry.DataSource = Country.GetCountries
            ddlCountry.DataTextField = "CountryName"
            ddlCountry.DataValueField = "CountryID"
            ddlCountry.DataBind()
            Dim objCompany As Company = Company.GetCompany(Profile.UserName)
            If Not (objCompany Is Nothing) Then
                Dim li As ListItem
                txtCompanyName.Text = objCompany.CompanyName
                txtAddress1.Text = objCompany.Address1
                txtAddress2.Text = objCompany.Address2
                txtCity.Text = objCompany.City
                li = ddlState.Items.FindByValue(objCompany.StateID.ToString)
                If Not (li Is Nothing) Then
                    ddlState.ClearSelection()
                    li.Selected = True
                End If
                li = ddlCountry.Items.FindByValue(objCompany.CountryID.ToString)
                If Not (li Is Nothing) Then
                    ddlCountry.ClearSelection()
                    li.Selected = True
                    ddlState.DataSource = State.GetStates(Integer.Parse(ddlCountry.SelectedValue))
                    ddlState.DataTextField = "StateName"
                    ddlState.DataValueField = "StateID"
                    ddlState.DataBind()
                    li = ddlState.Items.FindByValue(objCompany.StateID.ToString)
                    If Not (li Is Nothing) Then
                        ddlState.ClearSelection()
                        li.Selected = True
                    End If
                End If
                txtZIP.Text = objCompany.ZIP
                txtPhone.Text = objCompany.Phone
                txtFax.Text = objCompany.Fax
                txtEmail.Text = objCompany.Email
                txtWebSiteUrl.Text = objCompany.WebSiteUrl
                txtProfile.Text = objCompany.BriefProfile
            End If
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim objCompany As Company = New Company
        objCompany.CompanyName = txtCompanyName.Text
        objCompany.Address1 = txtAddress1.Text
        objCompany.Address2 = txtAddress2.Text
        objCompany.City = txtCity.Text
        objCompany.StateID = Integer.Parse(ddlState.SelectedValue)
        objCompany.CountryID = Integer.Parse(ddlCountry.SelectedValue)
        objCompany.ZIP = txtZIP.Text
        objCompany.Phone = txtPhone.Text
        objCompany.Fax = txtFax.Text
        objCompany.Email = txtEmail.Text
        objCompany.WebSiteUrl = txtWebSiteUrl.Text
        objCompany.BriefProfile = txtProfile.Text
        objCompany.UserName = Profile.UserName
        If Not (Profile.Employer.CompanyID = -1) Then
            objCompany.CompanyID = CType(Profile.Employer.CompanyID, Integer)
            Company.Update(objCompany)
        Else
            Dim i As Integer = Company.Insert(objCompany)
            Profile.Employer.CompanyID = i
        End If
        lblMsg.Text = "Your company profile is updated!"

    End Sub

    Protected Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCountry.SelectedIndexChanged
        ddlState.DataSource = State.GetStates(Integer.Parse(ddlCountry.SelectedValue))
        ddlState.DataTextField = "StateName"
        ddlState.DataValueField = "StateID"
        ddlState.DataBind()
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/default.aspx")
    End Sub
End Class
