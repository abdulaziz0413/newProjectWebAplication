using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newProject.models;
using Npgsql;

namespace newProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {

        static string connString = "Server=localhost;Port=5432;Database=vs;User Id=postgres;Password=oktava;";
        [HttpGet]
        public List<Model> Read()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                return connection.Query<Model>("select * from New;").ToList();
            }
        }
        [HttpGet]
        public List<Model> ReadByAge(int age)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                return connection.Query<Model>("select * from new where age > @age;", new { Age = age }).ToList();
            }
        }

        [HttpPost]
        public Model CreateDataWithDapper(Model viewModel)
        {
            string sql = "INSERT INTO new (mavzu, age) VALUES (@mavzu, @age);";

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Execute(sql, new Model
                {
                    Mavzu = viewModel.Mavzu,
                    age = viewModel.age,
                });

                return viewModel;
            }
        }
        [HttpPut]
        public Model UpdateDataWithDapper(int id, Model viewModel)
        {
            string sql = $"update new set mavzu = @mavzu, age = @age where id = {id}";

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                connection.Execute(sql, new Model
                {
                    Mavzu = viewModel.Mavzu,
                    age = viewModel.age,

                });

                return viewModel;
            }
        }
        [HttpDelete]
        public int DeleteDataWithDapper(int id)
        {
            string sql = $"Delete from new where id = @id";

            using (NpgsqlConnection connection = new NpgsqlConnection(connString))
            {
                var x = connection.Execute(sql, new { Id = id });

                return x;
            }
        }


        //pastdagisi read ADO.NET da

        /*public List<model> Get()
        {
           *//* using (NpgsqlConnection connection = new NpgsqlConnection(connString))
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
                connection.Close();*//*

            }*/
    }


}
    

