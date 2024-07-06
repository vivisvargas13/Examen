
CREATE PROCEDURE RegistrarMatricula

	@Nombre varchar(255),@Monto decimal(10,2),@TipoCurso int

AS
BEGIN

Declare @Fecha DateTime 

If not exists(SELECT 1 FROM dbo.Estudiantes WHERE Nombre = @Nombre)

BEGIN

INSERT INTO dbo.Estudiantes(Nombre,Fecha,Monto,TipoCurso)

Values 
	(@Nombre,@Fecha,@Monto,@TipoCurso)

	END
END
GO
