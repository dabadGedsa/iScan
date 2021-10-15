Imports doc = LibreriaCadenaProduccion.Entidades.ClsDocumento
Imports opDigi = LibreriaCadenaProduccion.Entidades.ClsOperacionesDigitalizacion
Imports datos = LibreriaCadenaProduccion.Datos.GeneralSQL.clsAccesoDatosSQL
Imports accesoDatosDocumentos = LibreriaCadenaProduccion.Datos.Produccion.cadenaproduccion.clsAccesoDatosDocumento
Public Class frmInsercionDocumento

    Dim var_tipo As tipoInsercion
    Dim var_pagina As Integer
    Dim var_frmAnterior As frmCorreccion


    Dim varRutaTmpCaratula As String = My.Settings.RutaImagenTemp.ToString.Replace("""", "") & "\caratula.tif"

    'variables para guardar el valor de nombre y apellidos 
    'se utilizan para comparar con los valores escritos en los  textbox 

    Dim cara_nombre As String = ""
    Dim cara_apellido1 As String = ""
    Dim cara_apellido2 As String = ""

    Enum tipoInsercion
        Plantilla = 1
        Documento = 2
    End Enum



    ''' <summary>
    ''' Cuando generamos un nuevo tipo de documentos debemos de pasarle en el constructor
    ''' el tipo de documento que queremos añadir
    ''' </summary>
    ''' <remarks></remarks>
    Sub New(ByRef frmPadre As frmCorreccion, ByVal tipo As tipoInsercion)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        var_frmAnterior = frmPadre
        var_tipo = tipo

        If var_frmAnterior.grdDocumentos.CurrentRow IsNot Nothing Then
            var_pagina = var_frmAnterior.dt_documentos.Rows(var_frmAnterior.grdDocumentos.CurrentRow.Index).Item("pagina").ToString
        Else
            var_pagina = 1
        End If


    End Sub

    Private Sub frmInsercionDocumento_ImeModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ImeModeChanged

    End Sub

    Private Sub frmInsercionDocumento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'cambiar el tipo y obtener datos iniciales NHC,...
        fnc_cambiarTipo(var_tipo)
    End Sub


    ''' <summary>
    ''' Metodo para cambiar el tipo de documento que deseamos insertar
    ''' </summary>
    ''' <param name="tipo">documento o caratula </param>
    ''' <remarks>Habilita los controles en funcion del tipo, y realiza comprobaciones como que la Historia 
    ''' este en el FIP o calcular el rango de documentos que tienen que copiar los datos del registro que 
    ''' estamos insertando para una caratula </remarks>
    Sub fnc_cambiarTipo(ByVal tipo As tipoInsercion)

        Select Case tipo
            Case tipoInsercion.Plantilla
                'Caratula
                var_tipo = tipoInsercion.Plantilla
                txtNHC.Enabled = True
                txtNumIcu.Enabled = True
                txtServicio.Enabled = True

                cmdCArgarImagen.Enabled = False
                txtRutaImagen.Enabled = False
                rdbInsertarCartula.Checked = True
                rdbInsertarDocumento.Checked = False

                txtDesde.Enabled = True
                txtHasta.Enabled = True

                txtNombre.Enabled = True
                txtApellido.Enabled = True
                txtApellido2.Enabled = True

                cmdPrevisualizacion.Enabled = True

                'calculamos el rango de documentos para los que tenemos que insertar los camos nhc 
                'episodio y servicio 
                If var_frmAnterior.dt_documentos.Rows.Count > 0 Then
                    txtDesde.Maximum = CInt(var_frmAnterior.dt_documentos(var_frmAnterior.dt_documentos.Rows.Count - 1).Item("pagina").ToString)
                    txtDesde.Value = var_pagina
                    txtDesde.Minimum = CInt(var_frmAnterior.dt_documentos(0).Item("pagina").ToString)
                    txtHasta.Maximum = txtDesde.Maximum
                    'Cuando cambiamos de caratula calculamos desde el registro que se
                    'se ha puesto hasta el final o el inicio de una nueva caratula y los resultados
                    'los ponemos en los combobox
                    Dim siguiente_caratula As System.Collections.Generic.List(Of DataRow)
                    siguiente_caratula = (From documento As DataRow In var_frmAnterior.dt_documentos Where CInt(documento.Item("pagina")) >= var_pagina AndAlso documento.Item("barcodedet") = "1" Order By CInt(documento.Item("pagina")) Ascending).ToList
                    If siguiente_caratula.Count > 0 Then
                        If CInt(siguiente_caratula(0).Item("pagina").ToString) - 1 < txtHasta.Minimum Then
                            txtHasta.Value = txtHasta.Minimum
                        Else
                            'si encuentra una caratula le damos el valor que le corresponde, sino lo situamos al final
                            txtHasta.Value = CInt(siguiente_caratula(0).Item("pagina").ToString) - 1
                        End If

                    Else
                        txtHasta.Value = CInt(txtDesde.Maximum)
                    End If
                Else
                    txtDesde.Maximum = 0
                    txtDesde.Minimum = 0
                    txtHasta.Maximum = 0
                    txtHasta.Minimum = 0
                End If


            Case Else
                'Documento
                var_tipo = tipoInsercion.Documento

                'Deshabilitamos los controles para NHC,ICU,SERV
                'se copian los datos del registro sobre el que hemos seleccionado la inserción 
                'en el formulario anterior
                txtNHC.Enabled = False
                txtNumIcu.Enabled = False
                txtServicio.Enabled = False

                'habilitamo menu inserción imagen 
                cmdCArgarImagen.Enabled = True
                txtRutaImagen.Enabled = True
                rdbInsertarDocumento.Checked = True
                rdbInsertarCartula.Checked = False

                txtDesde.Enabled = False
                txtHasta.Enabled = False

                txtNombre.Enabled = False
                txtApellido.Enabled = False
                txtApellido2.Enabled = False

                cmdPrevisualizacion.Enabled = False


                'Rellenamos los campos del NHC y en el caso de que encuentre el registro
                'Rellena los datos del paciente en el campo de texto
                If var_frmAnterior.grdDocumentos.CurrentRow IsNot Nothing Then
                    ' ''txtNHC.Text = "" ' var_frmAnterior.grdDocumentos.CurrentRow.Cells("NHC").Value.ToString
                    txtNHC.Text = var_frmAnterior.grdDocumentos.CurrentRow.Cells("NHC").Value.ToString
                    ' ''txtNumIcu.Text = var_frmAnterior.grdDocumentos.CurrentRow.Cells("ICU").Value.ToString
                    ' ''txtServicio.Text = var_frmAnterior.grdDocumentos.CurrentRow.Cells("Servicio").Value.ToString

                    'Rellenamos 
                    fnc_comprobarNHC()
                End If
        End Select

        Dim palabra As String = "documento"
        If var_tipo = 1 Then palabra = "carátula"

        If CheckBox1.Checked Then
            Me.Text = "Inserción de " & palabra & " al final del lote"
        Else
            Me.Text = "Inserción de " & palabra & " en la posicion: " & var_pagina
        End If

    End Sub

    ''' <summary>
    ''' fnc_comprobarNHC 
    ''' </summary>
    ''' <remarks>cuando cambiamos de foco buscamos en la tabla de de FIP los datosa del paciente
    ''' 
    ''' </remarks>
    Sub fnc_comprobarNHC()
        'cuando cambiamos de foco buscamos en la tabla de de FIP los datosa del paciente
        'Esto deberia estar en una CAPA SUPERIOR, metodo obtener Paciente (o algo asi)
        If txtNHC.Text.Length > 0 Then

            'Seleccionamos los datos, si no encuentra registro no rellenamos nada
            Dim sql As String = "SELECT isnull(nombre,'') nombre,isnull(apellido1,'') apellido1,isnull(apellido2,'') apellido2 from FIP WHERE numhistoria='" & txtNHC.Text & "'"
            Dim dt As DataTable = datos.ejecutarSQLDirecta(sql, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto).Tables(0)

            If dt IsNot Nothing Then
                If dt.Rows.Count > 0 Then
                    txtNombre.Text = dt.Rows(0).Item("Nombre").ToString()
                    cara_nombre = dt.Rows(0).Item("Nombre").ToString()
                    txtApellido.Text = dt.Rows(0).Item("apellido1").ToString()
                    cara_apellido1 = dt.Rows(0).Item("apellido1").ToString()
                    txtApellido2.Text = dt.Rows(0).Item("apellido2").ToString()
                    cara_apellido2 = dt.Rows(0).Item("apellido2").ToString()
                Else
                    txtNombre.Text = ""
                    txtApellido.Text = ""
                    txtApellido2.Text = ""

                    cara_nombre = ""
                    cara_apellido1 = ""
                    cara_apellido2 = ""

                End If
            Else
                txtNombre.Text = ""
                txtApellido.Text = ""
                txtApellido2.Text = ""
                cara_nombre = ""
                cara_apellido1 = ""
                cara_apellido2 = ""

            End If

        Else
            txtNombre.Text = ""
            txtApellido.Text = ""
            txtApellido2.Text = ""
            cara_nombre = ""
            cara_apellido1 = ""
            cara_apellido2 = ""

        End If


    End Sub




    ''' <summary>
    '''Segun el tipo de formulario que sea se realizan unas opciones u otras, 
    '''Genero una consulta LINQ con todos los documentos del formulario anterior, a partir del seeleccionado
    '''organizados de MAYOR A MENOR, para que cuando renombremos , no se sobreescriban
    '''uno a otro
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cmdInstertarDocumento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertarDocumento.Click

        If var_tipo = tipoInsercion.Plantilla Then

            'Comprobamos que hayan cumplimentado los datos del FIP, sino actualizamos
            If txtNombre.Text <> "" OrElse txtApellido2.Text <> "" OrElse txtApellido2.Text <> "" Then


                '' COMPROBAR SI LA HISTORIA EXISTE 
                'comprobar si existen los datos de la historia en la tabla FIP 
                'Si no existe el registro en la tabla de FIP, insertamos en la tabla FIP el numero de historia
                Dim sql As String = "IF (SELECT COUNT(*) from " & frmContenedorMDI.oProyecto._NombreBaseDatos & ".dbo.FIP WHERE NumHistoria ='" & txtNHC.Text & "') = 0 INSERT into " & frmContenedorMDI.oProyecto._NombreBaseDatos & ".dbo.FIP (NumHistoria) SELECT '" & txtNHC.Text & "'"
                datos.ejecutarSQLDirecta(sql, My.Settings.cadenaConexion)

                '' COMPROBAR SI SE HAN MODIFICADO LOS DATOS OBTENIDOS DE LA TABLA FIP
                'si se han modificado los datos iniciales obtenidos de la tabla FIP 
                'se actualiza la base de datos de la tabla FIP                 
                If cara_nombre <> txtNombre.Text OrElse cara_apellido1 <> txtApellido.Text OrElse cara_apellido2 <> txtApellido2.Text Then
                    If MsgBox("Se ha modificado los datos del nombre del cliente, desea modificarlo?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Atencion") = MsgBoxResult.Yes Then
                        sql = "UPDATE " & frmContenedorMDI.oProyecto._NombreBaseDatos & ".dbo.FIP set nombre='" & txtNombre.Text & "',apellido1= '" & txtApellido.Text & "',apellido2= '" & txtApellido2.Text & "' WHERE NumHistoria='" & txtNHC.Text & "'"
                        If datos.ejecutaSQLEjecucion(sql, My.Settings.cadenaConexion) Then
                            Me.Close()
                        End If

                    End If
                End If

            End If

            'Generamos en la rua temporal y visualizamos la caratula
            If fnc_caratula_previsualizar(varRutaTmpCaratula) Then
                'Insertamos caratula
                fnc_insercion_caratula(varRutaTmpCaratula)
            End If

        Else
            fnc_insercion_documento()
        End If
    End Sub

    Sub fnc_insercion_caratula(ByVal rutatemporal As String)

        'Comprobamos que todos los datos se encuentren

        Try

            'lkjlkjl
            Dim docs As System.Collections.Generic.List(Of DataRow)
            Dim tmp_var As Integer
            Dim ultimo As Boolean = False

            If CheckBox1.Checked Then
                'Obtenemos la el nonbre de la ultima imagen, obtener el count??? o me aseguro por si existen huecos en blanco..
                Try
                    tmp_var = CInt(var_frmAnterior.dt_documentos.Rows(var_frmAnterior.dt_documentos.Rows.Count - 1).Item("pagina").ToString) + 1
                    ultimo = True
                Catch ex As Exception
                    tmp_var = 1
                End Try
                docs = New System.Collections.Generic.List(Of DataRow)
            Else
                tmp_var = var_pagina
                ultimo = True
                docs = (From documento As DataRow In var_frmAnterior.dt_documentos Where CInt(documento.Item("pagina")) >= var_pagina Order By CInt(documento.Item("pagina")) Descending).ToList

            End If

            'Si no ha seleccionado una imagen, comprovamos la existencia de la misma
            If opDigi.documento_insercion(My.Settings.cadenaConexion, frmContenedorMDI.oProyecto._NombreBaseDatos, pgOperaciones, rutatemporal, frmContenedorMDI.oProyecto._CodigoProyecto, _
                                            frmContenedorMDI.oLote._idlote, tmp_var, var_frmAnterior.imagenes_ruta, docs, True, ultimo, txtNHC.Text, txtNumIcu.Text, txtServicio.Text) Then

                'Si realiza correctamente la insercion procedemos a hacer el update de ficheros siguientes
                'If datos.ejecutaSQLEjecucion("UPDATE documentos SET NumHistoria='" & txtNHC.Text & "', NumIcu='" & txtNumIcu.Text & "', codServicioUbicado='" & txtServicio.Text & "' WHERE proyecto='" & oProyecto._CodigoProyecto & "' and codigoLote='" & oLote._nombreCompleto & "' and pagina between " & (txtDesde.Value + 1) & " and " & (txtHasta.Value + 1), My.Settings.cadenaConexion) Then
                '    Me.Close()
                'End If
                'Actualizamos los datos de caratula

                If txtHasta.Value > txtDesde.Value Then
                    If accesoDatosDocumentos.ActualizaCamposCaratula(frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto, frmContenedorMDI.oProyecto._CodigoProyecto, frmContenedorMDI.oLote._idlote, _
             (txtDesde.Value + 1), (txtHasta.Value + 1), txtNHC.Text, txtNumIcu.Text, txtServicio.Text) Then
                        Me.Close()
                    End If
                Else
                    Me.Close()
                End If


                'ActualizaCamposCaratula()

            End If

        Catch ex As Exception
            MsgBox("Incidencia: " & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try

    End Sub

    Sub fnc_insercion_documento()
        If IO.File.Exists(txtRutaImagen.Text) Then
            Try
                Dim docs As System.Collections.Generic.List(Of DataRow)
                Dim tmp_var As Integer
                Dim ultimo As Boolean = False


                If CheckBox1.Checked Then 'esatamos añadiendo un documento al final de la lista 
                    'Obtenemos la el nonbre de la ultima imagen, obtener el count??? o me aseguro por si existen huecos en blanco..
                    'no pueden haber saltos de pagina 
                    Try
                        tmp_var = CInt(var_frmAnterior.dt_documentos.Rows(var_frmAnterior.dt_documentos.Rows.Count - 1).Item("pagina").ToString) + 1   'CInt(  docs(docs.Count - 1).Item("pagina").ToString) + 1
                        ultimo = True
                    Catch ex As Exception
                        'Si salta la excepcion es por que no hay registros
                        tmp_var = 1
                    End Try
                    docs = New System.Collections.Generic.List(Of DataRow)
                Else
                    tmp_var = var_pagina 'numero da pagina por el que se ha quedado 
                    'obtien
                    docs = (From documento As DataRow In var_frmAnterior.dt_documentos Where CInt(documento.Item("pagina")) >= var_pagina Order By CInt(documento.Item("pagina")) Descending).ToList

                End If

                'INSERCION DE DOCUMENTO

                'Si no ha seleccionado una imagen, comprovamos la existencia de la misma
                If opDigi.documento_insercion(My.Settings.cadenaConexion, frmContenedorMDI.oProyecto._NombreBaseDatos, pgOperaciones, txtRutaImagen.Text, frmContenedorMDI.oProyecto._CodigoProyecto, _
                                                frmContenedorMDI.oLote._idlote, tmp_var, var_frmAnterior.imagenes_ruta, docs, False, ultimo) Then
                    Me.Close()
                End If

            Catch ex As Exception
                MsgBox("Incidencia: " & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
            End Try

        Else
            MsgBox("No se puede leer la ruta destino", MsgBoxStyle.Critical, "Incidencia")
        End If

    End Sub



    Private Sub txtNHC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNHC.LostFocus
        fnc_comprobarNHC()
    End Sub



#Region "Manejadores controles del formulario "

    Private Sub rdbInsertarDocumento_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rdbInsertarDocumento.MouseDown
        fnc_cambiarTipo(tipoInsercion.Documento)
    End Sub

    Private Sub rdbInsertarCartula_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rdbInsertarCartula.MouseDown
        fnc_cambiarTipo(tipoInsercion.Plantilla)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrevisualizacion.Click
        fnc_caratula_previsualizar(My.Settings.RutaImagenTemp.ToString.Replace("""", "") & "\caratula.tif")
    End Sub


    Private Sub num_desde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesde.ValueChanged
        Try
            txtHasta.Minimum = txtDesde.Value
            If txtHasta.Value < txtHasta.Minimum Then txtHasta.Value = txtHasta.Minimum
            txtHasta.Maximum = txtDesde.Maximum
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        Dim palabra As String = "documento"
        If var_tipo = 1 Then palabra = "carátula"

        If CheckBox1.Checked Then
            Me.Text = "Inserción de " & palabra & " al final del lote"
        Else
            Me.Text = "Inserción de " & palabra & " en la posicion: " & var_pagina
        End If

    End Sub

#Region "Control de la imagen "


    Private Sub frmInsercionDocumento_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            PictureBox1.FitTo(0)
            PictureBox1.Display()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbCargarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCArgarImagen.Click
        Dim cargaImagen As New OpenFileDialog

        cargaImagen.Title = "Seleccione una imagen para mostrar"
        cargaImagen.Filter = "Archivo TIF|*.TIF"
        cargaImagen.Multiselect = False

        If cargaImagen.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            txtRutaImagen.Text = cargaImagen.FileName
            PictureBox1.Image = cargaImagen.FileName
            PictureBox1.FitTo(0)
            PictureBox1.Display()
            PictureBox1.Refresh()
        End If

    End Sub


    Function fnc_caratula_previsualizar(ByVal ruta As String)
        Try
            Dim imagen As Image = doc.generarCaratula(txtApellido.Text & " " & txtApellido2.Text & ", " & txtNombre.Text, txtNHC.Text, txtNumIcu.Text, frmContenedorMDI.oProyecto._obtenerCadenaConexionProyecto)
            Dim finfo As New IO.FileInfo(ruta)
            If finfo.Directory.Exists Then finfo.Directory.Create()
            PictureBox1.Image = ""
            If IO.File.Exists(ruta) Then IO.File.Delete(ruta)
            imagen.Save(ruta, System.Drawing.Imaging.ImageFormat.Tiff)

            PictureBox1.ClearDisplay()
            'PictureBox1.Refresh()
            PictureBox1.Image = ruta
            PictureBox1.Display()
            PictureBox1.FitTo(0)
            Return True

        Catch ex As Exception
            MsgBox("No se pudo escribir la imagen en la ruta seleccionada" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try
        Return False
    End Function

#End Region

#End Region

    Private Sub frmInsercionDocumento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            PictureBox1.Image = ""
            PictureBox1.ClearDisplay()
            PictureBox1.Dispose()
        Catch ex As Exception

        Finally

        End Try


    End Sub


End Class