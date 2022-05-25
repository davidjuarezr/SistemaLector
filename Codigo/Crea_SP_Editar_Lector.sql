CREATE PROCEDURE Editar_Lector
/*creamos 5 variables*/
@idLector varchar(13),
@Nombre varchar(50),
@Telefono int,
@Direccion varchar(100),
@Observaciones varchar(100)
AS 
UPDATE Table_Lectores SET lectores_Nombre = @Nombre,
							lectores_Telefono = @Telefono,
							lectores_Direccion = @Telefono,
							lectores_Observaciones = @Observaciones
WHERE lectores_IdLector = @idLector