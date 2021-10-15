
Namespace Entidades


    Public Class clsDescargas

        Dim NombreFiccheroRAR As String
        Dim NumHistoria As String
        Dim RutaRepositorioDocumentalista As String = ""
        Dim RutaRepositorioInformatica As String = ""
        Dim RutaRepositorioHospital As String = ""
        Dim NombreCarpetaHistoria As String = ""
        Dim NombreFicheroTXT As String = ""



        Public Sub New(ByVal NumHistoria As String)

            Me.NumHistoria = NumHistoria
            Me.NombreFiccheroRAR = "NHC" & NumHistoria & ".RAR"
            Me.NombreCarpetaHistoria = "NHC" & NumHistoria
            Me.NombreFicheroTXT = "NHC" & NumHistoria & ".txt"

        End Sub



        Public Property pNombreFicheroTXT() As String
            Get
                Return Me.NombreFicheroTXT
            End Get
            Set(ByVal value As String)
                Me.NombreFicheroTXT = value
            End Set
        End Property

        Public Property pNombreCarpetaHistoria() As String
            Get
                Return Me.NombreCarpetaHistoria
            End Get
            Set(ByVal value As String)
                Me.NombreCarpetaHistoria = value
            End Set
        End Property

        Public Property pNombreCortoFicheroRAR() As String
            Get
                Return Me.NombreFiccheroRAR
            End Get
            Set(ByVal value As String)
                Me.NombreFiccheroRAR = value
            End Set
        End Property

        Public Property pNumHistoria() As String
            Get
                Return Me.NumHistoria
            End Get
            Set(ByVal value As String)
                Me.NumHistoria = value
            End Set
        End Property

        Public Property pRutaRepositorioDocumentalista() As String
            Get
                Return Me.RutaRepositorioDocumentalista
            End Get
            Set(ByVal value As String)
                Me.RutaRepositorioDocumentalista = value
            End Set
        End Property

        Public Property pRutaRepositorioInformatica() As String
            Get
                Return Me.RutaRepositorioInformatica
            End Get
            Set(ByVal value As String)
                Me.RutaRepositorioInformatica = value
            End Set
        End Property


        Public Property pRutaRepositorioHospital() As String
            Get
                Return Me.RutaRepositorioHospital
            End Get
            Set(ByVal value As String)
                Me.RutaRepositorioHospital = value
            End Set
        End Property





    End Class

End Namespace
