Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Module ConexionMaestra
    Public conexion As New SqlConnection("Server= DESKTOP-MQT6GIO;Database= BD_CRUD; User Id= sa;Password= Bmw320ii&.")

    'se abre la conexion
    Sub Abrir_conexion()
        If conexion.State = 0 Then
            conexion.Open()
        End If
    End Sub

    'se cierra la conexion
    Sub Cerrar_conexion()
        If conexion.State = 1 Then
            conexion.Close()
        End If
    End Sub

End Module
