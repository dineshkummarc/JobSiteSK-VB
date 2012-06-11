Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class [Resume]

        Private intResumeID As Integer
        Private strUserName As String
        Private strJobTitle As String
        Private strCity As String
        Private intCountryID As Integer
        Private intStateID As Integer
        Private intRelocationCountryID As Integer
        Private intJobTypeID As Integer
        Private intEduLevelID As Integer
        Private intExpLevelID As Integer
        Private strResumeText As String
        Private strCoveringLetterText As String
        Private dtPostedDate As DateTime

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

        Public Property JobTitle() As String
            Get
                Return strJobTitle
            End Get
            Set(ByVal value As String)
                strJobTitle = value
            End Set
        End Property

        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal value As String)
                strCity = value
            End Set
        End Property

        Public Property CountryID() As Integer
            Get
                Return intCountryID
            End Get
            Set(ByVal value As Integer)
                intCountryID = value
            End Set
        End Property

        Public Property StateID() As Integer
            Get
                Return intStateID
            End Get
            Set(ByVal value As Integer)
                intStateID = value
            End Set
        End Property

        Public Property RelocationCountryID() As Integer
            Get
                Return intRelocationCountryID
            End Get
            Set(ByVal value As Integer)
                intRelocationCountryID = value
            End Set
        End Property

        Public Property JobTypeID() As Integer
            Get
                Return intJobTypeID
            End Get
            Set(ByVal value As Integer)
                intJobTypeID = value
            End Set
        End Property

        Public Property EducationLevelID() As Integer
            Get
                Return intEduLevelID
            End Get
            Set(ByVal value As Integer)
                intEduLevelID = value
            End Set
        End Property

        Public Property ExperienceLevelID() As Integer
            Get
                Return intExpLevelID
            End Get
            Set(ByVal value As Integer)
                intExpLevelID = value
            End Set
        End Property

        Public Property ResumeText() As String
            Get
                Return strResumeText
            End Get
            Set(ByVal value As String)
                strResumeText = value
            End Set
        End Property

        Public Property CoveringLetterText() As String
            Get
                Return strCoveringLetterText
            End Get
            Set(ByVal value As String)
                strCoveringLetterText = value
            End Set
        End Property


        Public Property PostedDate() As DateTime
            Get
                Return dtPostedDate
            End Get
            Set(ByVal value As DateTime)
                dtPostedDate = value
            End Set
        End Property

        Public Shared Function GetResume(ByVal username As String) As [Resume]
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@sUserName", username)
            Dim dr As SqlDataReader = CType(db.ExecuteReader("JobsDb_Resumes_SelectForUser"), SqlDataReader)
            If dr.HasRows Then
                Dim r As [Resume] = New [Resume]
                While dr.Read
                    r.ResumeID = dr.GetInt32(dr.GetOrdinal("ResumeID"))
                    r.City = dr.GetString(dr.GetOrdinal("TargetCity"))
                    r.CountryID = dr.GetInt32(dr.GetOrdinal("TargetCountryID"))
                    r.CoveringLetterText = dr.GetString(dr.GetOrdinal("CoverLetterText"))
                    r.EducationLevelID = dr.GetInt32(dr.GetOrdinal("EducationLevelID"))
                    r.ExperienceLevelID = dr.GetInt32(dr.GetOrdinal("ExperienceLevelID"))
                    r.JobTitle = dr.GetString(dr.GetOrdinal("JobTitle"))
                    r.JobTypeID = dr.GetInt32(dr.GetOrdinal("TargetJobTypeID"))
                    r.RelocationCountryID = dr.GetInt32(dr.GetOrdinal("RelocationCountryID"))
                    r.ResumeText = dr.GetString(dr.GetOrdinal("ResumeText"))
                    r.StateID = dr.GetInt32(dr.GetOrdinal("TargetStateID"))
                    r.UserName = dr.GetString(dr.GetOrdinal("UserName"))
                    r.PostedDate = dr.GetDateTime(dr.GetOrdinal("PostDate"))
                End While
                dr.Close()
                Return r
            Else
                dr.Close()
                Dim r As [Resume] = New [Resume]
                r.ResumeID = -1
                Return r
            End If
        End Function

        Public Shared Function GetResume(ByVal resumeid As Integer) As [Resume]
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iResumeID", resumeid)
            Dim dr As SqlDataReader = CType(db.ExecuteReader("JobsDb_Resumes_SelectOne"), SqlDataReader)
            If dr.HasRows Then
                Dim r As [Resume] = New [Resume]
                While dr.Read
                    r.ResumeID = dr.GetInt32(dr.GetOrdinal("ResumeID"))
                    r.City = dr.GetString(dr.GetOrdinal("TargetCity"))
                    r.CountryID = dr.GetInt32(dr.GetOrdinal("TargetCountryID"))
                    r.CoveringLetterText = dr.GetString(dr.GetOrdinal("CoverLetterText"))
                    r.EducationLevelID = dr.GetInt32(dr.GetOrdinal("EducationLevelID"))
                    r.ExperienceLevelID = dr.GetInt32(dr.GetOrdinal("ExperienceLevelID"))
                    r.JobTitle = dr.GetString(dr.GetOrdinal("JobTitle"))
                    r.JobTypeID = dr.GetInt32(dr.GetOrdinal("TargetJobTypeID"))
                    r.RelocationCountryID = dr.GetInt32(dr.GetOrdinal("RelocationCountryID"))
                    r.ResumeText = dr.GetString(dr.GetOrdinal("ResumeText"))
                    r.StateID = dr.GetInt32(dr.GetOrdinal("TargetStateID"))
                    r.UserName = dr.GetString(dr.GetOrdinal("UserName"))
                    r.PostedDate = dr.GetDateTime(dr.GetOrdinal("PostDate"))
                End While
                dr.Close()
                Return r
            Else
                dr.Close()
                Return New [Resume]
            End If
        End Function

        Public Shared Function Insert(ByVal r As [Resume]) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@sJobTitle", r.JobTitle)
            db.AddParameter("@sTargetCity", r.City)
            db.AddParameter("@iTargateStateID", r.StateID)
            db.AddParameter("@iTargetCountryID", r.CountryID)
            db.AddParameter("@iRelocationCountryID", r.RelocationCountryID)
            db.AddParameter("@iTargetJobTypeID", r.JobTypeID)
            db.AddParameter("@iEducationLevelID", r.EducationLevelID)
            db.AddParameter("@iExperienceLevelID", r.ExperienceLevelID)
            db.AddParameter("@sResumeText", r.ResumeText)
            db.AddParameter("@sCoverLetterText", r.CoveringLetterText)
            db.AddParameter("@sUserName", r.UserName)
            db.AddParameter("@dtPostDate", r.PostedDate)
            Dim p As SqlParameter = New SqlParameter("@iResumeID", SqlDbType.Int)
            p.Direction = ParameterDirection.Output
            db.AddParameter(p)
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_Resumes_Insert")
            If retval <= 0 Then
                Return -1
            Else
                Return CType(p.Value, Integer)
            End If
        End Function

        Public Shared Function Update(ByVal r As [Resume]) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iResumeID", r.ResumeID)
            db.AddParameter("@sJobTitle", r.JobTitle)
            db.AddParameter("@sTargetCity", r.City)
            db.AddParameter("@iTargateStateID", r.StateID)
            db.AddParameter("@iTargetCountryID", r.CountryID)
            db.AddParameter("@iRelocationCountryID", r.RelocationCountryID)
            db.AddParameter("@iTargetJobTypeID", r.JobTypeID)
            db.AddParameter("@iEducationLevelID", r.EducationLevelID)
            db.AddParameter("@iExperienceLevelID", r.ExperienceLevelID)
            db.AddParameter("@sResumeText", r.ResumeText)
            db.AddParameter("@sCoverLetterText", r.CoveringLetterText)
            db.AddParameter("@sUserName", r.UserName)
            db.AddParameter("@dtPostDate", r.PostedDate)
            Return db.ExecuteNonQuery("JobsDb_Resumes_Update")
        End Function

        Public Shared Function Delete(ByVal ResumeID As Integer) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iResumeID", ResumeID)
            Return db.ExecuteNonQuery("JobsDb_Resumes_Delete")
        End Function

        Public Shared Function GetResumeID(ByVal username As String) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@sUserName", username)
            Dim dr As SqlDataReader = CType(db.ExecuteReader("JobsDb_Resumes_SelectForUser"), SqlDataReader)
            Dim resumeid As Integer = -1
            If dr.HasRows Then
                While dr.Read
                    resumeid = dr.GetInt32(dr.GetOrdinal("ResumeID"))
                End While
                dr.Close()
            End If
            Return resumeid
        End Function

        Public Shared Function SearchResumes(ByVal skills As String, ByVal countryid As Integer, ByVal stateid As Integer, ByVal city As String) As DataSet
            Dim arr As String() = skills.Split(" "c)
            Dim ds As DataSet = New DataSet
            Dim dsTemp As DataSet = New DataSet
            Dim flag As Boolean = False
            Dim db As DBAccess = New DBAccess
            For Each s As String In arr
                db.AddParameter("@sSkill", s)
                If countryid = -1 Then
                    db.AddParameter("@iCountryID", DBNull.Value)
                Else
                    db.AddParameter("@iCountryID", countryid)
                End If
                If stateid = -1 Then
                    db.AddParameter("@iStateID", DBNull.Value)
                Else
                    db.AddParameter("@iStateID", stateid)
                End If
                If city = "" Then
                    db.AddParameter("@sCity", DBNull.Value)
                Else
                    db.AddParameter("@sCity", city)
                End If
                dsTemp = db.ExecuteDataSet("JobsDb_Resumes_SelectForMatchingSkills")
                db.Parameters.Clear()
                ds.Merge(dsTemp)
                If flag = False Then
                    Dim pk(1) As DataColumn
                    pk(0) = ds.Tables(0).Columns("resumeid")
                    ds.Tables(0).PrimaryKey = pk
                    flag = True
                End If
            Next
            Return ds
        End Function

        Public Shared Function GetResumeCount() As Integer
            Dim db As DBAccess = New DBAccess
            Return CType(db.ExecuteScalar("JobsDb_Resumes_GetCount"), Integer)
        End Function

    End Class
End Namespace