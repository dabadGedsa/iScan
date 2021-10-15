Imports System.Windows.Forms


Namespace Datos
    Namespace GeneralExcel

        Public Class clsAccesoDatosExcel

            Public Shared Function ObtenerDataSetRegistrosHojaExcel(ByRef nombreFichero As String) As DataSet

                Dim conexion = New OleDb.OleDbConnection
                Dim cmdInstruccion = New OleDb.OleDbCommand
                Dim daTabla = New OleDb.OleDbDataAdapter
                Dim dsCampos = New DataSet

                Try

                    conexion.ConnectionString = "provider=Microsoft.Jet.OLEDB.4.0;data source= " & nombreFichero & ";Extended Properties=Excel 8.0;"

                    With cmdInstruccion
                        .Connection = conexion
                        .CommandText = "SELECT * FROM [registro$]"
                    End With

                    daTabla.SelectCommand = cmdInstruccion

                    conexion.Open()

                    daTabla.Fill(dsCampos, "Registro")


                Catch err As OleDb.OleDbException
                    If err.ErrorCode.ToString = "-2147467259" Then
                        MessageBox.Show("Para poder consultar el archivo Excel, la hoja tiene que tener el nombre: registro. Cambie el nombre y vuelva a ejecutar la aplicación.")
                    Else
                        MessageBox.Show("Error cod:" & err.ErrorCode.ToString & "-" & err.Message & err.ErrorCode.ToString)
                    End If


                Catch err2 As Exception
                    MessageBox.Show(err2.Message.ToString)

                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                        conexion.dispose()
                    End If
                End Try

                Return dsCampos

            End Function




            Public Shared Function ObtenerRegistrosConAlgunCampoNulo(ByVal nomFichero As String) As DataTable


                Dim conexion = New OleDb.OleDbConnection
                Dim cmdInstruccion = New OleDb.OleDbCommand
                Dim daTabla = New OleDb.OleDbDataAdapter
                Dim dsCampos = New DataSet


                Try

                    conexion.ConnectionString = "provider=Microsoft.Jet.OLEDB.4.0;data source= " & nomFichero & ";Extended Properties=Excel 8.0;"

                    With cmdInstruccion
                        .Connection = conexion
                        .CommandText = "SELECT * FROM [registro$] where Hospital = 0 or Hospital is null or Historia = 0 or Historia is null or NUMICU = 0 or NUMICU is null"
                    End With

                    daTabla.SelectCommand = cmdInstruccion

                    conexion.Open()

                    daTabla.Fill(dsCampos, "Registro")


                Catch err As OleDb.OleDbException
                    If err.ErrorCode.ToString = "-2147467259" Then
                        MessageBox.Show("Para poder consultar el archivo Excel, la hoja tiene que tener el nombre: registro. Cambie el nombre y vuelva a ejecutar la aplicación.")
                    Else
                        MessageBox.Show("Error cod:" & err.ErrorCode.ToString & "-" & err.Message & err.ErrorCode.ToString)
                    End If


                Catch err2 As Exception
                    MessageBox.Show(err2.Message.ToString)

                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                        conexion.dispose()
                    End If
                End Try

                Return CType(dsCampos, DataSet).Tables(0)





            End Function


        End Class

    End Namespace
End Namespace
