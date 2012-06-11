Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class MyJob
        Private intMyJobID As Integer
        Private intPostingID As Integer
        Private strUserName As String

        Public Property MyJobID() As Integer
            Get
                Return intMyJobID
            End Get
            Set(ByVal value As Integer)
                intMyJobID = value
            End Set
        End Property

        Public Property PostingID() As Integer
            Get
                Return intPostingID
            End Get
            Set(ByVal value As Integer)
                intPostingID = value
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return strUserName
            End Get
            Set(ByVal value As String)
                strUserName = value
            End Set
        End Property

        Public Shared Function Insert(ByVal j As MyJob) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iPostingID", j.PostingID)
            db.AddParameter("@sUserName", j.UserName)
            Dim p As SqlParameter = New SqlParameter("@iMyJobID", SqlDbType.Int)
            p.Direction = ParameterDirection.Output
            db.AddParameter(p)
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_MyJobs_Insert")
            If retval = 1 Then
                Return Integer.Parse(p.Value.ToString)
            Else
                Return -1
            End If
        End Function

        Public Shared Function Delete(ByVal j As MyJob) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iMyJobID", j.MyJobID)
            Return db.ExecuteNonQuery("JobsDb_MyJobs_Delete")
        End Function

        Public Shared Function GetMyJobs(ByVal username As String) As DataSet
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@sUserName", username)
            Return db.ExecuteDataSet("JobsDb_MyJobs_SelectForUser")
        End Function
    End Class
End Namespace