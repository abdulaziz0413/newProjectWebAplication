using newProject.models.DTOs;
using newProject.models;

namespace newProject.Repository.IRepositoryPattern
{
    public interface IShopCRUD
    {
        public IEnumerable<Shop> GetAll();
        public string Create(ShopDTO model);
        public string Update(int id,ShopDTO model);
        public string Delete(int id);
    }
}
