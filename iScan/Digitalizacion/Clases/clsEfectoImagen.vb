''' <summary>
''' Clase para controlar el efecto que le vamos a dar a la imagen 
''' </summary>
''' <remarks></remarks>
Public Class clsEfectoImagen

    Private var_modo As Integer
    Private var_posicion_filtro As Integer

    'Variable que nos define el multiplicador de los filtros
    Private var_filtro_multiplicador As Double

#Region "Eventos"
    Event evento_cambiaModo(ByVal modo As Integer)
#End Region

#Region "Constructores y destructores"

    ''' <summary>
    ''' Contructor
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()

    End Sub

    ''' <summary>
    ''' Reinciamos todos los datos de la clase
    ''' </summary>
    ''' <remarks></remarks>
    Sub reincia()

    End Sub

    ''' <summary>
    ''' Destruccion de la clase
    ''' </summary>
    ''' <remarks></remarks>
    Sub dispose()

    End Sub

#End Region

    ''' <summary>
    ''' Cambio de modo de la clase
    ''' </summary>
    ''' <param name="modo"></param>
    ''' <remarks></remarks>
    Sub modo_cambia(ByVal modo As Integer)
        Select Case modo
            Case 1, 2, 3
                '1) Modo de Rotado 2) Brillo 3) Contraste 
                var_modo = modo
            Case Else
                'Sin modos (Modo 0)
                var_modo = 0
        End Select

        'Lanzamos el evento de cambio de modo
        RaiseEvent evento_cambiaModo(var_modo)
    End Sub

    ''' <summary>
    ''' Nos indica si existe un cambio en la imagen
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function imagen_isModificada()
        If var_posicion_filtro <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
