Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class JobType

        Public Sub New()
        End Sub

        Public Shared Function GetJobTypes() As DataSet
            Dim db As DBAccess = New DBAccess
            Return db.ExecuteDataSet("JobsDb_JobTypes_SelectAll")
        End Function

        Public Shared Function GetJobTypeName(ByVal id As Integer) As String
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iJobTypeID", id)
            Return db.ExecuteScalar("JobsDb_JobTypes_GetTypeName").ToString
        End Function
    End Class
End Namespace