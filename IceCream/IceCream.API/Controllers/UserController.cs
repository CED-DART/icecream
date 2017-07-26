using System.Collections.Generic;
using IceCream.Business.Component;
using IceCream.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace IceCream.API.Controllers
{
    [Route("api/User")]
    public class UserController : Controller
    {
        private UserComponent Component { get; set; }
        
        public UserController()
        {
            Component = new UserComponent();
        }

        [HttpGet]
        public List<User> tESTE()
        {
            List<User> response = Component.GetAllUser();

            return response;
        }

        [HttpPost]
        public List<User> Save(User model)
        {
            return null;
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            return null;
        }

        [HttpDelete]
        public ActionResult Delete(User model)
        {
            return null;
        }

    }
}
