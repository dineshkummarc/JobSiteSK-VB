Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace JobSiteStarterKit.DAL
    Public Class DBAccess
        Private cmd As IDbCommand = New SqlCommand()
        Private strConnectionString As String = ""
        Private handleErrors As Boolean = False
        Private strLastError As String = ""

        Public Sub New()
            Dim objConnectionStringSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("connectionstring")
            strConnectionString = objConnectionStringSettings.ConnectionString
            Dim cnn As New SqlConnection()
            cnn.ConnectionString = strConnectionString
            cmd.Connection = cnn
            cmd.CommandType = CommandType.StoredProcedure
        End Sub

        Public Function ExecuteReader() As IDataReader
            Dim reader As IDataReader = Nothing
            Try
                Me.Open()
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return reader
        End Function

        Public Function ExecuteReader(ByVal commandtext As String) As IDataReader
            Dim reader As IDataReader = Nothing
            Try
                cmd.CommandText = commandtext
                reader = Me.ExecuteReader()
            Catch ex As Exception
                If (handleErrors) Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return reader
        End Function

        Public Function ExecuteScalar() As Object
            Dim obj As Object = Nothing
            Try
                Me.Open()
                obj = cmd.ExecuteScalar()
                Me.Close()
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return obj
        End Function
        Public Function ExecuteScalar(ByVal commandtext As String) As Object
            Dim obj As Object = Nothing
            Try
                cmd.CommandText = commandtext
                obj = Me.ExecuteScalar()
            Catch ex As Exception
                If (handleErrors) Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return obj
        End Function

        Public Function ExecuteNonQuery() As Integer
            Dim i As Integer = -1
            Try
                Me.Open()
                i = cmd.ExecuteNonQuery()
                Me.Close()
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return i
        End Function



        Public Function ExecuteNonQuery(ByVal commandtext As String) As Integer
            Dim i As Integer = -1
            Try
                cmd.CommandText = commandtext
                i = Me.ExecuteNonQuery()
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return i
        End Function
        Public Function ExecuteDataSet() As DataSet
            Dim da As SqlDataAdapter = Nothing
            Dim ds As DataSet = Nothing
            Try
                da = New SqlDataAdapter()
                da.SelectCommand = CType(cmd, SqlCommand)
                ds = New DataSet()
                da.Fill(ds)
            Catch ex As Exception
                If (handleErrors) Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return ds
        End Function
        Public Function ExecuteDataSet(ByVal commandtext As String) As DataSet
            Dim ds As DataSet = Nothing
            Try
                cmd.CommandText = commandtext
                ds = Me.ExecuteDataSet()
            Catch ex As Exception
                If handleErrors Then
                    strLastError = ex.Message
                Else
                    Throw
                End If
            End Try
            Return ds
        End Function

        Public Property CommandText() As String
            Get
                Return cmd.CommandText
            End Get
            Set(ByVal value As String)
                cmd.CommandText = value
                cmd.Parameters.Clear()
            End Set
        End Property

        Public ReadOnly Property Parameters() As IDataParameterCollection
            Get
                Return cmd.Parameters
            End Get
        End Property

        Public Sub AddParameter(ByVal paramname As String, ByVal paramvalue As Object)
            Dim param As SqlParameter = New SqlParameter(paramname, paramvalue)
            cmd.Parameters.Add(param)
        End Sub

        Public Sub AddParameter(ByVal param As IDataParameter)
            cmd.Parameters.Add(param)
        End Sub

        Public Property ConnectionString() As String
            Get
                Return strConnectionString
            End Get
            Set(ByVal value As String)
                strConnectionString = value
            End Set
        End Property

        Private Sub Open()
            cmd.Connection.Open()
        End Sub

        Private Sub Close()
            cmd.Connection.Close()
        End Sub

        Public Property HandleExceptions() As Boolean
            Get
                Return handleErrors
            End Get
            Set(ByVal value As Boolean)
                handleErrors = value
            End Set
        End Property

        Public ReadOnly Property LastError() As String
            Get
                Return strLastError
            End Get
        End Property

        Public Sub Dispose()
            cmd.Dispose()
        End Sub

    End Class
End Namespace