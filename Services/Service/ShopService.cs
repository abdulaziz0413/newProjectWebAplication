using newProject.models;
using newProject.models.DTOs;
using newProject.Repository.IRepositoryPattern;
using newProject.Services.IService;

namespace newProject.Services.Service
{
    public class ShopService : IShopService
    {
        public IShopCRUD _shop;
        public ShopService(IShopCRUD crd)
        {
            _shop = crd;
        }
        public string Create(ShopDTO model)
        {
            if (model.Name == "" || model.Name == null)
            {
                return "Name must not be null";
            }
            if (model.Description == "" || model.Description == null)
            {
                return "Descripton must not be null";
            }
            try
            {
                return _shop.Create(model);
            }
            catch
            {
                return "Error in Service";
            }
        }

        public string Delete(int id)
        {
            if (id < 0)
            {
                return "Id must greater then or equal to 0";
            }
            try
            {
                return _shop.Delete(id);
            }
            catch
            {
                return "Error in Service";
            }
        }

        public IEnumerable<Shop> GetAll()
        {
            try
            {
                return _shop.GetAll();
            }
            catch
            {
                return Enumerable.Empty<Shop>();
            }
        }

        public string Update(int id, ShopDTO model)
        {
            if (id < 0)
            {
                return "Id must greater then or equal to 0";
            }
            if (model.Name == "" || model.Name == null)
            {
                return "Name must not be null";
            }
            if (model.Description == "" || model.Description == null)
            {
                return "Descripton must not be null";
            }
            try
            {
                return _shop.Update(id, model);
            }
            catch
            {
                return "Error in Service";
            }
        }
    }
}
