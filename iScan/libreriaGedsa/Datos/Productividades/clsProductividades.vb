Imports System.Data.SqlClient
Imports System.IO
Imports System.Transactions
Imports System.Data
Imports System.Windows.Forms
Imports libreriacadenaproduccion.Entidades

Public Class clsProductividades

    Public Shared Sub Productividades(ByVal NomUsuario As String, ByVal lote As String, ByVal NumProyecto As String, ByVal TipoAcceso As String, ByVal Modulo As String)
        'Procedimiento para insertar en la tabla de control de Accesos

        Dim con As SqlConnection = Nothing
        Dim cmd As SqlCommand
        Dim strSQL As String
        Dim maxid As Integer

        Try

            'primero se extrae el maximo id
            con = New SqlConnection()
            ' con.ConnectionString = strCadenaConexion
            strSQL = "select max(ID) as maximo from CONTROLACCESOSINDIZACION"
            cmd = New SqlCommand(strSQL, con)

            con.Open()
            maxid = cmd.ExecuteScalar()
            con.Close()

            '--------------------------------------------------------------------
            'se inserta en control de accesos
            strSQL = "insert into CONTROLACCESOSINDIZACION(ID,NomUsuario,FechaAcceso,HoraAcceso,TipoAcceso,ModuloAcceso,Proyecto,Lote,Autorizado,NumIntentos)" & _
            " values(" & maxid & ",'" & NomUsuario & "','" & Format(Now.Date, "dd/mm/yyyy") & "','" & Format(Now.TimeOfDay, "hh:mm:ss") & "','" & TipoAcceso & "','" & Modulo & "','" & NumProyecto & "'," & lote & ",1,1)"
            cmd = New SqlCommand(strSQL, con)

            con.Open()

            cmd.ExecuteNonQuery()


        Catch oExcep As SqlException
            ' si se produce algún error lo capturamos mediante el objeto de excepciones particular para _
            ' el proveedor de SQL Server
            MessageBox.Show("Error al conectar con datos" & ControlChars.CrLf & oExcep.Message & ControlChars.CrLf & oExcep.Server)

        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try

    End Sub


End Class
