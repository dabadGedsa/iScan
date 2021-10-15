Imports System.Data.SqlClient
Imports libreriacadenaproduccion.Entidades
Imports System.Windows.Forms


Namespace Datos


    Namespace CodificacionSQL


        Public Class AccesoDatosCodificacion



            ' guarda la fecha y la hora en que se conecta un usuario. Si el nombre de usuario y contraseña es incorrecto, devuelve nothing
            Public Shared Function conectarUsuario(ByVal login As String, ByVal psw As String, ByVal strCadenaConexion As String) As ClsUsuario

                Dim usuario As ClsUsuario = Nothing

                Dim strSQL As String
                Dim cmdSQL As sqlCommand
                Dim conexion As SqlConnection
                Dim dReader As SqlDataReader

                strSQL = "SELECT id, nombre, apellidos, nomUsuario, clave, cargo FROM cuentas WHERE nomUsuario = '" & login & "' AND clave = '" & psw & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)

                Try
                    conexion.Open()

                    dReader = cmdSQL.ExecuteReader()

                    If dReader.Read() Then
                        usuario = New ClsUsuario(dReader("id"), dReader("nomUsuario"))
                        usuario._nombre = IIf(dReader("nombre") Is System.DBNull.Value, "", dReader("nombre"))
                        usuario._apellidos = IIf(dReader("apellidos") Is System.DBNull.Value, "", dReader("apellidos"))
                        usuario._clave = IIf(dReader("clave") Is System.DBNull.Value, "", dReader("clave"))
                        usuario._cargo = IIf(dReader("cargo") Is System.DBNull.Value, 0, dReader("cargo"))

                        dReader.Close()


                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                    Throw New Exception("Error en la conexion")

                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return usuario

            End Function



            Public Shared Sub actualizarParto(ByVal partoViejo As ClsParto, ByVal partoNuevo As ClsParto, ByVal strCadenaConexion As String)

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                strSQL = "UPDATE partos SET"
                strSQL = strSQL & " fechaNacimiento = '" & partoNuevo.valorFechaParto.ToShortDateString() & "',"
                strSQL = strSQL & " horanacimiento = '" & partoNuevo.valorFechaParto.ToShortTimeString() & "',"
                strSQL = strSQL & " semanasGestacion = " & partoNuevo.valorSemanasGestacion & ","
                strSQL = strSQL & " sexo = " & partoNuevo.valorSexo & ","
                strSQL = strSQL & " peso = " & partoNuevo.valorPeso & ","
                strSQL = strSQL & " situacion = " & partoNuevo.valorSituacion & " "

                strSQL = strSQL & " WHERE hospital = '" & partoViejo.valorHospital & "' "
                strSQL = strSQL & " AND nhc = '" & partoViejo.valorNHC & "' "
                strSQL = strSQL & " AND episodio = '" & partoViejo.valorEpisodio & "' "
                strSQL = strSQL & " AND numparto = " & partoViejo.valorNumParto

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)

                Try
                    conexion.Open()

                    cmdSQL.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

            End Sub

            Public Shared Sub insertarParto(ByVal parto As ClsParto, ByVal cadenaconexion As String)

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                strSQL = "INSERT INTO partos(hospital, nhc, episodio, numparto, fechanacimiento, horanacimiento, semanasgestacion, sexo, peso, situacion) "
                strSQL = strSQL & "VALUES('" & parto.valorHospital & "', '" & parto.valorNHC & "', '" & parto.valorEpisodio & "', " & parto.valorNumParto & ", '"
                strSQL = strSQL & parto.valorFechaParto.ToShortDateString() & "', '" & parto.valorFechaParto.ToShortTimeString() & "', " & parto.valorSemanasGestacion & ", "
                strSQL = strSQL & parto.valorSexo & ", " & parto.valorPeso & ", " & parto.valorSituacion & ")"

                conexion = New SqlConnection(cadenaconexion)
                cmdSQL = New SqlCommand(strSQL, conexion)

                Try
                    conexion.Open()

                    cmdSQL.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

            End Sub


            Public Shared Sub eliminarParto(ByVal parto As ClsParto, ByVal cadenaConexion As String)

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                strSQL = "DELETE FROM partos "
                strSQL = strSQL & " WHERE hospital = '" & parto.valorHospital & "' "
                strSQL = strSQL & " AND nhc = '" & parto.valorNHC & "' "
                strSQL = strSQL & " AND episodio = '" & parto.valorEpisodio & "' "
                strSQL = strSQL & " AND numparto = " & parto.valorNumParto
                
                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)

                Try
                    conexion.Open()

                    cmdSQL.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

            End Sub


            Public Shared Function ObtenerSinonimosCodigo(ByVal codigo As String, ByVal strCadenaConexion As String) As DataTable


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter


                strSQL = "Select * from Diagnosticos where Codigo LIKE '" & codigo & "%'"


                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function

            Public Shared Function ObtenerProcedimientosCodigo(ByVal codigo As String, ByVal strCadenaConexion As String) As DataTable


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter


                strSQL = "Select * from Procedimientos where Codigo LIKE '" & codigo & "%'"


                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function

            Public Shared Function ObtenerSinonimosDesc(ByVal descrip As String, ByVal strCadenaConexion As String) As DataTable


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter
                strSQL = "Select * from Diagnosticos where descripcion LIKE '%" & descrip & "%'"


                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function

            Public Shared Function ObtenerSinonimosDescMorfologiaNeoplasias(ByVal descrip As String, ByVal cadenaConexion As String) As DataTable


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter
                strSQL = "Select * from MorfologiasNeoplasias where descripcion LIKE '%" & descrip & "%'"


                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function

            Public Shared Function ObtenerSinonimosDescProcedimientos(ByVal descrip As String, ByVal cadenaConexion As String) As DataTable


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter
                strSQL = "Select * from Procedimientos where descripcion LIKE '%" & descrip & "%'"


                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function

            

            Public Shared Function ObtenerSinonimosCodigoMorfologiasNeoplasias(ByVal codigo As String, ByVal strCadenaConexion As String) As DataTable


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter

                If codigo.StartsWith("M") Or codigo.StartsWith("m") Then ' va a la tabla  morfologias

                    strSQL = "Select * from MorfologiasNEoplasias where Codigo LIKE '" & codigo & "%'"

                Else ' va la la tabla Diagnostios

                    strSQL = "Select * from Diagnosticos where where Codigo LIKE '" & codigo & "%'"
                End If




                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return listado

            End Function

            Public Shared Function ObtenerCieDeCodigo(ByVal codigo As String, ByVal strCadenaConexion As String) As String


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter



                If (codigo.IndexOf(".") = 2) Or (codigo.Length = 2) Then 'es un PROCEDIMIENTO pues todo siguen el patron XX.XX, y ningun diagnostico ni morfologia lo sigue


                    strSQL = "Select * from Procedimientos where Codigo='" & codigo & "'"


                Else 'es una morfologia o un diagnostico normal


                    If codigo.StartsWith("M") Or codigo.StartsWith("m") Then ' va a la tabla  morfologias

                        strSQL = "Select * from MorfologiasNEoplasias where Codigo='" & codigo & "'"

                    Else ' va la la tabla Diagnostios

                        strSQL = "Select * from Diagnosticos where Codigo='" & codigo & "'"
                    End If

                End If


                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(listado)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try
                Try
                    Return listado.Rows(0).Item("Descripcion").ToString()
                Catch ex As Exception
                    Return "Sin descripcion."
                End Try


            End Function

          
            Public Shared Sub GuardarMorfologiaDiagnostico(ByVal morfo As ClsMorfologia, ByVal hospital As String, ByVal historia As String, ByVal strCadenaConexion As String)

                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim replicable


                If morfo.valorReplicable Then
                    replicable = 1
                Else
                    replicable = 0


                End If


                If morfo.valorCodigo.StartsWith("M") Or morfo.valorCodigo.StartsWith("m") Then ' va a la tabla episodios morfologias

                    strSQL = "Insert into EpisodiosMorfologias Values('" & hospital & "','" & historia & "','" & morfo.valorNomICU & "','" & morfo.valorCodigo & "'," & CType(replicable, Integer) & "," & morfo.valorOrden & ")"

                Else ' va la la tabla episodiosDiagnostios

                    strSQL = "Insert into EpisodiosDiagnosticos Values('" & hospital & "','" & historia & "','" & morfo.valorNomICU & "','" & morfo.valorCodigo & "'," & CType(replicable, Integer) & "," & morfo.valorOrden & "," & CType(morfo.valorEsPrincipal, Integer) & ")" 'aunque la variable se llame morfo se refiere a un diagnostico

                End If



                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    cmdSQL.ExecuteNonQuery()


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try




            End Sub

            Public Shared Sub ActualizarMorfologiaDiagnostico(ByVal morfoNuevo As ClsMorfologia, ByVal hospital As String, ByVal morfoViejo As ClsMorfologia, ByVal historia As String, ByVal strCadenaConexion As String)


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim replicable
                Dim numero As Integer

                If morfoNuevo.valorReplicable Then
                    replicable = 1
                Else
                    replicable = 0


                End If

                If morfoNuevo.valorCodigo.StartsWith("M") Or morfoNuevo.valorCodigo.StartsWith("m") Then ' va a la tabla episodios morfologias

                    strSQL = "Update EpisodiosMorfologias set Hospital='" & hospital & "',Historia='" & historia & "',NumICU='" & morfoNuevo.valorNomICU & "',M='" & morfoNuevo.valorCodigo & "',Replicar=" & replicable & " Where Hospital='" & hospital & "' and Historia='" & historia & "' and NumICU='" & morfoViejo.valorNomICU & "' and orden =" & morfoNuevo.valorOrden

                Else ' va la la tabla episodiosDiagnostios

                    strSQL = "Update EpisodiosDiagnosticos set Hospital='" & hospital & "',Historia='" & historia & "',NumICU='" & morfoNuevo.valorNomICU & "',C='" & morfoNuevo.valorCodigo & "',Replicar=" & replicable & ", esPrincipal = " & CType(morfoNuevo.valorOrden = 1, Integer) & ",  orden = " & morfoNuevo.valorOrden & " Where Hospital='" & hospital & "' and Historia='" & historia & "' and NumICU='" & morfoViejo.valorNomICU & "' and orden =" & morfoNuevo.valorOrden

                End If

                'Puede que falte comprobar si se modifica un codigo de diagnostico a uno de morfologia y viceversa. 


                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    numero = cmdSQL.ExecuteNonQuery()


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try



            End Sub

            Public Shared Sub eliminarMorfologiaDiagnostico(ByVal morfo As ClsMorfologia, ByVal hospital As String, ByVal historia As String, ByVal strCadenaConexion As String)

                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection



                If morfo.valorCodigo.StartsWith("M") Or morfo.valorCodigo.StartsWith("m") Then ' va a la tabla episodios morfologias

                    strSQL = "delete from EpisodiosMorfologias where Hospital='" & hospital & "' and Historia ='" & historia & "' and NumICU='" & morfo.valorNomICU & "' and Orden =" & morfo.valorOrden


                Else ' va la la tabla episodiosDiagnostios

                    strSQL = "delete from EpisodiosDiagnosticos where Hospital='" & hospital & "' and Historia ='" & historia & "' and NumICU='" & morfo.valorNomICU & "' and Orden =" & morfo.valorOrden

                End If




                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    If cmdSQL.ExecuteNonQuery() > 0 Then

                        MessageBox.Show("Borrado " & morfo.valorCie)
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try




            End Sub

            Public Shared Function existeCodigo(ByVal codigo As String, ByVal strCadenaConexion As String) As Boolean


                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                Dim objetoEncontrado = Nothing


                If (codigo.IndexOf(".") = 2) Or (codigo.Length = 2) Then '"XX.XX"

                    strSQL = "Select * from Procedimientos where Codigo = '" & codigo & "'"

                Else

                    If codigo.StartsWith("M") Or codigo.StartsWith("m") Then ' va a la tabla episodios morfologias

                        strSQL = "Select * from MorfologiasNeoplasias where Codigo = '" & codigo & "'"

                    Else ' va la la tabla episodiosDiagnostios

                        strSQL = "Select * from Diagnosticos where Codigo = '" & codigo & "'"
                    End If

                    'Puede que falte comprobar si se modifica un codigo de diagnostico a uno de morfologia y viceversa. 
                End If


                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    objetoEncontrado = cmdSQL.ExecuteScalar() 'comporbar que la consulta devuelve algo


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                If Not IsNothing(objetoEncontrado) Then
                    Return True

                Else
                    Return False

                End If


            End Function

            Public Shared Function obtenerNumeroMorfologias(ByVal historia As String, ByVal hospital As String, ByVal numicu As String, ByVal strCadenaConexion As String)


                Dim numero = Nothing

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                strSQL = "Select Max(orden) from EpisodiosMorfologias where Hospital='" & hospital & "' and Historia ='" & historia & "' and NumIcu ='" & numicu & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()

                    numero = cmdSQL.ExecuteScalar()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try


                If numero.Equals(System.DBNull.Value) Then 'si hay 0 devuelve un NULL
                    Return 0
                Else
                    Return numero
                End If


            End Function

            Public Shared Function obtenerNumeroDiagnosticos(ByVal historia As String, ByVal hospital As String, ByVal numicu As String, ByVal strCadenaConexion As String)


                Dim numero = Nothing

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                strSQL = "Select Max(orden) from EpisodiosDiagnosticos where Hospital='" & hospital & "' and Historia ='" & historia & "' and NumIcu ='" & numicu & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()

                    numero = cmdSQL.ExecuteScalar()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                If numero.Equals(System.DBNull.Value) Then 'si hay null devuelve un 0
                    Return 0
                Else
                    Return numero
                End If



            End Function

            Public Shared Sub GuardarProcedimientoQuirurjico(ByVal trata As ClsTratamientoQuirurjico, ByVal numicu As String, ByVal hospital As String, ByVal historia As String, ByVal strCadenaConexion As String)

                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim replicable


                Dim numeroDeQuiru As Integer
                numeroDeQuiru = obtenerNumeroProcedimientoQuirurjico(historia, hospital, numicu, strCadenaConexion) + 1

                If trata.valorReplicable Then
                    replicable = 1
                Else
                    replicable = 0

                End If


                strSQL = "Insert into EpisodiosProcedimientos Values('" & hospital & "','" & historia & "','" & trata.valorNomICU & "','" & trata.valorCodigo & "','" & Date.Parse(trata.valorFecha.ToShortDateString()) & "'," & replicable & "," & numeroDeQuiru & ")"

                conexion = New SqlConnection(strCadenaConexion)

                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    cmdSQL.ExecuteNonQuery()


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try




            End Sub

            Public Shared Sub ActualizarProcedimientosQuirurgicos(ByVal trataNuevo As ClsTratamientoQuirurjico, ByVal hospital As String, ByVal trataViejo As ClsTratamientoQuirurjico, ByVal historia As String, ByVal strCadenaconexion As String)
                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim numero As Integer



                strSQL = "Update EpisodiosProcedimientos set Hospital='" & hospital & "',Historia='" & historia & "',NumIcu='" & trataNuevo.valorNomICU & "',P='" & trataNuevo.valorCodigo & "',Fint='" & trataNuevo.valorFecha & "',Replicar=" & CType(trataNuevo.valorReplicable, Integer) & " Where Hospital='" & hospital & "' and Historia='" & historia & "'and NumICU='" & trataViejo.valorNomICU & "' and orden =" & trataViejo.valorOrden
                conexion = New SqlConnection(strCadenaconexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    numero = cmdSQL.ExecuteNonQuery()


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try



                If numero < 1 Then 'si llega aqui esque no ha modificado ningun registro

                    'Es necesario por si se modifica un codigo replicable en otro episodio 
                    'que no es en el que se inserto. Se modifican todos las entradas 
                    'que comparten el hospital-historia-orden (no numIcu como la anterior, pues estan en distintos episodios)




                    strSQL = "Update EpisodiosProcedimientos set Hospital='" & hospital & "',Historia='" & historia & "',P='" & trataNuevo.valorCodigo & "',Fint='" & trataNuevo.valorFecha & "',Replicar=" & CType(trataNuevo.valorReplicable, Integer) & " Where Hospital='" & hospital & "' and Historia='" & historia & "' and orden =" & trataViejo.valorOrden


                    conexion = New SqlConnection(strCadenaconexion)
                    cmdSQL = New SqlCommand(strSQL, conexion)


                    Try

                        conexion.Open()
                        numero = cmdSQL.ExecuteNonQuery()


                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString)
                    Finally
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                    End Try

                End If


            End Sub

            Public Shared Function obtenerNumeroProcedimientoQuirurjico(ByVal historia As String, ByVal hospital As String, ByVal numicu As String, ByVal strCadenaConexion As String) As Integer


                Dim numero = Nothing

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                strSQL = "Select Max(orden) from EpisodiosProcedimientos where Hospital='" & hospital & "' and Historia ='" & historia & "' and NumIcu ='" & numicu & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()

                    numero = cmdSQL.ExecuteScalar()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try


                If numero.Equals(System.DBNull.Value) Then 'si hay 0 devuelve un NULL
                    Return 0
                Else
                    Return numero
                End If



            End Function

            Public Shared Sub eliminarProcedimientoQuirurgico(ByVal quiru As ClsTratamientoQuirurjico, ByVal hospital As String, ByVal historia As String, ByVal strCadenaConexion As String)

                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection




                strSQL = "delete from EpisodiosProcedimientos where Hospital='" & hospital & "' and Historia ='" & historia & "' and NumICU='" & quiru.valorNomICU & "' and Orden =" & quiru.valorOrden



                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    If cmdSQL.ExecuteNonQuery() > 0 Then

                        MessageBox.Show("Borrado " & quiru.valorCie)
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try




            End Sub

            Public Shared Sub GuardarProcedimientoTerapeutico(ByVal proce As ClsTatamientoTerapeutico, ByVal hospital As String, ByVal numIcu As String, ByVal historia As String, ByVal strCadenaConexion As String)

                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim replicable As Integer

                Dim numeroDeProce As Integer
                numeroDeProce = obtenerNumeroProcedimientoTerapeutico(historia, hospital, numIcu, strCadenaConexion) + 1


                If proce.valorReplicable Then
                    replicable = 1
                Else
                    replicable = 0

                End If


                strSQL = "Insert into EpisodiosTratamientos Values('" & hospital & "','" & historia & "','" & proce.valorNomICU & "','" & proce.valorCodigo & "','" & Date.Parse(proce.valorFecha.ToShortDateString()) & "'," & replicable & "," & numeroDeProce & ")"


                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    cmdSQL.ExecuteNonQuery()


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try



            End Sub

            Public Shared Sub ActualizarProcedimientoTerapeutico(ByVal proceNuevo As ClsTatamientoTerapeutico, ByVal proceViejo As ClsTatamientoTerapeutico, ByVal historia As String, ByVal hospital As String, ByVal cadenaconexion As String)
                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim numero As Integer



                strSQL = "Update EpisodiosTratamientos set Hospital='" & hospital & "' ,Historia='" & historia & "',NumICU='" & proceNuevo.valorNomICU & "',T='" & proceNuevo.valorCodigo & "',Fint='" & Date.Parse(proceNuevo.valorFecha.ToShortDateString()) & "',Replicar=" & CType(proceNuevo.valorReplicable, Integer) & " Where Hospital='" & hospital & "' and Historia='" & historia & "' and NumICU='" & proceViejo.valorNomICU & "' and orden =" & proceViejo.valorOrden
                conexion = New SqlConnection(cadenaconexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    numero = cmdSQL.ExecuteNonQuery()


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try


                If numero < 1 Then 'si llega aqui esque no ha modificado ningun registro

                    'Es necesario por si se modifica un codigo replicable en otro episodio 
                    'que no es en el que se inserto. Se modifican todos las entradas 
                    'que comparten el hospital-historia-orden (no numIcu como la anterior, pues estan en distintos episodios)



                    strSQL = "Update EpisodiosTratamientos set Hospital='" & hospital & "' ,Historia='" & historia & "',NumICU='" & proceNuevo.valorNomICU & "',T='" & proceNuevo.valorCodigo & "',Fint='" & Date.Parse(proceNuevo.valorFecha.ToShortDateString()) & "',Replicar=" & CType(proceNuevo.valorReplicable, Integer) & " Where Hospital='" & hospital & "' and Historia='" & historia & "' and orden =" & proceViejo.valorOrden



                    conexion = New SqlConnection(cadenaconexion)
                    cmdSQL = New SqlCommand(strSQL, conexion)


                    Try

                        conexion.Open()
                        numero = cmdSQL.ExecuteNonQuery()


                    Catch ex As Exception
                        MessageBox.Show(ex.Message.ToString)
                    Finally
                        If conexion.State = ConnectionState.Open Then
                            conexion.Close()
                        End If
                    End Try

                End If



            End Sub

            Public Shared Sub eliminarProcedimientoTerapeutico(ByVal tera As ClsTatamientoTerapeutico, ByVal historia As String, ByVal hospital As String, ByVal strCadenaConexion As String)

                Dim listado As New DataTable()
                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection




                strSQL = "delete from EpisodiosTratamientos where Hospital='" & hospital & "' and Historia ='" & historia & "' and NumICU='" & tera.valorNomICU & "' and Orden =" & tera.valorOrden



                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try

                    conexion.Open()
                    If cmdSQL.ExecuteNonQuery() > 0 Then

                        MessageBox.Show("Borrado " & tera.valorCie)
                    End If


                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try




            End Sub

            Public Shared Function obtenerNumeroProcedimientoTerapeutico(ByVal historia As String, ByVal hospital As String, ByVal numicu As String, ByVal strCadenaConexion As String) As Integer


                Dim numero = Nothing

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                strSQL = "Select Max(orden) from EpisodiosTratamientos where Hospital='" & hospital & "' and Historia ='" & historia & "' and NumIcu ='" & numicu & "'"

                conexion = New SqlConnection(strCadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)


                Try
                    conexion.Open()

                    numero = cmdSQL.ExecuteScalar()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                If numero.Equals(System.DBNull.Value) Then 'si hay 0 devuelve un NULL
                    Return 0
                Else
                    Return numero
                End If



            End Function


            Public Shared Sub eliminarCodificacionAnterior(ByVal hospital As String, ByVal historia As String, ByVal numicu As String, ByVal CadenaConexion As String)

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection

                conexion = New SqlConnection(CadenaConexion)
                cmdSQL = New SqlCommand()
                cmdSQL.Connection = conexion

                Try

                    conexion.Open()

                    strSQL = "DELETE FROM EpisodiosDiagnosticos WHERE hospital = '" & hospital & "' AND historia = '" & historia & "' AND numicu = '" & numicu & "'"
                    cmdSQL.CommandText = strSQL
                    cmdSQL.ExecuteNonQuery()

                    strSQL = "DELETE FROM EpisodiosMorfologias WHERE hospital = '" & hospital & "' AND historia = '" & historia & "' AND numicu = '" & numicu & "'"
                    cmdSQL.CommandText = strSQL
                    cmdSQL.ExecuteNonQuery()

                    strSQL = "DELETE FROM EpisodiosProcedimientos WHERE hospital = '" & hospital & "' AND historia = '" & historia & "' AND numicu = '" & numicu & "'"
                    cmdSQL.CommandText = strSQL
                    cmdSQL.ExecuteNonQuery()

                    strSQL = "DELETE FROM EpisodiosTratamientos WHERE hospital = '" & hospital & "' AND historia = '" & historia & "' AND numicu = '" & numicu & "'"
                    cmdSQL.CommandText = strSQL
                    cmdSQL.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

            End Sub


#Region "Obtención de réplicas de la codificación"

            Public Shared Function obtenerReplicasDiagnosticos(ByVal hospital As String, ByVal historia As String, ByVal fecIng As String, ByVal cadenaConexion As String) As DataTable

                Dim dt As New DataTable()

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter

                strSQL = "SELECT e.C,e.Replicar,e.NumIcu,e.Orden "
                strSQL &= "FROM EpisodiosDiagnosticos e, CMBDCodificacion c "
                strSQL &= "WHERE e.hospital = c.hospital AND e.historia = c.historia AND e.numicu = c.numicu "
                strSQL &= "AND e.Hospital='" & hospital & "' "
                strSQL &= "AND e.historia='" & historia & "' "
                strSQL &= "AND e.replicar = 1 "
                strSQL &= "AND c.fecing <= '" & fecIng & "'"

                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(dt)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return dt

            End Function


            Public Shared Function obtenerReplicasMorfologias(ByVal hospital As String, ByVal historia As String, ByVal fecIng As String, ByVal cadenaConexion As String) As DataTable

                Dim dt As New DataTable()

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter

                strSQL = "SELECT e.M,e.Replicar,e.NumIcu,e.Orden "
                strSQL &= "FROM EpisodiosMorfologias e, CMBDCodificacion c "
                strSQL &= "WHERE e.hospital = c.hospital AND e.historia = c.historia AND e.numicu = c.numicu "
                strSQL &= "AND e.Hospital='" & hospital & "' "
                strSQL &= "AND e.historia='" & historia & "' "
                strSQL &= "AND e.replicar = 1 "
                strSQL &= "AND c.fecing <= '" & fecIng & "'"

                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(dt)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return dt

            End Function


            Public Shared Function obtenerReplicasProcedimientos(ByVal hospital As String, ByVal historia As String, ByVal fecIng As String, ByVal cadenaConexion As String) As DataTable

                Dim dt As New DataTable()

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter

                strSQL = "SELECT e.P,e.Replicar,e.NumIcu,e.Orden,e.Fint "
                strSQL &= "FROM EpisodiosProcedimientos e, CMBDCodificacion c "
                strSQL &= "WHERE e.hospital = c.hospital AND e.historia = c.historia AND e.numicu = c.numicu "
                strSQL &= "AND e.Hospital='" & hospital & "' "
                strSQL &= "AND e.historia='" & historia & "' "
                strSQL &= "AND e.replicar = 1 "
                strSQL &= "AND c.fecing <= '" & fecIng & "'"

                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(dt)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return dt

            End Function


            Public Shared Function obtenerReplicasTratamientos(ByVal hospital As String, ByVal historia As String, ByVal fecIng As String, ByVal cadenaConexion As String) As DataTable

                Dim dt As New DataTable()

                Dim strSQL As String
                Dim cmdSQL As SqlCommand
                Dim conexion As SqlConnection
                Dim daDatos As SqlDataAdapter

                strSQL = "SELECT e.T,e.Replicar,e.NumIcu,e.Orden,e.fint "
                strSQL &= "FROM EpisodiosTratamientos e, CMBDCodificacion c "
                strSQL &= "WHERE e.hospital = c.hospital AND e.historia = c.historia AND e.numicu = c.numicu "
                strSQL &= "AND e.Hospital='" & hospital & "' "
                strSQL &= "AND e.historia='" & historia & "' "
                strSQL &= "AND e.replicar = 1 "
                strSQL &= "AND c.fecing <= '" & fecIng & "'"

                conexion = New SqlConnection(cadenaConexion)
                cmdSQL = New SqlCommand(strSQL, conexion)
                daDatos = New SqlDataAdapter(cmdSQL)

                Try
                    conexion.Open()

                    daDatos.Fill(dt)

                Catch ex As Exception
                    MessageBox.Show(ex.Message.ToString)
                Finally
                    If conexion.State = ConnectionState.Open Then
                        conexion.Close()
                    End If
                End Try

                Return dt

            End Function

#End Region


        End Class
    End Namespace
End Namespace
