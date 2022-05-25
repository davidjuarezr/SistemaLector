Public Class frmLectores
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

    Private Sub panelTitulo_MouseUp(sender As Object, e As MouseEventArgs) Handles panelTitulo.MouseUp
        Arrastre = False
    End Sub
    '<a href = "https://www.flaticon.es/iconos-gratis/buscar" title="buscar iconos">Buscar iconos creados por inkubators - Flaticon</a>
    '<a href="https://www.flaticon.es/iconos-gratis/mas" title="más iconos">Más iconos creados por Smashicons - Flaticon</a>
    '<a href="https://www.flaticon.es/iconos-gratis/mas" title="mas iconos">Mas iconos creados por Pixel Buddha - Flaticon</a>
End Class
