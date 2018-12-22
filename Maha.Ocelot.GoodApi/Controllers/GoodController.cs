using Maha.Ocelot.GoodApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Maha.Ocelot.GoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        //Get api/Good/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var item = new Good
            {
                Id = id,
                Content = $"{id}的关联的商品明细",
            };
            return JsonConvert.SerializeObject(item);
        }
    }
}
