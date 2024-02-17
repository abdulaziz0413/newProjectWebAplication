using newProject.models.DTOs;
using newProject.models;

namespace newProject.Services.IService
{
    public interface IShopService
    {
        public IEnumerable<Shop> GetAll();
        public string Create(ShopDTO model);
        public string Update(int id, ShopDTO model);
        public string Delete(int id);
    }
}
