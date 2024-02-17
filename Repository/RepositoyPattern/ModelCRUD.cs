using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using newProject.models;
using newProject.models.DTOs;
using Dapper;
using newProject.Repository.IRepositoryPattern;
using Npgsql;

namespace newProject.Repository.RepositoyPattern
{
    public class ModelCRUD : IModelCRUD
    {
        public IConfiguration _conStr;
        public ModelCRUD(IConfiguration str)
        {
            _conStr = str;
        }
        public string Create(ModelDTO model)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_conStr.GetConnectionString("Default")))
                {
                    string sql = "INSERT INTO new (mavzu, age) VALUES (@Mavzu, @age);";
                    connection.Execute(sql, new Model
                    {
                        Mavzu = model.Mavzu,
                        age = model.age,
                    });

                    return "Successfully";
                }
            }
            catch
            {
                return "Error in RepPatern";
            }
        }

        public string Delete(int id)
        {
            try
            {

                using (NpgsqlConnection connection = new NpgsqlConnection(_conStr.GetConnectionString("Default")))
                {
                    string sql = $"Delete from new where id = @ids";
                    var x = connection.Execute(sql, new { ids = id });

                    return "Successfully";
                }
            }
            catch
            {
                return "Error in RepPattern";
            }
        }

        public IEnumerable<Model> GetAll()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_conStr.GetConnectionString("Default")))
            {
                try
                {
                    IEnumerable<Model>? result = connection.Query<Model>("select * from New;");
                    return result;
                }
                catch
                {
                    return Enumerable.Empty<Model>();
                }
            }
        }

        public string Update(int id, ModelDTO model)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_conStr.GetConnectionString("Default")))
                {
                    string sql = $"update new set mavzu = @Mavzu, age = @age where id = @ids";
                    connection.Execute(sql, new
                    {
                        Mavzu = model.Mavzu,
                        age = model.age,
                        ids = id

                    });

                    return "Succesfully";
                }
            }
            catch
            {
                return "Error in RepPattern";
            }
        }
    }
}
