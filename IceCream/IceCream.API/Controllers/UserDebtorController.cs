
using IceCream.Business.Component;
using IceCream.Data.Models;
using Microsoft.AspNetCore.Mvc;
namespace IceCream.API.Controllers
{
    [Route("api/UserDebtor")]
    public class UserDebtorController : Controller 
    {
        private UserDebtorComponent Component { get; set; }

        public UserDebtorController(DBIceScreamContext context)
        {
            Component = new UserDebtorComponent(context);
        }

        [HttpGet, Route("GetPending")]
        public IActionResult GetPending(int? maximumItems = null)
        {
            var userDebtorList = Component.GetPendingUserDebtor(maximumItems);

            return Json(userDebtorList);
        }

        [HttpPost, Route("CreatePendingDebtors")]
        public IActionResult CreatePendingDebtors()
        {
            Component.CreatePendingDebtors();

            return Ok();
        }

        [HttpGet, Route("GetLastPaymentDate")]
        public IActionResult GetLastPaymentDate()
        {
            var lastPaymentDate = Component.GetLastPaymentDate();

            return Json(lastPaymentDate);
        }

        [HttpPut, Route("RequestPayment")]
        public IActionResult RequestPayment([FromBody] RequestUserDebtorPayment requestPayment)
        {
            if (requestPayment == null)
            {
                return BadRequest();
            }

            Component.RequestPayment(requestPayment);

            return Ok();
        }

        [HttpGet, Route("GetAllEvaluationData")]
        public IActionResult GetAllEvaluationData()
        {
            var evaluationData = Component.GetAllEvaluationData();

            return Json(evaluationData);
        }
    }
}