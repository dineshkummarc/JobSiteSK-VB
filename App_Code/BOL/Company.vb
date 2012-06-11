Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class Company
        Private intCompanyID As Integer
        Private strUserName As String
        Private strCompanyName As String
        Private strBriefProfile As String
        Private strAddress1 As String
        Private strAddress2 As String
        Private strCity As String
        Private intStateID As Integer
        Private intCountryID As Integer
        Private strZIP As String
        Private strPhone As String
        Private strFax As String
        Private strEmail As String
        Private strWebSiteUrl As String

        Public Property CompanyID() As Integer
            Get
                Return intCompanyID
            End Get
            Set(ByVal value As Integer)
                intCompanyID = value
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

        Public Property CompanyName() As String
            Get
                Return strCompanyName
            End Get
            Set(ByVal value As String)
                strCompanyName = value
            End Set
        End Property

        Public Property BriefProfile() As String
            Get
                Return strBriefProfile
            End Get
            Set(ByVal value As String)
                strBriefProfile = value
            End Set
        End Property

        Public Property Address1() As String
            Get
                Return strAddress1
            End Get
            Set(ByVal value As String)
                strAddress1 = value
            End Set
        End Property

        Public Property Address2() As String
            Get
                Return strAddress2
            End Get
            Set(ByVal value As String)
                strAddress2 = value
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

        Public Property ZIP() As String
            Get
                Return strZIP
            End Get
            Set(ByVal value As String)
                strZIP = value
            End Set
        End Property

        Public Property Phone() As String
            Get
                Return strPhone
            End Get
            Set(ByVal value As String)
                strPhone = value
            End Set
        End Property

        Public Property Fax() As String
            Get
                Return strFax
            End Get
            Set(ByVal value As String)
                strFax = value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal value As String)
                strEmail = value
            End Set
        End Property

        Public Property WebSiteUrl() As String
            Get
                Return strWebSiteUrl
            End Get
            Set(ByVal value As String)
                strWebSiteUrl = value
            End Set
        End Property

        Public Shared Function Insert(ByVal c As Company) As Integer
            Dim db As DBAccess = New DBAccess
            Dim objParam As SqlParameter = New SqlParameter("@iCompanyID", 0)
            objParam.Direction = ParameterDirection.Output
            db.Parameters.Add(New SqlParameter("@sUserName", c.UserName))
            db.Parameters.Add(New SqlParameter("@sCompanyName", c.CompanyName))
            db.Parameters.Add(New SqlParameter("@sAddress1", c.Address1))
            db.Parameters.Add(New SqlParameter("@sAddress2", c.Address2))
            db.Parameters.Add(New SqlParameter("@sCity", c.City))
            db.Parameters.Add(New SqlParameter("@iStateID", c.StateID))
            db.Parameters.Add(New SqlParameter("@iCountryID", c.CountryID))
            db.Parameters.Add(New SqlParameter("@sZip", c.ZIP))
            db.Parameters.Add(New SqlParameter("@sPhone", c.Phone))
            db.Parameters.Add(New SqlParameter("@sFax", c.Fax))
            db.Parameters.Add(New SqlParameter("@sCompanyEmail", c.Email))
            db.Parameters.Add(New SqlParameter("@sWebSiteUrl", c.WebSiteUrl))
            db.Parameters.Add(New SqlParameter("@sCompanyProfile", c.BriefProfile))
            db.Parameters.Add(objParam)
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_Companies_Insert")
            If retval = 1 Then
                Return Integer.Parse(objParam.Value.ToString)
            Else
                Return -1
            End If
        End Function

        Public Shared Function Update(ByVal c As Company) As Integer
            Dim db As DBAccess = New DBAccess
            db.Parameters.Add(New SqlParameter("@iCompanyID", c.CompanyID))
            db.Parameters.Add(New SqlParameter("@sUserName", c.UserName))
            db.Parameters.Add(New SqlParameter("@sCompanyName", c.CompanyName))
            db.Parameters.Add(New SqlParameter("@sAddress1", c.Address1))
            db.Parameters.Add(New SqlParameter("@sAddress2", c.Address2))
            db.Parameters.Add(New SqlParameter("@sCity", c.City))
            db.Parameters.Add(New SqlParameter("@iStateID", c.StateID))
            db.Parameters.Add(New SqlParameter("@iCountryID", c.CountryID))
            db.Parameters.Add(New SqlParameter("@sZip", c.ZIP))
            db.Parameters.Add(New SqlParameter("@sPhone", c.Phone))
            db.Parameters.Add(New SqlParameter("@sFax", c.Fax))
            db.Parameters.Add(New SqlParameter("@sCompanyEmail", c.Email))
            db.Parameters.Add(New SqlParameter("@sWebSiteUrl", c.WebSiteUrl))
            db.Parameters.Add(New SqlParameter("@sCompanyProfile", c.BriefProfile))
            Dim retval As Integer = db.ExecuteNonQuery("JobsDb_Companies_Update")
            Return retval
        End Function

        Public Shared Function GetCompany(ByVal username As String) As Company
            Dim db As DBAccess = New DBAccess
            db.Parameters.Add(New SqlParameter("@sUserName", username))
            Dim dr As SqlDataReader = CType(db.ExecuteReader("JobsDb_Companies_SelectByUserName"), SqlDataReader)
            If dr.HasRows Then
                Dim c As Company = New Company
                While dr.Read
                    c.CompanyID = dr.GetInt32(dr.GetOrdinal("companyid"))
                    c.CompanyName = dr.GetString(dr.GetOrdinal("CompanyName"))
                    c.BriefProfile = dr.GetString(dr.GetOrdinal("CompanyProfile"))
                    c.WebSiteUrl = dr.GetString(dr.GetOrdinal("WebSiteUrl"))
                    c.Address1 = dr.GetString(dr.GetOrdinal("Address1"))
                    c.Address2 = dr.GetString(dr.GetOrdinal("Address2"))
                    c.City = dr.GetString(dr.GetOrdinal("City"))
                    c.StateID = dr.GetInt32(dr.GetOrdinal("StateID"))
                    c.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"))
                    c.ZIP = dr.GetString(dr.GetOrdinal("ZIP"))
                    c.Phone = dr.GetString(dr.GetOrdinal("Phone"))
                    c.Fax = dr.GetString(dr.GetOrdinal("Fax"))
                    c.Email = dr.GetString(dr.GetOrdinal("CompanyEmail"))
                    c.UserName = dr.GetString(dr.GetOrdinal("UserName"))
                End While
                dr.Close()
                Return c
            Else
                dr.Close()
                Return Nothing
            End If
        End Function

        Public Shared Function GetCompany(ByVal companyid As Integer) As Company
            Dim db As DBAccess = New DBAccess
            db.Parameters.Add(New SqlParameter("@iCompanyID", companyid))
            Dim dr As SqlDataReader = CType(db.ExecuteReader("JobsDb_Companies_SelectOne"), SqlDataReader)
            If dr.HasRows Then
                Dim c As Company = New Company
                While dr.Read
                    c.CompanyID = dr.GetInt32(dr.GetOrdinal("companyid"))
                    c.CompanyName = dr.GetString(dr.GetOrdinal("CompanyName"))
                    c.BriefProfile = dr.GetString(dr.GetOrdinal("CompanyProfile"))
                    c.WebSiteUrl = dr.GetString(dr.GetOrdinal("WebSiteUrl"))
                    c.Address1 = dr.GetString(dr.GetOrdinal("Address1"))
                    c.Address2 = dr.GetString(dr.GetOrdinal("Address2"))
                    c.City = dr.GetString(dr.GetOrdinal("City"))
                    c.StateID = dr.GetInt32(dr.GetOrdinal("StateID"))
                    c.CountryID = dr.GetInt32(dr.GetOrdinal("CountryID"))
                    c.ZIP = dr.GetString(dr.GetOrdinal("ZIP"))
                    c.Phone = dr.GetString(dr.GetOrdinal("Phone"))
                    c.Fax = dr.GetString(dr.GetOrdinal("Fax"))
                    c.Email = dr.GetString(dr.GetOrdinal("CompanyEmail"))
                    c.UserName = dr.GetString(dr.GetOrdinal("UserName"))
                End While
                dr.Close()
                Return c
            Else
                dr.Close()
                Return Nothing
            End If
        End Function

        Public Shared Function GetCompanyName(ByVal companyid As Integer) As String
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iCompanyID", companyid)
            Return CType(db.ExecuteScalar("JobsDb_Companies_SelectName"), String)
        End Function

        Public Shared Function GetCompanyCount() As Integer
            Dim db As DBAccess = New DBAccess
            Return CType(db.ExecuteScalar("JobsDb_Companies_GetCount"), Integer)
        End Function
    End Class
End Namespace