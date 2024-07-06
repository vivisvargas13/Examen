CREATE PROCEDURE ConsultarMatricula

@Nombre varchar(255)

AS
BEGIN

SELECT Consecutivo, Nombre, Fecha, Monto,TipoCurso
FROM dbo.Estudiantes
Where Nombre = @Nombre

END
GO
