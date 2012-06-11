
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Title = ConfigurationManager.AppSettings("pagetitle")
        HyperLink1.ImageUrl = "~/images/" + ConfigurationManager.AppSettings("sitelogo")
        lnkAds.NavigateUrl = "mailto:" + ConfigurationManager.AppSettings("advertiseemail")
        lnkWebmaster.NavigateUrl = "mailto:" + ConfigurationManager.AppSettings("webmasteremail")
    End Sub
End Class

