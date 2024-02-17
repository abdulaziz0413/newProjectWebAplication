using newProject.models.DTOs;
using newProject.models;

namespace newProject.Services.IService
{
    public interface IProductService
    {
        public IEnumerable<Model> GetAll();
        public string Create(ModelDTO model);
        public string Update(int id, ModelDTO model);
        public string Delete(int id);
    }
}
