Imports System.IO
Imports clsExtraerTXT = libreriacadenaproduccion.TXT.ClsExtraerTXT
Imports clsLote = libreriacadenaproduccion.Entidades.ClsLote
Imports clsUsuario = libreriacadenaproduccion.Entidades.ClsUsuario
Imports accesoDatosOracle = libreriacadenaproduccion.Datos.GeneralOracle.clsAccesoDatosOracle
Imports clsRAR = libreriacadenaproduccion.RAR.clsRAR

Namespace Entidades

    Public Class clsPeticion


        Dim FechaPeticion As String
        Dim FechaDescarga As String
        Dim FechaCita As String
        Dim FechaEntrega As String
        Dim EsUrgente As String
        Dim EsEstudios As String
        Dim EsExitus As String
        Dim NumDocs As Integer
        Dim Observaciones As String

        'rutas de transferencia de ficheros 
        Dim rutaorig As String = "\\192.168.4.8\peticiones\47"
        Dim rutadestinoLocal As String = "c:\Descargas"
        Dim DestinoBackUp As String = "C:\BackupDescargas"



        Dim Nombre As String
        Dim Apellido1 As String
        Dim Apellido2 As String
        Dim dni As String
        Dim NHistoria As String
        Dim NumLinea As Integer
        Dim strSQL As String

        Dim importada As String
        Dim FechaImportacion As String
        Dim UsuarioPeticion As String
        Dim usuarioEntrega As String
        Dim FormatoEntrega As String
        Dim MedioEntrega As String
        Dim DestinoEntrega As String
        Dim nomFichero As String
        Dim prioridad As String
        Dim descargada As String



#Region "Constructores"

        Public Sub New()

        End Sub

       


#End Region

#Region "Propiedades"


        Public Property pImportada() As String
            Get
                Return Me.importada
            End Get
            Set(ByVal value As String)
                Me.importada = value
            End Set
        End Property

        Public Property pNomfichero() As String
            Get
                Return Me.nomFichero
            End Get
            Set(ByVal value As String)
                Me.nomFichero = value
            End Set
        End Property

        Public Property pFechaPeticion() As String
            Get
                Return Me.FechaPeticion
            End Get
            Set(ByVal value As String)
                Me.FechaPeticion = value
            End Set
        End Property

        Public Property pFechaDescarga() As String
            Get
                Return Me.FechaDescarga
            End Get
            Set(ByVal value As String)
                Me.FechaDescarga = value
            End Set
        End Property

        Public Property pFechaCita() As String
            Get
                Return Me.FechaCita
            End Get
            Set(ByVal value As String)
                Me.FechaCita = value
            End Set
        End Property

        Public Property pFechaEntrega() As String
            Get
                Return Me.FechaEntrega
            End Get
            Set(ByVal value As String)
                Me.FechaEntrega = value
            End Set
        End Property

        Public Property pEsUrgente() As String
            Get
                Return Me.EsUrgente
            End Get
            Set(ByVal value As String)
                Me.EsUrgente = value
            End Set
        End Property

        Public Property pEsEstudios() As String
            Get
                Return Me.EsEstudios
            End Get
            Set(ByVal value As String)
                Me.EsEstudios = value
            End Set
        End Property

        Public Property pEsExitus() As String
            Get
                Return Me.EsExitus
            End Get
            Set(ByVal value As String)
                Me.EsExitus = value
            End Set
        End Property

        Public Property pNumDocs() As Integer
            Get
                Return Me.NumDocs
            End Get
            Set(ByVal value As Integer)
                Me.NumDocs = value
            End Set
        End Property

        Public Property pObservaciones() As String
            Get
                Return Me.Observaciones
            End Get
            Set(ByVal value As String)
                Me.Observaciones = value
            End Set
        End Property

        Public Property prutaorig() As String
            Get
                Return Me.rutaorig
            End Get
            Set(ByVal value As String)
                Me.rutaorig = value
            End Set
        End Property

        Public Property prutadestinoLocal() As String
            Get
                Return Me.rutadestinoLocal
            End Get
            Set(ByVal value As String)
                Me.rutadestinoLocal = value
            End Set
        End Property

        Public Property pDestinoBackUp() As String
            Get
                Return Me.DestinoBackUp
            End Get
            Set(ByVal value As String)
                Me.DestinoBackUp = value
            End Set
        End Property

        Public Property pNombre() As String
            Get
                Return Me.Nombre
            End Get
            Set(ByVal value As String)
                Me.Nombre = value
            End Set
        End Property

        Public Property pApellido1() As String
            Get
                Return Me.Apellido1
            End Get
            Set(ByVal value As String)
                Me.Apellido1 = value
            End Set
        End Property

        Public Property pFechaImportacion() As String
            Get
                Return Me.FechaImportacion
            End Get
            Set(ByVal value As String)
                Me.FechaImportacion = value
            End Set
        End Property

        Public Property pApellido2() As String
            Get
                Return Me.Apellido2
            End Get
            Set(ByVal value As String)
                Me.Apellido2 = value
            End Set
        End Property

        Public Property pdni() As String
            Get
                Return Me.dni
            End Get
            Set(ByVal value As String)
                Me.dni = value
            End Set
        End Property

        Public Property pNHistoria() As String
            Get
                Return Me.NHistoria
            End Get
            Set(ByVal value As String)
                Me.NHistoria = value
            End Set
        End Property

        Public Property pNumLinea() As Integer
            Get
                Return Me.NumLinea
            End Get
            Set(ByVal value As Integer)
                Me.NumLinea = value
            End Set
        End Property

        Public Property pstrSQL() As String
            Get
                Return Me.strSQL
            End Get
            Set(ByVal value As String)
                Me.strSQL = value
            End Set
        End Property


        Public Property pUsuarioPeticion() As String
            Get
                Return Me.UsuarioPeticion
            End Get
            Set(ByVal value As String)
                Me.UsuarioPeticion = value
            End Set
        End Property




        Public Property pFormatoEntrega() As String
            Get
                Return Me.FormatoEntrega
            End Get
            Set(ByVal value As String)
                Me.FormatoEntrega = value
            End Set
        End Property


        Public Property pUsuarioEntrega() As String
            Get
                Return Me.UsuarioEntrega
            End Get
            Set(ByVal value As String)
                Me.UsuarioEntrega = value
            End Set
        End Property

        Public Property pMedioEntrega() As String
            Get
                Return Me.MedioEntrega
            End Get
            Set(ByVal value As String)
                Me.medioEntrega = value
            End Set
        End Property

        Public Property pDestinoEntrega() As String
            Get
                Return Me.DestinoEntrega
            End Get
            Set(ByVal value As String)

                Me.DestinoEntrega = value
            End Set
        End Property


        Public Property pPrioridad() As String
            Get
                Return Me.prioridad
            End Get
            Set(ByVal value As String)
                Me.prioridad = value
            End Set
        End Property


        Public Property pDescargada() As String
            Get
                Return Me.descargada
            End Get
            Set(ByVal value As String)
                Me.descargada = value
            End Set
        End Property




#End Region




#Region "Metodos"


        Public Function DescargarPeticion(ByVal rutaorig As String, ByVal rutadestinolocal As String) As Boolean

            Try

                Me.prutaorig = rutaorig
                Me.prutadestinoLocal = rutadestinolocal

                'si no exiten las rutas locales las crea 
                If Not Directory.Exists(Me.rutadestinoLocal) Then Directory.CreateDirectory(Me.rutadestinoLocal)
                If Not Directory.Exists(Me.DestinoBackUp) Then Directory.CreateDirectory(Me.DestinoBackUp)

                If File.Exists(Me.rutadestinoLocal & "\" & Me.nomFichero) Then File.Delete(Me.rutadestinoLocal & "\" & Me.nomFichero)
                If File.Exists(Me.DestinoBackUp & "\" & Me.nomFichero) Then File.Delete(Me.DestinoBackUp & "\" & Me.nomFichero)

                My.Computer.FileSystem.CopyFile(Me.pDestinoEntrega, Me.rutadestinoLocal & "\" & Me.nomFichero, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)
                My.Computer.FileSystem.CopyFile(Me.rutadestinoLocal & "\" & Me.nomFichero, Me.DestinoBackUp & "\" & Me.nomFichero, FileIO.UIOption.AllDialogs, FileIO.UICancelOption.ThrowException)

            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
                Return False
            End Try

            Return True

        End Function

        Public Function ComprobacionesRAR(ByVal peticion As clsPeticion, ByVal rutaorig As String, ByVal rutadestinolocal As String) As Boolean
            ComprobacionesRAR = False

            Try

                'Comprobar que el numero de documentos es correcto y coincide con el numero de imagenes del fichero
                If Directory.Exists("C:\temp\NHC" & peticion.pNHistoria) Then Directory.Delete("C:\temp\NHC" & peticion.pNHistoria, True)
                clsRAR.SentenciaDescomprimir(peticion.pDestinoEntrega, "C:\temp\", " x -phlp02 ")

                If clsExtraerTXT.LineasTXT("C:\temp\NHC" & peticion.pNHistoria & "\NHC" & peticion.pNHistoria & ".txt") = peticion.pNumDocs Then

                    'leer el numero total de imagenes
                    'Dim di As DirectoryInfo = New DirectoryInfo("C:\temp\NHC" & peticion.pNHistoria & "\")
                    Dim ContadorDeArchivos As System.Collections.IList
                    'Dim ContadorDeArchivos As String()
                    ContadorDeArchivos = Directory.GetFiles("C:\temp\NHC" & peticion.pNHistoria & "", "*.TIF")

                    If ContadorDeArchivos.Count = peticion.pNumDocs Then
                        ComprobacionesRAR = True
                    End If


                End If
                'se borra en fichero del directorio temporal
                Directory.Delete("C:\temp\NHC" & peticion.pNHistoria, True)

            Catch ex As Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
                Return False
            End Try

            Return ComprobacionesRAR

        End Function


#End Region



    End Class

End Namespace

