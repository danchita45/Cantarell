using FormularioJorge.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace FormularioJorge.Controllers
{

    public class HomeController : Controller
    {
        private static List<Entrevistado> _Entrevistados = new List<Entrevistado>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Configurar los parámetros de conexión
            string server = "DANCHITA45\\SQLEXPRESS";
            string database = "PlataformaJorge";
            string userId = "sa";
            string password = "desa";
            // Crear una instancia de DatabaseManager y usarla para conectarse y realizar consultas
            using (ConeccionBD dbManager = new(server, database, userId, password))
            {
                try
                {
                    dbManager.OpenConnection();
                    // Llamar a un procedimiento almacenado
                    string procedureName = "spPruebaConexion";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Parametro1", SqlDbType.Int) { Value = 123 },
                        new SqlParameter("@Parametro2", SqlDbType.VarChar, 20) { Value = "Prueba" },
                        new SqlParameter("@Parametro3", SqlDbType.Money) { Value = 1.20 }
                    };
                    using (var reader = dbManager.ExecuteStoredProcedure(procedureName, parameters))
                    {
                        // Leer los datos obtenidos
                        while (reader.Read())
                        {
                            // Acceder a los datos por índice o nombre de columna
                            Console.WriteLine($"{reader[0]}, {reader["Parametro1"]}");
                            Console.WriteLine($"{reader[1]}, {reader["Parametro2"]}");
                            Console.WriteLine($"{reader[2]}, {reader["Parametro3"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error: " + ex.Message);
                }
            }


            return View(_Entrevistados);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GuardarFormulario(string NombreEntr, string RazonSocial, string Puesto, string CorreoElectronico)
        {

            string server = "DANCHITA45\\SQLEXPRESS";
            string database = "PlataformaJorge";
            string userId = "sa";
            string password = "desa";
            // Crear una instancia de DatabaseManager y usarla para conectarse y realizar consultas
            using (ConeccionBD dbManager = new(server, database, userId, password))
            {
                try
                {
                    dbManager.OpenConnection();
                    // Llamar a un procedimiento almacenado
                    string procedureName = "spGuardarEntrevistado";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@Nombre", SqlDbType.VarChar,100) { Value = NombreEntr },
                        new SqlParameter("@RazonSocial", SqlDbType.VarChar, 100) { Value = RazonSocial },
                        new SqlParameter("@Puesto", SqlDbType.VarChar,100) { Value = Puesto},
                        new SqlParameter("@CorreoElectronico", SqlDbType.VarChar,200) { Value = CorreoElectronico },
                    };
                    //using (var reader = dbManager.ExecuteStoredProcedure(procedureName, parameters))
                    //{
                    //    // Leer los datos obtenidos
                    //    while (reader.Read())
                    //    {
                    //        // Acceder a los datos por índice o nombre de columna
                    //        Console.WriteLine($"{reader[0]}, {reader["Parametro1"]}");
                    //        Console.WriteLine($"{reader[1]}, {reader["Parametro2"]}");
                    //        Console.WriteLine($"{reader[2]}, {reader["Parametro3"]}");
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            _Entrevistados.Add(new Entrevistado()
            {
                Nombre = NombreEntr,
                RazonSocial = RazonSocial,
                puesto = Puesto,
                correo = CorreoElectronico
            });
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
