CREATE PROCEDURE Buscar_Lector
@Busqueda varchar(50)
AS
SELECT lectores_IdLector AS [N° Identidad],
		lectores_Nombre AS [Nombre],
		lectores_Telefono AS [Telefono],
		lectores_Direccion AS [Direccion],
		lectores_Observaciones AS [Observaciones]
FROM Table_Lectores WHERE lectores_IdLector + lectores_Nombre LIKE '%' + @Busqueda + '%'