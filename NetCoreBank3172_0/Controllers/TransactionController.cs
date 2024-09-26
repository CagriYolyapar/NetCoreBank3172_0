using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreBank3172_0.Models.ContextClasses;
using NetCoreBank3172_0.Models.Entities;
using NetCoreBank3172_0.Models.RequestModels;

namespace NetCoreBank3172_0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        MyContext _db;

        public TransactionController(MyContext db)
        {
            _db = db;
        }


        //[HttpGet]
        //public async Task<IActionResult> Test()
        //{
        //    return Ok(_db.CardInfoes.ToList());
        //}


        [HttpPost]
        public async Task<IActionResult> StartTransaction(PaymentRequestModel item)
        {
            if(_db.CardInfoes.Any(x=>x.CardNumber == item.CardNumber && x.CVC == item.CVC && x.CardUserName == item.CardUserName)) //aslında burada daha katı daha ayrıntılı bir business logic yapılır
            {
                UserCardInfo uCInfo = await _db.CardInfoes.SingleOrDefaultAsync(x => x.CardNumber == item.CardNumber && x.CVC == item.CVC && x.CardUserName == item.CardUserName);

                if (uCInfo.Balance >= item.ShoppingPrice)
                {
                    uCInfo.Balance -= item.ShoppingPrice; //Fiyat katrın balance'inden düser

                    await _db.SaveChangesAsync();
                    return Ok("Odeme basarıyla alındı");
                }
                else return StatusCode(400, "Kart bakiyesi yeresiz bulundu");
            }

            return StatusCode(400, "Kart bulunamadı");
        }
    }
}
