using newProject.models;
using newProject.models.DTOs;
using newProject.Repository.IRepositoryPattern;
using newProject.Services.IService;

namespace newProject.Services.Service
{
    public class ProductService : IProductService
    {
        public IModelCRUD _prCrd;
        public ProductService(IModelCRUD crd)
        {
            _prCrd = crd;
        }
        public string Create(ModelDTO model)
        {
            if (model.Mavzu == "" || model.Mavzu == null)
            {
                return "Mavzu must not be null";
            }
            if (model.age < 18)
            {
                return " You are young";
            }
            try
            {
                return _prCrd.Create(model);
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
                return "Id must be grater then or equal to 0";
            }
            try
            {
                return _prCrd.Delete(id);
            }
            catch
            {
                return "Error in Service";
            }
        }

        public IEnumerable<Model> GetAll()
        {
            try
            {
                return _prCrd.GetAll();
            }
            catch
            {
                return Enumerable.Empty<Model>();
            }
        }

        public string Update(int id, ModelDTO model)
        {
            if (id < 0)
            {
                return "Id must be grater then or equal to 0";
            }
            if (model.Mavzu == "" || model.Mavzu == null)
            {
                return "Mavzu must not be null";
            }
            if (model.age < 18)
            {
                return " You are young";
            }
            try
            {
                return _prCrd.Update(id, model);
            }
            catch
            {
                return "Error in Service";
            }
        }
    }
}
