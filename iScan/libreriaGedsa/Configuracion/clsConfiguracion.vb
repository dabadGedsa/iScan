Imports System.Xml
Imports System.IO
Imports System.CodeDom
Imports System.CodeDom.Compiler

Namespace Configuracion

    Public Class clsConfiguracion

        Private docConfig As XmlDocument
        Private raizRutaObjeto As String
        Private rutaXML As String

        Private seccionUsuarios As String
        Private seccionAplicacion As String
        Private seccionCadenasConexion As String


        Public Enum tipoValorConfiguracion
            usuario = 1
            aplicacion = 2
            cadenaConexion = 3
        End Enum


        ''' <summary>
        ''' Constructor. Carga en memoria el archivo de configuración pasado como parámetro.
        ''' </summary>
        ''' <param name="rutaXML">
        ''' Ruta completa del archivo XML de configuración. El archivo de configuración correcto es el que tiene 
        ''' el formato "nombre de aplicacion".exe.config que se encuentra generalmente en la carpeta bin del 
        ''' proyecto.
        ''' </param>
        Public Sub New(ByVal rutaXML As String)

            Dim nombreArchivo As String

            Me.rutaXML = rutaXML

            ' le quitamos la extension y la ruta completa al nombre del archivo
            nombreArchivo = rutaXML.Substring(rutaXML.LastIndexOf("\") + 1)
            nombreArchivo = nombreArchivo.Remove(nombreArchivo.IndexOf("."))

            Me.docConfig = New XmlDocument()
            Me.docConfig.Load(rutaXML)

            seccionAplicacion = "configuration/applicationSettings/" & nombreArchivo & ".My.MySettings/setting"
            seccionUsuarios = "configuration/userSettings/" & nombreArchivo & ".My.MySettings/setting"
            seccionCadenasConexion = "configuration/connectionStrings/add"

            Me.raizRutaObjeto = nombreArchivo & ".My.MySettings."

        End Sub


#Region "Lectura XML"

        Private Function leerValorSettings(ByVal seccion As String, ByVal clave As String) As String

            For Each nodo As XmlNode In Me.docConfig.SelectNodes(seccion)

                If nodo.Attributes("name").Value = clave Then
                    Return nodo.ChildNodes(0).InnerText
                End If

            Next

            Return ""

        End Function


        Private Function leerValorCadenaConexion(ByVal seccion As String, ByVal clave As String) As String

            For Each nodo As XmlNode In Me.docConfig.SelectNodes(seccion)

                If nodo.Attributes("name").Value = Me.raizRutaObjeto & clave Then
                    Return nodo.Attributes("connectionString").Value
                End If

            Next

            Return ""

        End Function


        Public Function leerValor(ByVal campo As String, ByVal tipoValor As tipoValorConfiguracion) As String

            Dim res As String = ""

            Select Case tipoValor

                Case tipoValorConfiguracion.aplicacion
                    res = Me.leerValorSettings(Me.seccionAplicacion, campo)

                Case tipoValorConfiguracion.usuario
                    res = Me.leerValorSettings(Me.seccionUsuarios, campo)

                Case tipoValorConfiguracion.cadenaConexion
                    res = Me.leerValorCadenaConexion(Me.seccionCadenasConexion, campo)

            End Select

            Return res

        End Function


        Public Function leerValorUsuario(ByVal campo As String) As String

            Return Me.leerValorSettings(Me.seccionUsuarios, campo)

        End Function


        Public Function leerValorAplicacion(ByVal campo As String) As String

            Return Me.leerValorSettings(Me.seccionAplicacion, campo)

        End Function


        Public Function leerValorCadenaConexion(ByVal campo As String) As String

            Return Me.leerValorCadenaConexion(Me.seccionCadenasConexion, campo)

        End Function


#End Region

#Region "Escritura XML"


        Private Function escribirValorSetting(ByVal seccion As String, ByVal clave As String, ByVal valor As String) As Boolean

            Dim exito As Boolean = False

            For Each nodo As XmlNode In Me.docConfig.SelectNodes(seccion)

                If nodo.Attributes("name").Value = clave Then

                    nodo.ChildNodes(0).InnerText = valor
                    exito = True

                End If

            Next

            If exito Then
                Me.docConfig.Save(Me.rutaXML)
            End If

            Return exito

        End Function


        Private Function escribirValorCadenaConexion(ByVal seccion As String, ByVal clave As String, ByVal valor As String) As Boolean

            Dim exito As Boolean = False

            For Each nodo As XmlNode In Me.docConfig.SelectNodes(seccion)

                If nodo.Attributes("name").Value = Me.raizRutaObjeto & clave Then

                    nodo.Attributes("connectionString").Value = valor
                    exito = True

                End If

            Next

            If exito Then
                Me.docConfig.Save(Me.rutaXML)
            End If

            Return exito

        End Function


        Public Function escribirValor(ByVal campo As String, ByVal valor As String, ByVal tipoValor As tipoValorConfiguracion) As Boolean

            Dim res As Boolean = False

            Select Case tipoValor

                Case tipoValorConfiguracion.aplicacion
                    res = Me.escribirValorSetting(Me.seccionAplicacion, campo, valor)

                Case tipoValorConfiguracion.usuario
                    res = Me.escribirValorSetting(Me.seccionUsuarios, campo, valor)

                Case tipoValorConfiguracion.cadenaConexion
                    res = Me.escribirValorCadenaConexion(Me.seccionCadenasConexion, campo, valor)

            End Select

            Return res

        End Function


        Public Function escribirValorUsuario(ByVal campo As String, ByVal valor As String) As Boolean

            Return Me.escribirValorSetting(Me.seccionUsuarios, campo, valor)

        End Function


        Public Function escribirValorAplicacion(ByVal campo As String, ByVal valor As String) As Boolean

            Return Me.escribirValorSetting(Me.seccionAplicacion, campo, valor)

        End Function


        Public Function escribirValorCadenaConexion(ByVal campo As String, ByVal valor As String) As Boolean

            Return Me.escribirValorCadenaConexion(Me.seccionCadenasConexion, campo, valor)

        End Function


#End Region

#Region "Generación automática de código"

        Public Shared Sub generarClaseConfiguracion(ByVal rutaXML As String)

            Dim claseConfig As CodeTypeDeclaration
            Dim ccu As New CodeCompileUnit()
            Dim proveedorVB As CodeDomProvider = New VBCodeProvider()

            ' Creamos un namespace por defecto
            Dim namespacePorDefecto As New CodeNamespace("")

            Dim escritor As TextWriter

            Dim docXML As New XmlDocument()

            Dim nombreArchivo As String

            ' le quitamos la extension y la ruta completa al nombre del archivo
            nombreArchivo = rutaXML.Substring(rutaXML.LastIndexOf("\") + 1)
            nombreArchivo = nombreArchivo.Remove(nombreArchivo.IndexOf("."))

            docXML.Load(rutaXML)

            ' creamos la clase
            claseConfig = New CodeTypeDeclaration("clsConfig" & nombreArchivo)

            ' la marcamos como pública
            claseConfig.Attributes = MemberAttributes.Public

            ' añadimos las cadenas de conexión
            ' (por implementar)

            ' añadimos las configuraciones de usuario 
            claseConfig.Members.AddRange(clsConfiguracion.generarPropiedades("configuration/userSettings/" & nombreArchivo & ".My.MySettings/setting", docXML))

            ' añadimos las configuraciones de aplicación
            claseConfig.Members.AddRange(clsConfiguracion.generarPropiedades("configuration/applicationSettings/" & nombreArchivo & ".My.MySettings/setting", docXML))

            ' Añadimos la clase al namespace
            namespacePorDefecto.Types.Add(claseConfig)

            ' Añadimos el espacio de nombres al compilador
            ccu.Namespaces.Add(namespacePorDefecto)

            ' Creamos un Stream para guardar el código
            escritor = New StreamWriter(System.Environment.CurrentDirectory & "/" & "clsConfig" & nombreArchivo & "." & proveedorVB.FileExtension, False)

            ' Generamos el código
            proveedorVB.GenerateCodeFromCompileUnit(ccu, escritor, New CodeGeneratorOptions())

            ' Cerramos el fichero
            escritor.Close()

        End Sub


        Private Shared Function generarPropiedades(ByVal seccion As String, ByRef docXML As XmlDocument) As CodeTypeMember()

            Dim campo As CodeMemberField
            Dim propiedad As CodeMemberProperty
            Dim ordenReturn As CodeMethodReturnStatement
            Dim ordenAsignacion As CodeAssignStatement

            Dim codigo As New List(Of CodeTypeMember)()

            For Each nodo As XmlNode In docXML.SelectNodes(seccion)

                campo = New CodeMemberField(New CodeTypeReference("System.String"), String.Format("_{0}", nodo.Attributes("name").Value))
                campo.Attributes = MemberAttributes.Private

                propiedad = New CodeMemberProperty()
                propiedad.Name = nodo.Attributes("name").Value
                propiedad.Type = New CodeTypeReference("System.String")
                propiedad.Attributes = MemberAttributes.Public

                ' Creamos la instrucción return
                ordenReturn = New CodeMethodReturnStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), campo.Name))

                ' La añadimos al get de la propiedad
                propiedad.GetStatements.Add(ordenReturn)

                ' Creamos la orden de asignación
                ordenAsignacion = New CodeAssignStatement(New CodeFieldReferenceExpression(New CodeThisReferenceExpression(), campo.Name), New CodePropertySetValueReferenceExpression())

                ' La añadimos al set de la propiedad
                propiedad.SetStatements.Add(ordenAsignacion)

                ' Seguramente falle aqui al estar cambiando la misma referencia de los objetos campo y propiedad
                ' Añadimos el campo y la propiedad al conjunto de código que se agregará a la clase
                codigo.Add(campo)
                codigo.Add(propiedad)

            Next

            Return codigo.ToArray()

        End Function

#End Region


    End Class

End Namespace
