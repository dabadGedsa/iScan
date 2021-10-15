Imports editor = LibreriaCadenaProduccion.TXT.clsFormato


Public Class frmAviso

    Private datosAvisoLoteado As DataTable
    Private datosnhcnoindizadas As DataTable
    Private datosdigilot As DataTable
    Private datosnumpaginas As DataTable

    Public Sub New(ByVal datosLoteado As DataTable, ByVal nhcnoindizadas As DataTable, ByVal datosdigilot As DataTable, ByVal datosnumpaginas As DataTable)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.datosnhcnoindizadas = nhcnoindizadas
        Me.datosAvisoLoteado = datosLoteado
        Me.datosdigilot = datosdigilot
        Me.datosnumpaginas = datosnumpaginas

    End Sub

    
    Private Sub frmAviso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        If Not IsNothing(Me.datosnhcnoindizadas) And Me.datosnhcnoindizadas.Rows.Count > 0 Then

            editor.escribir(Me.rtbpizarra, "Se ha detectado registros a los que les faltan datos por cumplimentar .", Color.Red)
            Try

                For Each registro As DataRow In Me.datosnhcnoindizadas.Rows
                    editor.escribir(Me.rtbpizarra, "Pagina ->" & registro.Item(0).ToString, Color.Blue)
                Next


            Catch ex As Exception
                MessageBox.Show("No se puede mostrar el numreo de pagina ")
            End Try

        End If


        If Not IsNothing(datosAvisoLoteado) And datosAvisoLoteado.Rows.Count > 0 Then

            editor.escribir(Me.rtbpizarra, "Atención se crearon caratulas para historias que no aparecen en este lote.Verifique la existencia o no de caratula para las siguientes historias. Si esta seguro de que esta todo correcto puede cerrar el lote desde el menu de administración.", Color.Red)

            Try

                For Each registro As DataRow In Me.datosAvisoLoteado.Rows

                    editor.escribir(Me.rtbpizarra, "Num historia ->" & registro.Item(0).ToString, Color.Blue)
                Next


            Catch ex As Exception
                MessageBox.Show("No se puede mostrar el numreo de pagina ")
            End Try
        End If


        If Not IsNothing(datosdigilot) And datosdigilot.Rows.Count > 0 Then

            editor.escribir(Me.rtbpizarra, "Atención se han digitalizado historias sin caratula para este lote.Verifique la existencia o no de caratula para las siguientes historias. Si esta seguro de que esta todo correcto puede cerrar el lote desde el menu de administración.", Color.Red)

            Try

                For Each registro As DataRow In Me.datosdigilot.Rows

                    editor.escribir(Me.rtbpizarra, "Num historia ->" & registro.Item(0).ToString, Color.Blue)
                Next


            Catch ex As Exception
                MessageBox.Show("No se puede mostrar el numreo de pagina ")
            End Try
        End If

        If Not IsNothing(Me.datosnumpaginas) And Me.datosnumpaginas.Rows.Count > 0 Then

            editor.escribir(Me.rtbpizarra, "Atención se han digitalizado historias con distinto número de paginas al indicado al crear la carátula. Si esta seguro de que esta todo correcto puede cerrar el lote desde el menu de administración.", Color.Red)

            Try

                For Each registro As DataRow In Me.datosnumpaginas.Rows

                    editor.escribir(Me.rtbpizarra, "Num historia ->" & registro.Item(0).ToString, Color.Blue)
                    editor.escribir(Me.rtbpizarra, "Docs. digitalizados ->" & registro.Item(1).ToString, Color.Blue)
                    editor.escribir(Me.rtbpizarra, "Docs. contados carat ->" & registro.Item(2).ToString, Color.Blue)
                Next


            Catch ex As Exception
                MessageBox.Show("No se puede mostrar el numreo de pagina ")
            End Try
        End If

    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class