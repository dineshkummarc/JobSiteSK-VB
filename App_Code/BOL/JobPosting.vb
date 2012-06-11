Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class JobPosting
        Private intJobPostingID As Integer
        Private intCompanyID As Integer
        Private strContactPerson As String
        Private strTitle As String
        Private strDepartment As String
        Private strJobCode As String
        Private strCity As String
        Private intStateID As Integer
        Private intCountryID As Integer
        Private intEducationLevelID As Integer
        Private intJobTypeID As Integer
        Private dblMinSalary As Decimal
        Private dblMaxSalary As Decimal
        Private strDescription As String
        Private dtPostingDate As DateTime
        Private strPostedBy As String

        Public Property JobPostingID() As Integer
            Get
                Return intJobPostingID
            End Get
            Set(ByVal value As Integer)
                intJobPostingID = value
            End Set
        End Property

        Public Property CompanyID() As Integer
            Get
                Return intCompanyID
            End Get
            Set(ByVal value As Integer)
                intCompanyID = value
            End Set
        End Property

        Public Property ContactPerson() As String
            Get
                Return strContactPerson
            End Get
            Set(ByVal value As String)
                strContactPerson = value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal value As String)
                strTitle = value
            End Set
        End Property

        Public Property Department() As String
            Get
                Return strDepartment
            End Get
            Set(ByVal value As String)
                strDepartment = value
            End Set
        End Property

        Public Property JobCode() As String
            Get
                Return strJobCode
            End Get
            Set(ByVal value As String)
                strJobCode = value
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

        Public Property StateID() As Integer
            Get
                Return intStateID
            End Get
            Set(ByVal value As Integer)
                intStateID = value
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

        Public Property EducationLevelID() As Integer
            Get
                Return intEducationLevelID
            End Get
            Set(ByVal value As Integer)
                intEducationLevelID = value
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

        Public Property MinSalary() As Decimal
            Get
                Return dblMinSalary
            End Get
            Set(ByVal value As Decimal)
                dblMinSalary = value
            End Set
        End Property

        Public Property MaxSalary() As Decimal
            Get
                Return dblMaxSalary
            End Get
            Set(ByVal value As Decimal)
                dblMaxSalary = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal value As String)
                strDescription = value
            End Set
        End Property

        Public Property PostingDate() As DateTime
            Get
                Return dtPostingDate
            End Get
            Set(ByVal value As DateTime)
                dtPostingDate = value
            End Set
        End Property

        Public Property PostedBy() As String
            Get
                Return strPostedBy
            End Get
            Set(ByVal value As String)
                strPostedBy = value
            End Set
        End Property

        Public Shared Function Insert(ByVal p As JobPosting) As Integer
            Dim db As DBAccess = New DBAccess
            Dim objParam As SqlParameter = New SqlParameter("@iPostingID", 0)
            objParam.Direction = ParameterDirection.Output
            db.Parameters.Add(New SqlParameter("@iCompanyID", p.CompanyID))
            db.Parameters.Add(New SqlParameter("@sContactPerson", p.ContactPerson))
            db.Parameters.Add(New SqlParameter("@sTitle", p.Title))
            db.Parameters.Add(New SqlParameter("@sDepartment", p.Department))
            db.Parameters.Add(New SqlParameter("@sJobCode", p.JobCode))
            db.Parameters.Add(New SqlParameter("@sCity", p.City))
            db.Parameters.Add(New SqlParameter("@iStateID", p.StateID))
            db.Parameters.Add(New SqlParameter("@iCountryID", p.CountryID))
            db.Parameters.Add(New SqlParameter("@iEducationLevelID", p.EducationLevelID))
            db.Parameters.Add(New SqlParameter("@iJobTypeID", p.JobTypeID))
            db.Parameters.Add(New SqlParameter("@curMinSalary", p.MinSalary))
            db.Parameters.Add(New SqlParameter("@curMaxSalary", p.MaxSalary))
            db.Parameters.Add(New SqlParameter("@sJobDescription", p.Description))
            db.Parameters.Add(New SqlParameter("@daPostingDate", p.PostingDate))
            db.Parameters.Add(New SqlParameter("@sPostedBy", p.PostedBy))
            db.Parameters.Add(objParam)
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_JobPostings_Insert")
            If retval = 1 Then
                Return Integer.Parse(objParam.Value.ToString)
            Else
                Return -1
            End If
        End Function

        Public Shared Function Update(ByVal p As JobPosting) As Integer
            Dim db As DBAccess = New DBAccess
            db.Parameters.Add(New SqlParameter("@iPostingID", p.JobPostingID))
            db.Parameters.Add(New SqlParameter("@iCompanyID", p.CompanyID))
            db.Parameters.Add(New SqlParameter("@sContactPerson", p.ContactPerson))
            db.Parameters.Add(New SqlParameter("@sTitle", p.Title))
            db.Parameters.Add(New SqlParameter("@sDepartment", p.Department))
            db.Parameters.Add(New SqlParameter("@sJobCode", p.JobCode))
            db.Parameters.Add(New SqlParameter("@sCity", p.City))
            db.Parameters.Add(New SqlParameter("@iStateID", p.StateID))
            db.Parameters.Add(New SqlParameter("@iCountryID", p.CountryID))
            db.Parameters.Add(New SqlParameter("@iEducationLevelID", p.EducationLevelID))
            db.Parameters.Add(New SqlParameter("@iJobTypeID", p.JobTypeID))
            db.Parameters.Add(New SqlParameter("@curMinSalary", p.MinSalary))
            db.Parameters.Add(New SqlParameter("@curMaxSalary", p.MaxSalary))
            db.Parameters.Add(New SqlParameter("@sJobDescription", p.Description))
            db.Parameters.Add(New SqlParameter("@daPostingDate", p.PostingDate))
            db.Parameters.Add(New SqlParameter("@sPostedBy", p.PostedBy))
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_JobPostings_Update")
            Return retval
        End Function

        Public Shared Function Delete(ByVal p As JobPosting) As Integer
            Dim db As DBAccess = New DBAccess
            db.Parameters.Add(New SqlParameter("@iPostingID", p.JobPostingID))
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_JobPostings_Delete")
            Return retval
        End Function

        Public Shared Function GetPosting(ByVal id As Integer) As JobPosting
            Dim db As DBAccess = New DBAccess
            db.Parameters.Add(New SqlParameter("@iPostingID", id))
            Dim dr As SqlDataReader = CType(db.ExecuteReader("JobsDb_JobPostings_SelectOne"), SqlDataReader)
            If dr.HasRows Then
                Dim objJobPosting As JobPosting = New JobPosting
                While dr.Read
                    objJobPosting.JobPostingID = dr.GetInt32(dr.GetOrdinal("PostingID"))
                    objJobPosting.CompanyID = dr.GetInt32(dr.GetOrdinal("CompanyID"))
                    objJobPosting.Title = dr.GetString(dr.GetOrdinal("Title"))
                    objJobPosting.ContactPerson = dr.GetString(dr.GetOrdinal("ContactPerson"))
                    objJobPosting.Department = dr.GetString(dr.GetOrdinal("Department"))
                    objJobPosting.Description = dr.GetString(dr.GetOrdinal("JobDescription"))
                    objJobPosting.City = dr.GetString(dr.GetOrdinal("City"))
                    objJobPosting.StateID = dr.GetInt32(dr.GetOrdinal("StateID"))
                    objJobPosting.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"))
                    objJobPosting.EducationLevelID = dr.GetInt32(dr.GetOrdinal("EducationLevelID"))
                    objJobPosting.JobTypeID = dr.GetInt32(dr.GetOrdinal("JobTypeID"))
                    objJobPosting.JobCode = dr.GetString(dr.GetOrdinal("JobCode"))
                    objJobPosting.MinSalary = dr.GetDecimal(dr.GetOrdinal("MinSalary"))
                    objJobPosting.MaxSalary = dr.GetDecimal(dr.GetOrdinal("MaxSalary"))
                    objJobPosting.PostingDate = dr.GetDateTime(dr.GetOrdinal("PostingDate"))
                    objJobPosting.PostedBy = dr.GetString(dr.GetOrdinal("PostedBy"))
                End While
                dr.Close()
                Return objJobPosting
            Else
                dr.Close()
                Return New JobPosting
            End If
        End Function

        Public Shared Function GetPostings(ByVal username As String) As DataSet
            Dim db As DBAccess = New DBAccess
            db.Parameters.Add(New SqlParameter("@sUserName", username))
            Dim ds As DataSet = db.ExecuteDataSet("JobsDb_JobPostings_SelectByUser")
            Return ds
        End Function

        Public Shared Function SearchJobs(ByVal skills As String, ByVal countryid As Integer, ByVal stateid As Integer, ByVal city As String) As DataSet
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
                dsTemp = db.ExecuteDataSet("JobsDb_JobPostings_SelectForMatchingSkills")
                db.Parameters.Clear()
                ds.Merge(dsTemp)
                If flag = False Then
                    Dim pk(1) As DataColumn
                    pk(0) = ds.Tables(0).Columns("postingid")
                    ds.Tables(0).PrimaryKey = pk
                    flag = True
                End If
            Next
            Return ds
        End Function

        Public Shared Function GetJobPostingCount() As Integer
            Dim db As DBAccess = New DBAccess
            Return CType(db.ExecuteScalar("JobsDb_JobPostings_GetCount"), Integer)
        End Function

        Public Shared Function GetLatest() As DataSet
            Dim db As DBAccess = New DBAccess
            Return db.ExecuteDataSet("JobsDb_JobPostings_GetLatest")
        End Function

    End Class
End Namespace