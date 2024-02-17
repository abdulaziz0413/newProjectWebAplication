using newProject.models;
using newProject.models.DTOs;

namespace newProject.Repository.IRepositoryPattern
{
    public interface IModelCRUD
    {
        public IEnumerable<Model> GetAll();
        public string Create(ModelDTO model);
        public string Update(int id, ModelDTO model);
        public string Delete(int id);
    }
}
