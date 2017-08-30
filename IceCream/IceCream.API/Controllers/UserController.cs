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
        
        public UserController(IceCreamManagementContext context)
        {
            Component = new UserComponent(context);
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            List<User> response = Component.GetAll();

            return Json(response);
        }

        [HttpGet, Route("Get")]
        public IActionResult Get(int id)
        {
            var user = Component.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost, Route("Add")]
        public IActionResult Add([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            Component.Add(user);

            return Ok();
        }

        [HttpPut, Route("Update")]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            User oldEntity = Component.Get(user.IdUser);

            if (oldEntity == null)
            {
                return NotFound();
            }

            Component.Update(user);

            return Ok();
        }

        [HttpDelete, Route("Delete")]
        public IActionResult Delete(int id)
        {
            User user = Component.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            Component.Delete(id);

            return Ok();
        }

        [HttpPost, Route("Login")]
        public IActionResult Login([FromBody] User user) 
        {
            User response = Component.Login(user.Email, user.Password);

            if (user == null) 
            {
                return NotFound();
            }

            return Json(response);    
        }

        [HttpPost, Route("AcceptedTerms")]
        public IActionResult AcceptedTerms(int id)
        {
            User user = Component.Get(id);
            
            if (user == null)
            {
                return NotFound();
            }
            
            Component.AcceptedTerms(user);

            return Ok();
        }

    }
}
