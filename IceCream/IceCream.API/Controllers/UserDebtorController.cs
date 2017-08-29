
using IceCream.Business.Component;
using IceCream.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace IceCream.API.Controllers
{
    [Route("api/UserDebtor")]
    public class UserDebtorController : Controller 
    {
        private UserDebtorComponent Component { get; set; }

        public UserDebtorController(IceCreamManagementContext context)
        {
            Component = new UserDebtorComponent(context);
        }

        [HttpGet, Route("GetAll")]
        public IActionResult GetAll()
        {
            var userDebtorList = Component.GetAllUserDebtor();

            return Json(userDebtorList);
        }

        [HttpPost, Route("CreatePendingDebtors")]
        public IActionResult CreatePendingDebtors()
        {
            Component.CreatePendingDebtors();

            return Ok();
        }
    }
}