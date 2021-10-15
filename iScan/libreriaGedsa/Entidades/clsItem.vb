
Namespace Entidades


    Public Class clsItem


        Public Enum tipoOperador

            _igual = 1
            _is = 3
            _like = 4

        End Enum

        Private campo As String                 'columna de la base de datos 
        Public valor As Object                 'valor del registro
        Private operador As tipoOperador        'operador que utlizamos like,igual,distinto is null  ...

        Public Nombre As String                 'nombrecompleto de la columna -> tabla.columna
        Public valor2 As String                 'se utiliza para las fechas
        Public texto As Integer                 'se utiliza apra saber si se tiene que utilizar el like al hacer la consulta 
        Public Fecha As Integer                 'para indicar si el item es una fecha 
        'rangofecha sera 0 no 1 es rango 2 anterior 3 posterior
        Public RangoFecha As Integer            'para indicar si es un rango de fechas 


        Public Sub New()

        End Sub

        Public Sub New(ByVal nombrecolbd As String, ByVal valor As Object)
            Me.campo = nombrecolbd
            Me._valor = valor
            Me.operador = tipoOperador._igual
        End Sub

        Public Sub New(ByVal campo As String, ByVal valor As String, ByVal operador As tipoOperador)

            Me.campo = campo
            Me._valor = valor
            Me.operador = operador

        End Sub

        Public Sub New(ByVal campo As String, ByVal valor As String)

            Me.campo = campo
            Me._valor = valor
            Me.operador = tipoOperador._igual

        End Sub



        Public Property _Campo() As String
            Get
                Return Me.campo
            End Get
            Set(ByVal value As String)
                Me.campo = value
            End Set
        End Property


        Public Property _valor() As String
            Get
                Return Me.valor
            End Get
            Set(ByVal value As String)
                Me.valor = value
            End Set
        End Property

        Public Property _operador() As tipoOperador
            Get
                Return Me.operador
            End Get
            Set(ByVal value As tipoOperador)
                Me.operador = value
            End Set
        End Property

        Public Overrides Function ToString() As String

            Dim strOperador As String = ""

            Select Case Me.operador
                Case tipoOperador._is
                    strOperador = "IS"
                Case tipoOperador._like
                    strOperador = "LIKE"
                Case tipoOperador._igual
                    strOperador = "="
                Case Else
                    strOperador = "="
            End Select

            Return " " & Me.campo & " " & strOperador & " '" & Me.valor & "' "
        End Function

    End Class



End Namespace

