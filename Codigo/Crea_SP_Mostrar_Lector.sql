CREATE PROCEDURE Mostrar_Lector
AS
SELECT lectores_IdLector AS [N° Identidad],
		lectores_Nombre AS [Nombre],
		lectores_Telefono AS [Telefono],
		lectores_Direccion AS [Direccion],
		lectores_Observaciones AS [Observaciones]
FROM Table_Lectores