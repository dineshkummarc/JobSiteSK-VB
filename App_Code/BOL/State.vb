Imports System.Data
Imports JobSiteStarterKit.DAL

Namespace JobSiteStarterKit.BOL
    Public Class State
        Public Shared Function GetStates() As DataSet
            Dim db As DBAccess = New DBAccess
            Return db.ExecuteDataSet("JobsDb_States_SelectAll")
        End Function

        Public Shared Function GetStates(ByVal countryid As Integer) As DataSet
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iCountryID", countryid)
            Return db.ExecuteDataSet("JobsDb_States_SelectForCountry")
        End Function

        Public Shared Function GetStateName(ByVal id As Integer) As String
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iStateID", id)
            Return db.ExecuteScalar("JobsDb_States_GetStateName").ToString
        End Function

    End Class
End Namespace