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
                    string sql = "INSERT INTO products (mavzu, age,shop_id) VALUES (@Mavzu, @age,@Shop_id);";
                    connection.Execute(sql, new Model
                    {
                        Mavzu = model.Mavzu,
                        age = model.age,
                        Shop_id = model.Shop_id
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
                    string sql = $"Delete from products where id = @ids";
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
                    IEnumerable<Model>? result = connection.Query<Model>("select * from products;");
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
                    string sql = $"update products set mavzu = @Mavzu, age = @age,shop_id = @Shop_id where id = @ids";
                    connection.Execute(sql, new
                    {
                        Mavzu = model.Mavzu,
                        age = model.age,
                        Shop_id = model.Shop_id,
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
