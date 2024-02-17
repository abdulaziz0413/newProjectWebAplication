using newProject.models;
using newProject.models.DTOs;
using newProject.Repository.IRepositoryPattern;
using Npgsql;
using Dapper;

namespace newProject.Repository.RepositoyPattern
{
    public class ShopCRUD : IShopCRUD
    {
        public IConfiguration _conStr;
        public ShopCRUD(IConfiguration str)
        {
            _conStr = str;
        }
        public string Create(ShopDTO model)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_conStr.GetConnectionString("Default")))
                {
                    string sql = "INSERT INTO shops (name, description) VALUES (@Name, @Description);";
                    connection.Execute(sql, new ShopDTO
                    {
                        Name = model.Name,
                        Description = model.Description,
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
                    string sql = $"Delete from shops where id = @ids";
                    var x = connection.Execute(sql, new { ids = id });

                    return "Successfully";
                }
            }
            catch
            {
                return "Error in RepPattern";
            }
        }

        public IEnumerable<Shop> GetAll()
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_conStr.GetConnectionString("Default")))
            {
                try
                {
                    IEnumerable<Shop>? result = connection.Query<Shop>("select * from shops;");
                    return result;
                }
                catch
                {
                    return Enumerable.Empty<Shop>();
                }
            }
        }

        public string Update(int id, ShopDTO model)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_conStr.GetConnectionString("Default")))
                {
                    string sql = $"update shops set name = @Name, Description = @Describtion1 where id = @ids";
                    connection.Execute(sql, new
                    {
                        Name = model.Name,
                        Describtion1 = model.Description,
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
