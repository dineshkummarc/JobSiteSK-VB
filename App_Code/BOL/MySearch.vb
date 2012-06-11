Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class MySearch
        Private intMySearchID As Integer
        Private strCriteria As String
        Private intCountryID As Integer
        Private intStateID As Integer
        Private strCity As String
        Private strUserName As String

        Public Property MySearchID() As Integer
            Get
                Return intMySearchID
            End Get
            Set(ByVal value As Integer)
                intMySearchID = value
            End Set
        End Property

        Public Property Criteria() As String
            Get
                Return strCriteria
            End Get
            Set(ByVal value As String)
                strCriteria = value
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

        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal value As String)
                strCity = value
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

        Public Shared Function Insert(ByVal s As MySearch) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@sSearchCriteria", s.Criteria)
            db.AddParameter("@iCountryID", s.CountryID)
            db.AddParameter("@iStateID", s.StateID)
            db.AddParameter("@iCity", s.City)
            db.AddParameter("@sUserName", s.UserName)
            Dim p As SqlParameter = New SqlParameter("@iMySearchID", SqlDbType.Int)
            p.Direction = ParameterDirection.Output
            db.AddParameter(p)
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_MySearches_Insert")
            If retval = 1 Then
                Return Integer.Parse(p.Value.ToString)
            Else
                Return -1
            End If
        End Function

        Public Shared Function GetMySearches(ByVal username As String) As DataSet
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@sUserName", username)
            Return db.ExecuteDataSet("JobsDb_MySearches_SelectForUser")
        End Function

        Public Shared Function GetMySearch(ByVal mysearchid As Integer) As MySearch
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iMySearchID", mysearchid)
            Dim dr As SqlDataReader = CType(db.ExecuteReader("JobsDb_MySearches_SelectOne"), SqlDataReader)
            If dr.HasRows Then
                Dim s As MySearch = New MySearch
                While dr.Read
                    s.MySearchID = dr.GetInt32(dr.GetOrdinal("mysearchid"))
                    s.Criteria = dr.GetString(dr.GetOrdinal("SearchCriteria"))
                    s.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"))
                    s.StateID = dr.GetInt32(dr.GetOrdinal("StateID"))
                    s.City = dr.GetString(dr.GetOrdinal("City"))
                    s.UserName = dr.GetString(dr.GetOrdinal("UserName"))
                End While
                dr.Close()
                Return s
            Else
                Return Nothing
            End If
        End Function

        Public Shared Function Delete(ByVal s As MySearch) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iMySearchID", s.MySearchID)
            Return db.ExecuteNonQuery("JobsDb_MySearches_Delete")
        End Function
    End Class
End Namespace