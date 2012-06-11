Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class ExperienceLevel
        Private intExpLevelID As Integer
        Private strExpLevelName As String

        Public Property ExperienceLevelID() As Integer
            Get
                Return intExpLevelID
            End Get
            Set(ByVal value As Integer)
                intExpLevelID = value
            End Set
        End Property

        Public Property ExperienceLevelName() As String
            Get
                Return strExpLevelName
            End Get
            Set(ByVal value As String)
                strExpLevelName = value
            End Set
        End Property

        Public Shared Function GetExperienceLevels() As DataSet
            Dim db As DBAccess = New DBAccess
            Return db.ExecuteDataSet("JobsDb_ExperienceLevels_SelectAll")
        End Function

        Public Shared Function Insert(ByVal l As ExperienceLevel) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@sExperienceLevelName", l.ExperienceLevelName)
            Dim p As SqlParameter = New SqlParameter("@iExperienceLevelID", SqlDbType.Int)
            p.Direction = ParameterDirection.Output
            db.AddParameter(p)
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_ExperienceLevels_Insert")
            If retval = 1 Then
                Return Integer.Parse(p.Value.ToString)
            Else
                Return -1
            End If
        End Function

        Public Shared Function Update(ByVal l As ExperienceLevel) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iExperienceLevelID", l.ExperienceLevelID)
            db.AddParameter("@sExperienceLevelName", l.ExperienceLevelName)
            Return db.ExecuteNonQuery("JobsDb_ExperienceLevels_Update")
        End Function

        Public Shared Function Delete(ByVal l As ExperienceLevel) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iExperienceLevelID", l.ExperienceLevelID)
            Return db.ExecuteNonQuery("JobsDb_ExperienceLevels_Delete")
        End Function

        Public Shared Function GetExperienceLevelName(ByVal id As Integer) As String
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iExperienceLevelID", id)
            Return db.ExecuteScalar("JobsDb_ExperienceLevels_GetLevelName").ToString
        End Function
    End Class
End Namespace