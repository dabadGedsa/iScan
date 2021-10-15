Imports System.ComponentModel
Imports System.IO

Imports libreriacadenaproduccion.Entidades
Imports libreriacadenaproduccion.DAT
Imports cons = libreriacadenaproduccion.Controles.Constantes


Namespace Controles
    Namespace VisorImagenes


        Public Class VisorDocumentos


            Private _listaDocumentos As List(Of ClsDocumento)
            Private _documentoCargado As ClsDocumento
            Private _leerImagenesArchivoDat As Boolean
            Private _carpetaImagenesTemporales As String
            Private _imagenPorDefecto As Image

            Public Delegate Sub delegadoElementoSeleccionado(ByVal documento As ClsDocumento, ByVal indice As Integer)
            Public Event elementoSeleccionadoCambiado As delegadoElementoSeleccionado


            Public Sub New()

                ' Llamada necesaria para el Diseñador de Windows Forms.
                InitializeComponent()

                ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

            End Sub


            Public Sub New(ByVal listaDocumentos As List(Of ClsDocumento), ByVal leerImagenesArchivoDat As Boolean)

                ' Llamada necesaria para el Diseñador de Windows Forms.
                InitializeComponent()

                ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

                Me._listaDocumentos = listaDocumentos
                Me._leerImagenesArchivoDat = leerImagenesArchivoDat

            End Sub


#Region "Propiedades y métodos públicos"

            <Browsable(False)> _
            Public Property listaDocumentos() As List(Of ClsDocumento)

                Get
                    Return Me._listaDocumentos
                End Get

                Set(ByVal value As List(Of ClsDocumento))

                    Me._listaDocumentos = value
                    Me._documentoCargado = Nothing
                    Me.ImageControl1.Image = Nothing

                    If value IsNot Nothing Then
                        Me.lblNavegacionImagenes.Text = "Imagen 0 de " & Me._listaDocumentos.Count
                    End If
                    
                End Set

            End Property


            <Category(cons.PROP_CATEG_GENE), Description("Indica si la ruta del documento corresponde a un archivo Dat o a una imagen."), Browsable(True)> _
            Public Property leerImagenesArchivoDat() As Boolean
                Get
                    Return Me._leerImagenesArchivoDat
                End Get
                Set(ByVal value As Boolean)
                    Me._leerImagenesArchivoDat = value
                End Set
            End Property


            <Category(cons.PROP_CATEG_GENE), Description("Indica la carpeta que se utilizará para almacenar las imágenes extraídas del archivo Dat."), Browsable(True)> _
            Public Property carpetaImagenesTemporales() As String
                Get
                    Return Me._carpetaImagenesTemporales
                End Get
                Set(ByVal value As String)
                    Me._carpetaImagenesTemporales = value
                End Set
            End Property


            <Browsable(False)> _
            Public ReadOnly Property documentoCargado() As ClsDocumento
                Get
                    Return Me._documentoCargado
                End Get
            End Property


            <Category(cons.PROP_CATEG_GENE), Description("Imagen que se mostrará en el caso de que no se encuentre la imagen del documento."), Browsable(True)> _
            Public Property imagenPorDefecto() As Image
                Get
                    Return Me._imagenPorDefecto
                End Get
                Set(ByVal value As Image)
                    Me._imagenPorDefecto = value
                End Set
            End Property


            Public Sub cargarDocumento(ByVal indice As Integer)

                ' Hago la carga de la imagen solo cuando sea diferente de la q ya sta cargada
                If (Me._documentoCargado Is Nothing) OrElse (Me._listaDocumentos.IndexOf(Me._documentoCargado) <> indice) Then

                    If Me._leerImagenesArchivoDat Then

                        Me.cargarDocumentoDesdeDat(indice)

                    Else

                        Me.cargarDocumentoDesdeImagen(indice)

                    End If

                End If

            End Sub


            Public Sub limpiarImagen()

                Me.ImageControl1.Image = Nothing
                Me._documentoCargado = Nothing
                Me.lblNavegacionImagenes.Text = "Imagen 0 de 0"

            End Sub

#End Region


#Region "Funciones y procedimientos privados"

            Private Sub cargarDocumentoDesdeImagen(ByVal indice As Integer)

                Try

                    Me.ImageControl1.Image = Image.FromFile(Me._listaDocumentos(indice)._NombreImagen)
                    Me._documentoCargado = Me._listaDocumentos(indice)
                    Me._listaDocumentos(indice)._cargado = True

                    Me.lblNavegacionImagenes.Text = "Imagen " & indice + 1 & " de " & Me._listaDocumentos.Count

                    RaiseEvent elementoSeleccionadoCambiado(Me._listaDocumentos(indice), indice)

                Catch

                    If Me._imagenPorDefecto IsNot Nothing Then
                        Me.ImageControl1.Image = Me._imagenPorDefecto
                    End If

                End Try

            End Sub


            Private Sub cargarDocumentoDesdeDat(ByVal indice As Integer)

                Dim imagen As MemoryStream

                Try

                    If Me._listaDocumentos(indice)._cargado Then

                        ' La imagen ya ha sido cargada y la ruta del archivo temporal se encuentra en el campo "rutaImagenTemporal"
                        Me.ImageControl1.Image = Image.FromStream(Me._listaDocumentos(indice)._imagen)

                    Else

                        ' La imagen no ha sido cargada, por tanto la extraigo del dat
                        imagen = New MemoryStream(ClsExtraerDat.extraerImagenDatAMemoria(Me._listaDocumentos(indice)._NombreImagen, Me._listaDocumentos(indice)._inicioDevice, Me._listaDocumentos(indice)._sizeDevice))
                        Me.ImageControl1.Image = Image.FromStream(imagen)

                        Me._listaDocumentos(indice)._cargado = True
                        Me._listaDocumentos(indice)._imagen = imagen

                    End If

                    Me._documentoCargado = Me._listaDocumentos(indice)

                    Me.lblNavegacionImagenes.Text = "Imagen " & indice + 1 & " de " & Me._listaDocumentos.Count

                    RaiseEvent elementoSeleccionadoCambiado(Me._listaDocumentos(indice), indice)

                Catch

                    If Me._imagenPorDefecto IsNot Nothing Then
                        Me.ImageControl1.Image = Me._imagenPorDefecto
                    End If
                    
                End Try

            End Sub

#End Region


#Region "Eventos y métodos para la navegación de imágenes"

            Private Sub btnAtrasSimple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonAtras.eClick
                Me.atrasSimple()
            End Sub

            Private Sub btnAdelanteSimple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonAdelante.eClick
                Me.adelenteSimple()
            End Sub

            Private Sub btnAtrasTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonAtrasTodo.eClick
                Me.atrasTodo()
            End Sub

            Private Sub btnAdelanteTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BotonAdelanteTodo.eClick
                Me.adelanteTodo()
            End Sub


            Public Sub atrasTodo()

                If Me._leerImagenesArchivoDat Then

                    Me.cargarDocumentoDesdeDat(0)

                Else

                    Me.cargarDocumentoDesdeImagen(0)

                End If

            End Sub


            Public Sub adelanteTodo()

                If Me._leerImagenesArchivoDat Then

                    Me.cargarDocumentoDesdeDat(Me._listaDocumentos.Count - 1)

                Else

                    Me.cargarDocumentoDesdeImagen(Me._listaDocumentos.Count - 1)

                End If

            End Sub


            Public Sub adelenteSimple()

                Dim indice As Integer

                If Me._documentoCargado IsNot Nothing Then

                    indice = Me._listaDocumentos.IndexOf(Me._documentoCargado)

                    If (indice >= 0) And (indice < Me._listaDocumentos.Count - 1) Then

                        If Me._leerImagenesArchivoDat Then

                            Me.cargarDocumentoDesdeDat(indice + 1)

                        Else

                            Me.cargarDocumentoDesdeImagen(indice + 1)

                        End If

                    End If

                End If

            End Sub


            Public Sub atrasSimple()

                Dim indice As Integer

                If Me._documentoCargado IsNot Nothing Then

                    indice = Me._listaDocumentos.IndexOf(Me._documentoCargado)

                    If (indice >= 1) And (indice < Me._listaDocumentos.Count) Then

                        If Me._leerImagenesArchivoDat Then

                            Me.cargarDocumentoDesdeDat(indice - 1)

                        Else

                            Me.cargarDocumentoDesdeImagen(indice - 1)

                        End If

                    End If

                End If

            End Sub


#End Region


#Region "Controles de Lupa y otras funciones de visualización"

            Private Sub tstAmpliarSeleccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstAmpliarSeleccion.Click

                If Me.ImageControl1.PanMode Then
                    Me.ImageControl1.PanMode = False
                End If

            End Sub

            Private Sub tstAmpliarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstAmpliarImagen.Click

                Me.ampliarImagen()

            End Sub


            Private Sub tstReducirImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstReducirImagen.Click

                Me.reducirImagen()

            End Sub


            Private Sub tstAjustarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstAjustarImagen.Click
                Me.ImageControl1.fittoscreen()
            End Sub

            Private Sub HerramientaMano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tstHerramientaMano.Click
                If Me.ImageControl1.PanMode = False Then
                    Me.ImageControl1.PanMode = True
                End If
            End Sub

            Private Sub ToolStripButtonRotarImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonRotarImagen.Click

                If Me.ImageControl1.Image IsNot Nothing Then
                    Me.ImageControl1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    Me.ImageControl1.Refresh()
                End If

            End Sub

            ' Ampliamos la imagen cuatro veces, partiendo de la imagen ajustada a la ventana
            Private Sub ampliarVistaImagenActual()

                Me.ImageControl1.fittoscreen()
                Me.ImageControl1.ZoomIn()
                Me.ImageControl1.ZoomIn()
                Me.ImageControl1.ZoomIn()
                Me.ImageControl1.ZoomIn()

            End Sub


            Public Sub ampliarImagen()
                Me.ImageControl1.ZoomIn()
            End Sub


            Public Sub reducirImagen()
                Me.ImageControl1.ZoomOut()
            End Sub

#End Region


        End Class


    End Namespace
End Namespace