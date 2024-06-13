using FormularioJorge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FormularioJorge.Controllers
{
    public class MarketIndexController1 : Controller
    {
        public IActionResult Index(string NombreEntr, string RazonSocial, string Puesto, string CorreoElectronico)
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
                    using (var reader = dbManager.ExecuteStoredProcedure(procedureName, parameters))
                    {
                        // Leer los datos obtenidos
                        //while (reader.Read())
                        //{
                        //    // Acceder a los datos por índice o nombre de columna
                        //    Console.WriteLine($"{reader[0]}, {reader["Parametro1"]}");
                        //    Console.WriteLine($"{reader[1]}, {reader["Parametro2"]}");
                        //    Console.WriteLine($"{reader[2]}, {reader["Parametro3"]}");
                        //}
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return View();
        }
        public IActionResult Octanosocho()
        {
            return View();
        }
        public IActionResult OctanosNueve()
        {
            return View();
        }
        public IActionResult OctanosDiesel()
        {
            return View();
        }
        public IActionResult OrdenesCompra()
        {
            return View();
        }
    }
}
