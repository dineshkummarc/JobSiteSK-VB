
Partial Class UserControls_DisplayModeController
    Inherits System.Web.UI.UserControl

    Private manager As WebPartManager

    Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Init
        AddHandler Page.InitComplete, AddressOf InitComplete
    End Sub

    Sub InitComplete(ByVal sender As Object, ByVal e As System.EventArgs)
        manager = WebPartManager.GetCurrentWebPartManager(Page)
        Dim browseModeName As String = WebPartManager.BrowseDisplayMode.Name
        For Each mode As WebPartDisplayMode In manager.SupportedDisplayModes
            Dim modeName As String = mode.Name
            If mode.IsEnabled(manager) Then
                Dim item As ListItem = New ListItem(modeName, modeName)
                DisplayModeDropdown.Items.Add(item)
            End If
        Next
    End Sub

    Protected Sub DisplayModeDropdown_SelectedIndexChanged1(ByVal sender As Object, ByVal e As EventArgs)
        Dim selectedMode As String = DisplayModeDropdown.SelectedValue
        Dim mode As WebPartDisplayMode = manager.SupportedDisplayModes(selectedMode)
        If Not (mode Is Nothing) Then
            manager.DisplayMode = mode
        End If
    End Sub

End Class
