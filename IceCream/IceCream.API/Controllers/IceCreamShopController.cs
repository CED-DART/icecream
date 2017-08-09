﻿using System.Collections.Generic;
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

        [HttpPost]
        public IActionResult Add([FromBody] IceCreamShop item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            Component.Add(item);
            return CreatedAtRoute("Get", new { Controller = "IceCreamShop", id = item.IdIceCreamShop }, item);
        }

        [HttpPut, Route("Update")]
        public IActionResult Update(int id, [FromBody] IceCreamShop item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = Component.Get(id);
            if (contactObj == null)
            {
                return NotFound();
            }
            Component.Update(item);
            return new NoContentResult();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Component.Delete(id);
        }
    }
}