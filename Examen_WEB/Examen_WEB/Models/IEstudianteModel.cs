using Examen_WEB.Entities;

namespace Examen_WEB.Models
{
    public interface IEstudianteModel
    {

        Respuesta RegistrarMatricula(Estudiante estudiante);

        Respuesta ConsultarMatricula();
    }
}