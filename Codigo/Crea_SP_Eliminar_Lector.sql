CREATE PROCEDURE Eliminar_Lecctor
@idLector varchar(13)
AS
DELETE FROM Table_Lectores WHERE lectores_IdLector = @idLector