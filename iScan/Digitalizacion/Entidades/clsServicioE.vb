Namespace Entidades

    Public Class clsServicioE

#Region "Variables privadas"

        Private idServicio As Integer
        Private codigoServicio As String
        Private descripcionServicio As String
        Private area As String
        Private visible As Integer

#End Region

#Region "Constructores y destructores"

        Public Sub New()

        End Sub

        Public Sub New(ByVal idServicio As Integer)

            'Aqui hará consulta y devolverá el objeto cargado

        End Sub

        ''' <summary>
        ''' Constructor del objeto lote
        ''' </summary>
        ''' <param name="lote">nombre del lote, lote1 , lote2, lote3</param>
        ''' <param name="codigoproyecto ">Identifica al proyecto al que pertenece el lote </param> 
        ''' <param name="fechalote">es util para diferenciar los lotes dentro de un mism proyecto en años diferentes</param> 
        ''' <remarks> 
        '''se crea un tipo de documento con el codigo del proyecto 
        ''' </remarks> 
        Public Sub New(ByVal idServicio As Integer, ByVal codigoServicio As String, ByVal descripcionServicio As String, ByVal area As String, ByVal visible As Integer)
            Me.idServicio = idServicio
            Me.codigoServicio = codigoServicio
            Me.descripcionServicio = descripcionServicio
            Me.area = area
            Me.visible = visible
        End Sub

#End Region

#Region "Propiedades"
        Public Property _idServicio() As Integer
            Get
                Return idServicio
            End Get
            Set(ByVal value As Integer)
                idServicio = value
            End Set
        End Property

        Public Property _codigoServicio() As String
            Get
                Return codigoServicio
            End Get
            Set(ByVal value As String)
                codigoServicio = value
            End Set
        End Property

        Public Property _descripcionServicio() As String
            Get
                Return descripcionServicio
            End Get
            Set(ByVal value As String)
                descripcionServicio = value
            End Set
        End Property

        Public Property _area() As String
            Get
                Return area
            End Get
            Set(ByVal value As String)
                area = value
            End Set
        End Property

        Public Property _visible() As Integer
            Get
                Return visible
            End Get
            Set(ByVal value As Integer)
                visible = value
            End Set
        End Property

#End Region

    End Class
End Namespace