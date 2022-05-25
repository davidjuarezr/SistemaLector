CREATE PROCEDURE Insertar_Lector
/*creamos 5 variables*/
@idLector varchar(13),
@Nombre varchar(50),
@Telefono int,
@Direccion varchar(100),
@Observaciones varchar(100)
AS 
/*hacemos una validacion para no insertar repetidos*/
IF EXISTS (SELECT Lectores_IdLector FROM Table_Lectores WHERE lectores_Direccion = @idLector)
	RAISERROR('El número de identificacion que ha ingresado ya está registrado en el sistema', 16,1)
ELSE
	INSERT INTO Table_Lectores
	VALUES(@idLector, @Nombre, @Telefono, @Direccion, @Observaciones)

