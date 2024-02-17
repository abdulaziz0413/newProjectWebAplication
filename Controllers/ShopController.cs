using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using newProject.models;
using newProject.models.DTOs;
using newProject.Services.IService;

namespace newProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        public ShopController(IShopService shop)
        {
            _shopService = shop;
        }
        [HttpGet]
        public IEnumerable<Shop> GetAll()
        {
            return _shopService.GetAll();
        }
        [HttpPost]
        public string Create(ShopDTO shopDTO)
        {
            return _shopService.Create(shopDTO);
        }
        [HttpPut]
        public string Update(int id, ShopDTO shopDTO)
        {
            return _shopService.Update(id, shopDTO);
        }
        [HttpDelete]
        public string Delete(int id)
        {
            return _shopService.Delete(id);
        }
    }
}
