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
            List<Entrevistado> _Entrevistados = new List<Entrevistado>();
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
                        
                        while (reader.Read())
                        {

                            Console.WriteLine($"{reader[0]}, {reader["IdEntrevistado"]}");
                            Console.WriteLine($"{reader[1]}, {reader["Nombre"]}");
                            Console.WriteLine($"{reader[2]}, {reader["RazonSocial"]}");
                            _Entrevistados.Add(new Entrevistado()
                            {
                                IdEntrevistado = Convert.ToInt32(reader["IdEntrevistado"]),
                                Nombre = reader["Nombre"].ToString(),
                                RazonSocial = Convert.ToString(reader["RazonSocial"]),
                                puesto = Convert.ToString(reader["Puesto"]),
                                correo = Convert.ToString(reader["Correo"]),
                            }); ;
                        }
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
