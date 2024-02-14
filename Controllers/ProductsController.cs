using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newProject.models;
using Npgsql;

namespace newProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {

        static string connString = "Server=localhost;Port=5432;Database=vs;User Id=postgres;Password=oktava;";
        [HttpGet]
        public List<model> Get()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                string query = $"select * from new;";
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                var x = command.ExecuteReader();

                List<model> list = new List<model>();


                while (x.Read())
                {
                    list.Add(new model()
                    {
                        Id = (int)x[0],
                        Mavzu = (string)x[1],
                        age = (int)x[2]
                    });

                }

                return list;
                connection.Close();

            }
        }


    }
    
}
