Public Class clsComboBox
    Inherits Windows.Forms.ComboBox

    Public prueba As String = ""


    Private var_ As String

    Public Property NewProperty() As String
        Get
            Return var_
        End Get
        Set(ByVal value As String)
            var_ = value
        End Set
    End Property


    Public Sub muestraMensaje()
        MsgBox(prueba)
    End Sub

End Class
