Imports JobSiteStarterKit.DAL
Imports System.Data
Imports System.Data.SqlClient

Namespace JobSiteStarterKit.BOL
    Public Class Country
        Public Sub New()
        End Sub
        Private strCountryName As String
        Private intCountryID As Integer

        Public Property CountryName() As String
            Get
                Return strCountryName
            End Get
            Set(ByVal value As String)
                strCountryName = value
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

        Public Function InsertCountry(ByVal c As Country) As Integer
            Dim db As DBAccess = New DBAccess
            Dim p As SqlParameter = New SqlParameter("@iCountryID", 0)
            p.Direction = ParameterDirection.Output
            db.AddParameter("@sCountryName", c.CountryName)
            db.AddParameter(p)
            Return db.ExecuteNonQuery("JobsDb_Countries_Insert")
        End Function

        Public Function UpdateCountry(ByVal c As Country) As Integer
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iCountryID", c.CountryID)
            db.AddParameter("@sCountryName", c.CountryName)
            Return db.ExecuteNonQuery("JobsDb_Countries_Update")
        End Function

        Public Function SelectCountries() As DataSet
            Dim db As DBAccess = New DBAccess
            Return db.ExecuteDataSet("JobsDb_Countries_SelectAll")
        End Function

        Public Shared Function GetCountries() As DataSet
            Dim db As DBAccess = New DBAccess
            Return db.ExecuteDataSet("JobsDb_Countries_SelectAll")
        End Function

        Public Shared Function GetCountryName(ByVal id As Integer) As String
            Dim db As DBAccess = New DBAccess
            db.AddParameter("@iCountryID", id)
            Return db.ExecuteScalar("JobsDb_Countries_GetCountryName").ToString
        End Function
    End Class
End Namespace