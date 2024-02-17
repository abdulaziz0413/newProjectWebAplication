using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newProject.models;
using newProject.models.DTOs;
using newProject.Services.IService;
using Npgsql;

namespace newProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _prodSer
            ;
        public ProductsController(IProductService pr)
        {
            _prodSer = pr;
        }
        [HttpGet]
        public IEnumerable<Model> GetAll()
        {
            return _prodSer.GetAll();
        }
        [HttpPost]
        public string Create(ModelDTO shopDTO)
        {
            return _prodSer.Create(shopDTO);
        }
        [HttpPut]
        public string Update(int id, ModelDTO shopDTO)
        {
            return _prodSer.Update(id, shopDTO);
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return _prodSer.Delete(id);
        }
    }


}
    

