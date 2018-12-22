using Maha.Ocelot.OrderApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Maha.Ocelot.OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //Get api/Order/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var item = new Order
            {
                Id = id,
                Content = $"{id}的订单明细",
            };
            return JsonConvert.SerializeObject(item);
        }
    }
}
