using System.Collections.Generic;
using IceCream.Business.Component;
using IceCream.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IceCream.API.Controllers
{
    [Route("api/IceCreamShop")]
    public class IceCreamShopController : Controller
    {
        private IceCreamShopComponent Component { get; set; }

        public IceCreamShopController(IceCreamManagementContext context)
        {
            Component = new IceCreamShopComponent(context);
        }

        [HttpGet]
        public List<IceCreamShop> GetAll()
        {
            return Component.GetAll();
        }

        [HttpGet, Route("Get")]
        public IActionResult Get(int id)
        {
            var item = Component.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost, Route("Add")]
        public IActionResult Add([FromBody] IceCreamShop item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            Component.Add(item);

            return Ok();
        }

        [HttpPut, Route("Update")]
        public IActionResult Update([FromBody] IceCreamShop item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            
            var oldEntity = Component.Get(item.IdIceCreamShop);

            if (oldEntity == null)
            {
                return NotFound();
            }

            Component.Update(oldEntity, item);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            
            var iceCreamShop = Component.Get(id);

            if (iceCreamShop == null)
            {
                return NotFound();
            }
            
            Component.Delete(id);

            return Ok();
        }
    }
}
