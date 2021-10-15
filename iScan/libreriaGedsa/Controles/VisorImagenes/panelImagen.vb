'Imports filtro = libreriacadenaproduccion.TratamientoImagen.BitmapFilter
Imports filtrados = AForge.Imaging.Filters

Public Class panelImagen

#Region "Variables privadas"

    ''' <summary>
    ''' Existen diferentes modos en la imagen
    ''' </summary>
    ''' <remarks></remarks>
    Dim var_modo As Integer

    Dim var_activado As Boolean = True

    Private var_imagen As Image 'Imagen ORIGINAL
    'Private var_imagen_tmp As Image 'Imagen tamaño original , transformada (la que se guardará)
    Private var_imagen_resizeada As Image 'Imagen resizeada , transformada (para una previsualizacion más rápida)

    ''' <summary>
    ''' Esta variable sirve para controlar "posicion" del filtro cuando se está realizando,
    ''' ya que cuando se aplica un filtro la imagen
    ''' no puede volver al tamaño original, con lo que se ha de aplicar cada vez sobre
    ''' la original, siempre se reinicia a 0 cuando cambiamos el modo 
    ''' </summary>
    ''' <remarks></remarks>
    Private var_posicion_filtro As Integer
    'Variable que nos define el multiplicador de los filtros
    Private var_filtro_multiplicador As Double

    

#End Region

#Region "Eventos"
    Event evento_cambiaModo(ByVal modo As Integer)
    Event evento_imagenCargada()
#End Region

#Region "Propiedades"

    Public Property panel_activado() As Boolean
        Get
            Return var_activado
        End Get
        Set(ByVal value As Boolean)
            var_activado = value
            panel_barra_visible = value
        End Set
    End Property

    Public Property panel_barra_visible() As Boolean
        Get
            Return ToolStrip1.Visible
        End Get
        Set(ByVal value As Boolean)
            ToolStrip1.Visible = value
        End Set
    End Property


    Public Property panel_filtro_multiplicador() As Double
        Get
            Return var_filtro_multiplicador
        End Get
        Set(ByVal value As Double)
            var_filtro_multiplicador = value
        End Set
    End Property

    Property panel_imagen() As Image
        Get
            Return var_imagen
        End Get
        Set(ByVal value As Image)
            If value IsNot Nothing Then
                asignaImagen(value)
                Try
                    value.Dispose()
                    value = Nothing
                Catch ex As Exception

                End Try
                
            End If

        End Set
    End Property

#End Region

    Function imagen_isModificada()
        If var_posicion_filtro <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Creamos una copia de las imagenes para su tratamiento digital
    ''' </summary>
    ''' <remarks></remarks>
    Sub asignaImagen(ByRef tmp_imagen As Image)

        Try

            'Primero generamos la imagen que mostramos en el control
            Dim filtro As New AForge.Imaging.Filters.ResizeBilinear(obj_imagen.Width, obj_imagen.Height)
            var_imagen_resizeada = filtro.Apply(tmp_imagen)
            obj_imagen.Image = var_imagen_resizeada
            'imagen_libera()

            'Hacemos una copia en memoria de la actual para eliminar referencias
            var_imagen = tmp_imagen.Clone

            tmp_imagen.Dispose()
            tmp_imagen = Nothing

            'Reinicamos las variables
            var_posicion_filtro = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        RaiseEvent evento_imagenCargada()

    End Sub

    Function imagen_clona(ByRef imagen As Image) As Image
        Dim imagen2 As Image = New Bitmap(imagen.Width, imagen.Height)
        Dim g As Graphics = Graphics.FromImage(imagen2)
        Dim rec As New Rectangle(0, 0, imagen.Width, imagen.Height)
        g.DrawImage(imagen, rec)

        Try
            imagen.Dispose()
            imagen = Nothing

        Catch ex As Exception
            MsgBox("Incidencia liberando imagen: " & ex.Message, MsgBoxStyle.Critical, "Incidencia")
        End Try
        Return imagen2
    End Function


#Region "Constructores y destructores"

    Sub New()
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        var_modo = 0                        'sin ninguna opcion brillo, zoom  seleccionada 
        var_filtro_multiplicador = 0.15     'factor de incremento en brillo y contraste 
        var_posicion_filtro = 0             'pasos, incrementos, decrementos de efectos aplicados a la imagen 
    End Sub

    ''' <summary>
    ''' Este método libera la imagen que tengamos cargada en el control
    ''' </summary>
    ''' <remarks></remarks>
    Sub imagen_libera()
        'Liberamos al contenedor de la imagen
        obj_imagen.Image = Nothing

        'Destruimos la imagen
        If var_imagen IsNot Nothing Then var_imagen.Dispose()
        If var_imagen_resizeada IsNot Nothing Then var_imagen_resizeada.Dispose()

        'Liberamos de memoria
        var_imagen = Nothing
        var_imagen_resizeada = Nothing
    End Sub

  
#End Region

#Region "Menu superior"

    Private Sub btnRotacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotacion.Click
        cambiaModo(1)
    End Sub

    Private Sub btnZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoom.Click
        cambiaModo(4)
    End Sub

    Private Sub btnBrillo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrillo.Click
        cambiaModo(2)
    End Sub

    Private Sub btnContraste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContraste.Click
        cambiaModo(3)
    End Sub

#End Region

#Region "Metodos de clase"

    Public Property modo() As String
        Get
            Return var_modo
        End Get
        Set(ByVal value As String)
            cambiaModo(value)
        End Set
    End Property

    Sub cambiaModo(ByVal tmpModo As Integer, Optional ByVal evento As Boolean = True)

        If Not var_activado Then Exit Sub

        var_posicion_filtro = 0

        Select Case tmpModo
            Case 1
                If var_modo = 1 Then
                    cambiaModo(0)

                Else
                    var_modo = tmpModo
                    'Modo rotacion
                    btnZoom.Checked = False
                    btnBrillo.Checked = False
                    btnRotacion.Checked = True
                    btnContraste.Checked = False
                    btnSuave.Checked = False
                    obj_imagen.Focus()
                    'En el caso de que seleccionamos que se ejecute el evento 
                    If evento Then RaiseEvent evento_cambiaModo(var_modo)
                End If

            Case 2
                If var_modo = 2 Then
                    cambiaModo(0)
                Else
                    var_modo = tmpModo
                    'Modo brillo
                    btnZoom.Checked = False
                    btnBrillo.Checked = True
                    btnRotacion.Checked = False
                    btnContraste.Checked = False
                    btnSuave.Checked = False
                    obj_imagen.Focus()
                    If evento Then RaiseEvent evento_cambiaModo(var_modo)
                End If


            Case 3

                If var_modo = 3 Then
                    cambiaModo(0)
                Else
                    var_modo = tmpModo
                    'Modo Contraste
                    btnZoom.Checked = False
                    btnBrillo.Checked = False
                    btnRotacion.Checked = False
                    btnContraste.Checked = True
                    btnSuave.Checked = False

                    obj_imagen.Focus()
                    If evento Then RaiseEvent evento_cambiaModo(var_modo)
                End If

            Case 4
                If var_modo = 4 Then
                    cambiaModo(0)
                Else
                    var_modo = tmpModo
                    btnZoom.Checked = True
                    btnRotacion.Checked = False
                    btnBrillo.Checked = False
                    btnContraste.Checked = False
                    btnSuave.Checked = False
                    obj_imagen.Focus()
                    If evento Then RaiseEvent evento_cambiaModo(var_modo)
                End If
            Case 5

                'btnZoom.Checked = False
                'btnRotacion.Checked = False
                'btnBrillo.Checked = False
                'btnContraste.Checked = False
                'btnSuave.Checked = True
                'obj_imagen.Focus()

            Case Else
                var_modo = 0
                'Modo de exploracion
                btnRotacion.Checked = False
                btnBrillo.Checked = False
                btnContraste.Checked = False
                btnSuave.Checked = False
                btnZoom.Checked = False
        End Select
    End Sub


#End Region



    Public Function imagen_salva(ByVal ruta As String) As Boolean
        Dim correcto As Boolean = False
        Try

            'Clonamos la imagen actual en una imagen sin enlace a d
            Dim imagen As Image = imagen_clona(var_imagen)

            'Liberamos las imagenes
            imagen_libera()

            'Si existe eliminamos la imagen
            If IO.File.Exists(ruta) Then IO.File.Delete(ruta)

            'Salvamos la imagen en la ruta seleccionada
            imagen.Save(ruta, System.Drawing.Imaging.ImageFormat.Tiff)

            'Asignamos la imagen resultante
            asignaImagen(imagen)
            Return True
        Catch ex As Exception
            MsgBox("No se puede guardar la imagen en la ruta destino." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Incidencia de aplicacion")
        End Try
        Return False
    End Function

    Sub control_salvaEstado()
        var_imagen = imagen_trasforma(3, var_imagen, False)
        'y guardamos la imagen
    End Sub

    Function control_salvaEstado(ByVal ruta As String) As Boolean
        var_imagen = imagen_trasforma(3, var_imagen, False)
        Return imagen_salva(ruta)
    End Function


    Public Sub control_visualiza(ByVal cantidad As Integer)
        If modo <> 0 Then
            obj_imagen.Image = imagen_trasforma(cantidad)
        End If
    End Sub

    Public Function imagen_trasforma(ByVal cantidad As Integer) As Image
        Return imagen_trasforma(cantidad, var_imagen_resizeada)
    End Function



    Public Function imagen_trasforma(ByVal cantidad As Integer, ByRef tmpImage As Image, Optional ByVal incrementa As Boolean = True) As Image

        If Not var_activado Then Return Nothing

        If var_posicion_filtro = 0 Then
            Dim img As Image = imagen_clona(var_imagen)

            tmpImage.Dispose()
            tmpImage = Nothing

            'Liberamos la imagenes
            imagen_libera()

            'Primero generamos la imagen que mostramos en el control
            Dim filtro As New AForge.Imaging.Filters.ResizeBilinear(obj_imagen.Width, obj_imagen.Height)
            var_imagen_resizeada = filtro.Apply(img)
            obj_imagen.Image = var_imagen_resizeada

            'Hacemos una copia en memoria de la actual para eliminar referencias
            var_imagen = img
        End If

        If incrementa Then
            If cantidad = 0 Then

                var_posicion_filtro -= 1
                If var_posicion_filtro > -20 Then
                    var_posicion_filtro -= 1
                Else
                    var_posicion_filtro = -20
                End If
            Else
                'Ponemos una restriccion de 20 posiciones
                If var_posicion_filtro < 20 Then
                    var_posicion_filtro += 1
                Else
                    var_posicion_filtro = 20
                End If

            End If
        End If

        Select Case var_modo

            Case 1
                'rotacion
                Dim filtro As New filtrados.RotateBilinear(90 * var_posicion_filtro, True)
                Return filtro.Apply(var_imagen_resizeada)

                'var_imagen_resizeada.RotateFlip(RotateFlipType.Rotate90FlipNone)
                'var_imagen.RotateFlip(RotateFlipType.Rotate90FlipNone)

                'Me.obj_imagen.Refresh()

                'var_imagen.RotateFlip(RotateFlipType.Rotate90FlipNone)
                
            Case 2
                'brillo
                Dim filtro As New AForge.Imaging.Filters.BrightnessCorrection
                filtro.AdjustValue = 0.1 * var_posicion_filtro
                Return filtro.Apply(tmpImage)

            Case 3
                'Contraste
                obj_imagen.Image = Nothing
                Dim filtro As New AForge.Imaging.Filters.ContrastCorrection
                filtro.Factor = 0.1 * (var_posicion_filtro + 10)
                Return filtro.Apply(tmpImage)

            Case 4
                'Zoom

            Case 5
                'Suavizado
                obj_imagen.Image = Nothing
                Dim filtro As New AForge.Imaging.Filters.AdaptiveSmooth
                filtro.Factor = 0.1 * var_posicion_filtro
                Return filtro.Apply(tmpImage)
            Case Else
                var_posicion_filtro = 0
        End Select

        Return Nothing
    End Function

    Public Sub imagen_rotacion(ByVal cantidad As Integer)
        cambiaModo(1, False)
        control_visualiza(cantidad)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        'Boton cancelar nos devuelve al estado explorador
        cambiaModo(0)
    End Sub

    Private Sub btnSuave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSuave.Click
        cambiaModo(5)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        'Cuando aceptamos el filtro aplicamos el filtro actual a la imagen grande
        control_salvaEstado()

        'Dim nuevaImagen As Image = filtro.Apply(var_imagen_resizeada)

        'PictureBox1.Image = Image
        'filtro.Smooth(var_imagen_tmp, cant)
        'obj_imagen.Image = nuevaImagen
    End Sub

    Private Sub obj_imagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles obj_imagen.Click

    End Sub
End Class
