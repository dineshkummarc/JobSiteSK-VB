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

Partial Public Class AddEditPosting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Roles.IsUserInRole(ConfigurationManager.AppSettings("employerrolename")) Then
            Response.Redirect("~/customerrorpages/NotAuthorized.aspx")
        End If
        If Not Page.IsPostBack Then
            If Company.GetCompany(User.Identity.Name) Is Nothing Then
                Response.Redirect("~/customerrorpages/profilenotfound.aspx")
            End If
            If Request.QueryString("id") Is Nothing Then
                DetailsView1.DefaultMode = DetailsViewMode.Insert
            Else
                DetailsView1.DefaultMode = DetailsViewMode.ReadOnly
            End If
        End If
    End Sub

    Protected Sub DetailsView1_ItemInserting(ByVal sender As Object, ByVal e As DetailsViewInsertEventArgs)
        Dim ddl As DropDownList
        ddl = CType(DetailsView1.FindControl("ddlStateInsert"), DropDownList)
        e.Values("StateID") = ddl.SelectedValue
        ddl = CType(DetailsView1.FindControl("ddlCountryInsert"), DropDownList)
        e.Values("CountryID") = ddl.SelectedValue
        ddl = CType(DetailsView1.FindControl("ddlEduLevelInsert"), DropDownList)
        e.Values("EducationLevelID") = ddl.SelectedValue
        ddl = CType(DetailsView1.FindControl("ddlJobTypeInsert"), DropDownList)
        e.Values("JobTypeID") = ddl.SelectedValue
        e.Values("PostedBy") = Profile.UserName
        e.Values("CompanyID") = Profile.Employer.CompanyID.ToString
        e.Values("PostingDate") = DateTime.Today.ToString("MM/dd/yyyy")
    End Sub

    Protected Sub DetailsView1_ItemUpdating(ByVal sender As Object, ByVal e As DetailsViewUpdateEventArgs)
        Dim ddl As DropDownList
        ddl = CType(DetailsView1.FindControl("ddlStateUpdate"), DropDownList)
        e.NewValues("StateID") = ddl.SelectedValue
        ddl = CType(DetailsView1.FindControl("ddlCountryUpdate"), DropDownList)
        e.NewValues("CountryID") = ddl.SelectedValue
        ddl = CType(DetailsView1.FindControl("ddlEduLevelUpdate"), DropDownList)
        e.NewValues("EducationLevelID") = ddl.SelectedValue
        ddl = CType(DetailsView1.FindControl("ddlJobTypeUpdate"), DropDownList)
        e.NewValues("JobTypeID") = ddl.SelectedValue
        e.NewValues("PostedBy") = Profile.UserName
        e.NewValues("CompanyID") = Profile.Employer.CompanyID.ToString
        e.NewValues("PostingDate") = DateTime.Today.ToString("MM/dd/yyyy")
    End Sub

    Protected Sub DetailsView1_ItemDeleted(ByVal sender As Object, ByVal e As DetailsViewDeletedEventArgs) Handles DetailsView1.ItemDeleted
        Response.Redirect("~/employer/jobpostings.aspx")
    End Sub

    Protected Sub ddlCountryUpdate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim ddl As DropDownList
        ddl = CType(sender, DropDownList)
        ObjectDataSource2.SelectParameters("countryid").DefaultValue = ddl.SelectedValue
        ObjectDataSource2.Select()
    End Sub

    Protected Sub ddlCountryInsert_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim ddl As DropDownList
        ddl = CType(sender, DropDownList)
        ObjectDataSource2.SelectParameters("countryid").DefaultValue = ddl.SelectedValue
        ObjectDataSource2.Select()
    End Sub

    Protected Sub DetailsView1_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles DetailsView1.DataBound
        Dim ddl As DropDownList
        ddl = CType(DetailsView1.FindControl("ddlCountryUpdate"), DropDownList)
        If Not (ddl Is Nothing) Then
            ObjectDataSource2.SelectParameters("countryid").DefaultValue = ddl.SelectedValue
            ObjectDataSource2.Select()
        End If
    End Sub

End Class
