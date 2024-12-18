using KuaforShop.API.Models;
using KuaforShop.API.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace KuaforShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaloonController : ControllerBase
    {
        [HttpGet("/get/{id}")]
        public mdlSaloons Get(Guid id)
        {
            return new SaloonRepository().GetAllSaloons().Where(x => x.Id == id)?.FirstOrDefault() ?? null;
        }

        [HttpGet("/getAll")]
        public List<mdlSaloons> GetAll()
        {
            return new SaloonRepository().GetAllSaloons();
        }
    }
}
