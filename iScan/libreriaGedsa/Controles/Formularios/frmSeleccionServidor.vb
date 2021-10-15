Imports System.Data.Sql.SqlDataSourceEnumerator
Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Xml
Imports accesoBD = libreriacadenaproduccion.Datos.AdministrativosSQL.clsAccesoDatosMetaDatosSQL

Namespace Controles

    Namespace Formularios



        Public Class frmSeleccionServidor


           

            'Importante: La cadena de conexion ( ya construida ) se encuentra
            'almacenada en la propiedad "Me.valorCadenaConexion", actualmente
            'esta hecha para SQL. 


#Region "Constructores"

            Public Sub New()

                ' Llamada necesaria para el Diseñador de Windows Forms.
                InitializeComponent()

                ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

            End Sub

            Public Sub New(ByRef CandenaConexionServer As String)

                ' Llamada necesaria para el Diseñador de Windows Forms.
                InitializeComponent()

                ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
                Me.con = CandenaConexionServer

            End Sub




#End Region


#Region "Propiedades añadidas"

            Private con As String
            Public Property valorCadenaConexion() As String
                Get
                    Return con
                End Get
                Set(ByVal value As String)
                    con = value
                End Set
            End Property

           

            Private Servidor As String
            Public Property valorServidor() As String
                Get
                    Return Servidor
                End Get
                Set(ByVal value As String)
                    Servidor = value
                End Set
            End Property


            Private BaseDatos As String
            Public Property valorBD() As String
                Get
                    Return BaseDatos
                End Get
                Set(ByVal value As String)
                    BaseDatos = value
                End Set
            End Property



            Private user As String
            Public Property valorUser() As String
                Get
                    Return user
                End Get
                Set(ByVal value As String)
                    user = value
                End Set
            End Property


            Private pass As String
            Public Property valorPassword() As String
                Get
                    Return pass
                End Get
                Set(ByVal value As String)
                    pass = value
                End Set
            End Property





#End Region


#Region "Eventos"


            Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
                Me.Close()
            End Sub

            Private Sub frmSeleccionServidor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


                'obtenemos los servidores accesibles desde esa makina
                Dim instance As System.Data.Sql.SqlDataSourceEnumerator = System.Data.Sql.SqlDataSourceEnumerator.Instance
                Dim dataTable As System.Data.DataTable = instance.GetDataSources()
                Me.GroupBox2.Enabled = False
                Me.GroupBox3.Enabled = False


                'los mostramos en el combo
                For Each servidor As DataRow In dataTable.Rows

                    Me.cmdServidores.Items.Add(servidor("ServerName").ToString())

                Next





            End Sub



            Private Sub cmdServidores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdServidores.SelectedIndexChanged
                Me.Servidor = Me.cmdServidores.Text


            End Sub



            Private Sub cmdConectar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConectar.Click







                Try

                    If Me.cmbBD.Text <> "" Then
                        accesoBD.ObtenerTablasBD(Me.cmdServidores.Text, Me.txtUser.Text, Me.txtPsw.Text, Me.cmbBD.Text) ' si esto no peta eske se ha podido identificar
                    End If

                    If MessageBox.Show("Ha elegido el servidor " & Me.Servidor & " y la Tabla " & Me.cmbBD.Text & ". Esta seguro?", "Confirmacion del servidor", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then



                        Me.valorServidor = Me.cmdServidores.Text

                        'generico para sql
                        Me.valorCadenaConexion = "server=" & Me.valorServidor & ";uid=" & Me.txtUser.Text & ";pwd= " & Me.txtPsw.Text & ";database= " & Me.cmbBD.Text & ";"
                        Me.user = Me.txtUser.Text
                        Me.pass = Me.txtPsw.Text
                        Me.valorBD = Me.cmbBD.Text




                        Me.Close()
                    End If


                Catch ex As Exception
                    MessageBox.Show("Error al conectar al servidor." & vbCrLf & "Detalles:" & ex.Message, "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try





                '
            End Sub


            Private Sub cmdServidores_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdServidores.TextChanged

                Me.GroupBox2.Enabled = True


            End Sub




            Private Sub btnProbarConexxion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProbarConexxion.Click

                Try



                    For Each baseDatos As DataRow In accesoBD.ObtenerBaseDatosServidores(Me.cmdServidores.Text, Me.txtUser.Text, Me.txtPsw.Text).Rows

                        Me.cmbBD.Items.Add(baseDatos(0))

                        Me.GroupBox3.Enabled = True 'si hay almenos 1 activamos el groupbox 3


                    Next



                Catch ex As Exception

                End Try


            End Sub


#End Region


#Region "Funciones"

            Public Sub ocultarEleccionDeBD(ByVal valor As Boolean)

                Me.GroupBox3.Visible = valor


            End Sub





#End Region



        End Class



    End Namespace



End Namespace


