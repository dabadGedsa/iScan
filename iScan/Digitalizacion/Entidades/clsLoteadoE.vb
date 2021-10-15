Namespace Entidades

    Public Class clsLoteadoE

#Region "Variables privadas"

        Private codigoProyecto As String
        Private idCaja As Integer
        Private idLote As Integer
        Private numHistoria As Integer
        Private fechaLoteado As String
        Private usuarioLoteado As String
        Private sinDocumentos As Integer
        Private incidencia As Integer
        Private coleccion As String

#End Region

#Region "Constructores y destructores"

        Public Sub New()

        End Sub

        Public Sub New(ByVal lote As Integer)

        End Sub


        ''' <summary>
        ''' Constructor del objeto lote
        ''' </summary>
        ''' <param name="lote">nombre del lote, lote1 , lote2, lote3</param>
        ''' <param name="codigoproyecto ">Identifica al proyecto al que pertenece el lote </param> 
        ''' <param name="fechalote">es util para diferenciar los lotes dentro de un mism proyecto en años diferentes</param> 
        ''' <remarks> 
        '''se crea un lote con el codigo del proyecto 
        ''' </remarks> 
        Public Sub New(ByVal caja As Integer, ByVal lote As Integer, ByVal codigoproyecto As String, ByVal numHistoria As Integer)
            Me.codigoProyecto = codigoproyecto
            Me.idCaja = caja
            Me.idLote = lote
            Me.numHistoria = numHistoria
        End Sub

#End Region

#Region "Propiedades"
        Public Property _Caja() As Integer
            Get
                Return idLote
            End Get
            Set(ByVal value As Integer)
                idLote = value
            End Set
        End Property

        Public Property _Lote() As Integer
            Get
                Return idLote
            End Get
            Set(ByVal value As Integer)
                idLote = value
            End Set
        End Property

        Public Property _NumeroHistoria() As Integer
            Get
                Return numHistoria
            End Get
            Set(ByVal value As Integer)
                numHistoria = value
            End Set
        End Property

        Public Property _codigoProyecto() As String
            Get
                Return Me.codigoProyecto
            End Get
            Set(ByVal value As String)

                Me.codigoProyecto = value

            End Set
        End Property

        Public Property _FechaLoteado() As String
            Get
                Return Me.fechaLoteado
            End Get
            Set(ByVal value As String)

                Me.fechaLoteado = value

            End Set
        End Property

        Public Property _UsuarioLoteado() As String
            Get
                Return Me.usuarioLoteado
            End Get
            Set(ByVal value As String)

                Me.usuarioLoteado = value

            End Set
        End Property

        Public Property _sinDocumentos() As Integer
            Get
                Return sinDocumentos
            End Get
            Set(ByVal value As Integer)
                sinDocumentos = value
            End Set
        End Property

        Public Property _incidencia() As Integer
            Get
                Return incidencia
            End Get
            Set(ByVal value As Integer)
                incidencia = value
            End Set
        End Property

        Public Property _coleccion() As Integer
            Get
                Return coleccion
            End Get
            Set(ByVal value As Integer)
                coleccion = value
            End Set
        End Property

#End Region

    End Class

End Namespace