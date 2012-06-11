Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class EducationLevel
        Private intEduLevelID As Integer
        Private strEduLevelName As String

        Public Property EducationLevelID() As Integer
            Get
                Return intEduLevelID
            End Get
            Set(ByVal value As Integer)
                intEduLevelID = value
            End Set
        End Property

        Public Property EducationLevelName() As String
            Get
                Return strEduLevelName
            End Get
            Set(ByVal value As String)
                strEduLevelName = value
            End Set
        End Property

        Public Shared Function GetEducationLevels() As DataSet
            Dim db As DBAccess = New DBAccess
            Return db.ExecuteDataSet("JobsDb_EducationLevels_SelectAll")
        End Function

        Public Shared Function GetEducationLevelName(ByVal id As Integer) As String
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iEducationLevelID", id)
            Return db.ExecuteScalar("JobsDb_EducationLevels_GetLevelName").ToString
        End Function

        Public Shared Function Insert(ByVal l As EducationLevel) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@sEducationLevelName", l.EducationLevelName)
            Dim p As SqlParameter = New SqlParameter("@iEducationLevelID", SqlDbType.Int)
            p.Direction = ParameterDirection.Output
            db.AddParameter(p)
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_EducationLevels_Insert")
            If retval = 1 Then
                Return Integer.Parse(p.Value.ToString)
            Else
                Return -1
            End If
        End Function

        Public Shared Function Update(ByVal l As EducationLevel) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iEducationLevelID", l.EducationLevelID)
            db.AddParameter("@sEducationLevelName", l.EducationLevelName)
            Return db.ExecuteNonQuery("JobsDb_EducationLevels_Update")
        End Function

        Public Shared Function Delete(ByVal e As EducationLevel) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iEducationLevelID", e.EducationLevelID)
            Return db.ExecuteNonQuery("JobsDb_EducationLevels_Delete")
        End Function
    End Class
End Namespace