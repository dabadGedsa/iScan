
Namespace Entidades

    Public Class clsTipoDocumentoE

#Region "Variables privadas"

        Private idTipoDocumento As Integer
        Private DescripcionTipoDocumento As String
        Private codigoOrdenacion As Integer
        Private idTipoDocumentoCliente As Integer
        Private DescripcionTipoDocumentoCliente As String

#End Region

#Region "Constructores y destructores"

        Public Sub New()

        End Sub

        Public Sub New(ByVal idTipoDocumento As Integer)

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
        Public Sub New(ByVal idTipoDocumento As Integer, ByVal DescripcionTipoDocumento As String, ByVal idTipoDocumentoCliente As Integer, ByVal DescripcionTipoDocumentoCliente As String)
            Me.idTipoDocumento = idTipoDocumento
            Me.DescripcionTipoDocumento = DescripcionTipoDocumento
            Me.idTipoDocumentoCliente = idTipoDocumentoCliente
            Me.DescripcionTipoDocumentoCliente = DescripcionTipoDocumentoCliente
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
        Public Sub New(ByVal idTipoDocumento As Integer, ByVal DescripcionTipoDocumento As String, ByVal idTipoDocumentoCliente As Integer, ByVal DescripcionTipoDocumentoCliente As String, ByVal codigoOrdenacion As Integer)
            Me.idTipoDocumento = idTipoDocumento
            Me.DescripcionTipoDocumento = DescripcionTipoDocumento
            Me.idTipoDocumentoCliente = idTipoDocumentoCliente
            Me.DescripcionTipoDocumentoCliente = DescripcionTipoDocumentoCliente
            Me.codigoOrdenacion = codigoOrdenacion
        End Sub
#End Region

#Region "Propiedades"
        Public Property _idTipoDocumento() As Integer
            Get
                Return idTipoDocumento
            End Get
            Set(ByVal value As Integer)
                idTipoDocumento = value
            End Set
        End Property

        Public Property _DescripcionTipoDocumento() As String
            Get
                Return DescripcionTipoDocumento
            End Get
            Set(ByVal value As String)
                DescripcionTipoDocumento = value
            End Set
        End Property

        Public Property _idTipoDocumentoCliente() As Integer
            Get
                Return idTipoDocumentoCliente
            End Get
            Set(ByVal value As Integer)
                idTipoDocumentoCliente = value
            End Set
        End Property

        Public Property _DescripcionTipoDocumentoCliente() As String
            Get
                Return DescripcionTipoDocumentoCliente
            End Get
            Set(ByVal value As String)
                DescripcionTipoDocumentoCliente = value
            End Set
        End Property

        Public Property _codigoOrdenacion() As Integer
            Get
                Return codigoOrdenacion
            End Get
            Set(ByVal value As Integer)
                codigoOrdenacion = value
            End Set
        End Property

#End Region

    End Class
End Namespace

