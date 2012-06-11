Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class MyResume
        Private intMyResumeID As Integer
        Private intResumeID As Integer
        Private strUserName As String

        Public Property MyResumeID() As Integer
            Get
                Return intMyResumeID
            End Get
            Set(ByVal value As Integer)
                intMyResumeID = value
            End Set
        End Property

        Public Property ResumeID() As Integer
            Get
                Return intResumeID
            End Get
            Set(ByVal value As Integer)
                intResumeID = value
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

        Public Shared Function Insert(ByVal r As MyResume) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iResumeID", r.ResumeID)
            db.AddParameter("@sUserName", r.UserName)
            Dim p As SqlParameter = New SqlParameter("@iMyResumeID", SqlDbType.Int)
            p.Direction = ParameterDirection.Output
            db.AddParameter(p)
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_MyResumes_Insert")
            If retval = 1 Then
                Return Integer.Parse(p.Value.ToString)
            Else
                Return -1
            End If
        End Function

        Public Shared Function Delete(ByVal r As MyResume) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iMyResumeID", r.MyResumeID)
            Return db.ExecuteNonQuery("JobsDb_MyResumes_Delete")
        End Function

        Public Shared Function GetMyResumes(ByVal username As String) As DataSet
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@sUserName", username)
            Return db.ExecuteDataSet("JobsDb_MyResumes_SelectForUser")
        End Function
    End Class
End Namespace