Imports System.Data.SqlClient

Public Class frmLectores

    Private Sub frmLectores_Load(sender As Object, e As EventArgs) Handles Me.Load
        Mostrar()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Dim ex, ey As Integer
    Dim Arrastre As Boolean

    Private Sub panelTitulo_MouseDown(sender As Object, e As MouseEventArgs) Handles panelTitulo.MouseDown
        ex = e.X
        ey = e.Y
        Arrastre = True
    End Sub

    Private Sub panelTitulo_MouseMove(sender As Object, e As MouseEventArgs) Handles panelTitulo.MouseMove
        If Arrastre Then Me.Location = Me.PointToScreen(New Point(frmLectores.MousePosition.X - Me.Location.X - ex, frmLectores.MousePosition.Y - Me.Location.Y - ey))
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        panelDatos.Visible = True
        btnGuardar.Enabled = True
        btnModificar.Enabled = False
        txtIdentidad.Focus()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Limpiar()
        btnGuardar.Enabled = True
        btnModificar.Enabled = True
        panelDatos.Visible = False
    End Sub

    Private Sub panelTitulo_MouseUp(sender As Object, e As MouseEventArgs) Handles panelTitulo.MouseUp
        Arrastre = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim cmd As New SqlCommand

        If txtNombre.Text <> "" And txtIdentidad.Text <> "" Then
            Try
                Abrir_conexion()
                cmd = New SqlCommand("Insertar_Lector", conexion)
                cmd.CommandType = 4

                cmd.Parameters.AddWithValue("@IdLector", txtIdentidad.Text.ToString)
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.ToString)
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.ToString)
                cmd.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text.ToString)
                cmd.ExecuteNonQuery()

                Cerrar_conexion()

                panelDatos.Visible = False
                Limpiar()
                Mostrar()
            Catch ex As Exception

            End Try
        Else
            MsgBox("Los campos Numero de Identidad y Nombre, son obligatorios", vbInformation + vbOK, "Sistema Letores")
        End If
    End Sub

    Private Sub Limpiar()
        txtIdentidad.Clear()
        txtNombre.Clear()
        txtTelefono.Clear()
        txtDireccion.Clear()
        txtObservaciones.Clear()
        txtIdentidad.Focus()
    End Sub

    Private Sub Mostrar()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Try
            Abrir_conexion()
            da = New SqlDataAdapter("Mostrar_Lector", conexion)
            da.Fill(dt)
            dataLectores.DataSource = dt
            Cerrar_conexion()

            'cambiar ancho de las columnas(encabezados)
            dataLectores.Columns(0).Width = 180
            dataLectores.Columns(1).Width = 250
            dataLectores.Columns(2).Width = 100
            dataLectores.Columns(3).Width = 300
            dataLectores.Columns(4).Width = 300

            'Cambiar apariencia de los encabezados
            dataLectores.EnableHeadersVisualStyles = False
            Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle()

            estilo.BackColor = Color.White
            estilo.ForeColor = Color.Black
            estilo.Font = New Font("Segoe UI", 10, FontStyle.Regular Or FontStyle.Bold)
            dataLectores.ColumnHeadersDefaultCellStyle = estilo

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Buscar()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Try
            Abrir_conexion()
            da = New SqlDataAdapter("Buscar_Lector", conexion)
            da.SelectCommand.CommandType = 4
            da.SelectCommand.Parameters.AddWithValue("@Busqueda", txtBuscar.Text)
            da.Fill(dt)
            dataLectores.DataSource = dt
            Cerrar_conexion()

            'cambiar ancho de las columnas(encabezados)
            dataLectores.Columns(0).Width = 180
            dataLectores.Columns(1).Width = 250
            dataLectores.Columns(2).Width = 100
            dataLectores.Columns(3).Width = 300
            dataLectores.Columns(4).Width = 300

            'Cambiar apariencia de los encabezados
            dataLectores.EnableHeadersVisualStyles = False
            Dim estilo As DataGridViewCellStyle = New DataGridViewCellStyle()

            estilo.BackColor = Color.White
            estilo.ForeColor = Color.Black
            estilo.Font = New Font("Segoe UI", 10, FontStyle.Regular Or FontStyle.Bold)
            dataLectores.ColumnHeadersDefaultCellStyle = estilo
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dataLectores_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataLectores.CellContentDoubleClick
        panelDatos.Visible = True

        Try
            txtIdentidad.Text = dataLectores.SelectedCells.Item(0).Value
            txtNombre.Text = dataLectores.SelectedCells.Item(1).Value
            txtTelefono.Text = dataLectores.SelectedCells.Item(2).Value
            txtDireccion.Text = dataLectores.SelectedCells.Item(3).Value
            txtObservaciones.Text = dataLectores.SelectedCells.Item(4).Value

            btnGuardar.Enabled = False
            btnModificar.Enabled = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim cmd As New SqlCommand

        If txtNombre.Text <> "" And txtIdentidad.Text <> "" Then
            Try
                Abrir_conexion()
                cmd = New SqlCommand("Editar_Lector", conexion)
                cmd.CommandType = 4

                cmd.Parameters.AddWithValue("@IdLector", txtIdentidad.Text.ToString)
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text.ToString)
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text)
                cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text.ToString)
                cmd.Parameters.AddWithValue("@Observaciones", txtObservaciones.Text.ToString)
                cmd.ExecuteNonQuery()

                Cerrar_conexion()

                panelDatos.Visible = False
                Limpiar()
                Mostrar()
            Catch ex As Exception

            End Try
        Else
            MsgBox("Los campos Numero de Identidad y Nombre, son obligatorios", vbInformation + vbOK, "Sistema Letores")
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Buscar()
        panelDatos.Visible = False
    End Sub


    '<a href = "https://www.flaticon.es/iconos-gratis/buscar" title="buscar iconos">Buscar iconos creados por inkubators - Flaticon</a>
    '<a href="https://www.flaticon.es/iconos-gratis/mas" title="más iconos">Más iconos creados por Smashicons - Flaticon</a>
    '<a href="https://www.flaticon.es/iconos-gratis/mas" title="mas iconos">Mas iconos creados por Pixel Buddha - Flaticon</a>
End Class
