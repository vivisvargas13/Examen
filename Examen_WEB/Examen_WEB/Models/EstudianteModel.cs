using Examen_WEB.Entities;
using System.Net.Http.Headers;
using static Examen_WEB.Models.EstudianteModel;

namespace Examen_WEB.Models
{
        public class EstudianteModel(HttpClient http, IConfiguration iConfiguration, IHttpContextAccessor iAccesor) : IEstudianteModel
        {
            public Respuesta RegistrarMatricula(Estudiante estudiante)
            {
                string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Matricula/RegistrarMatricula";
                JsonContent body = JsonContent.Create(estudiante);
                var result = http.PostAsync(url, body).Result;

                if (result.IsSuccessStatusCode)
                    return result.Content.ReadFromJsonAsync<Respuesta>().Result!;
                else
                    return new Respuesta();
            }

            public Respuesta ConsultarMatricula()
            {
                string url = iConfiguration.GetSection("Llaves:UrlApi").Value + "Matricula/ConsultarMatricula";
                string token = iAccesor.HttpContext!.Session.GetString("TOKEN")!.ToString();

                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var result = http.GetAsync(url).Result;

                if (result.IsSuccessStatusCode)
                    return result.Content.ReadFromJsonAsync<Respuesta>().Result!;
                else
                    return new Respuesta();
            }
        }
    }

