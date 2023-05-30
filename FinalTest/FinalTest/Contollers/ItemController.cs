using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinalTest.Contollers
{
    public class ItemController : Controller
    {
        private readonly ItemInterface itemInterface;
        public ItemController(ItemInterface itemInterface)
        {
            this.itemInterface = itemInterface;
        }
        [HttpGet]
        public IActionResult Index()
        {
            PriceChangeDTO priceChangeDTO = new()
            {

                Items = itemInterface.GetItemCodes()
            };
            return View(priceChangeDTO);
        }
        [HttpPost]
        public IActionResult Index(PriceChangeDTO changeDTO)
        {
            string result=itemInterface.AddPriceChangeAndUpdateItem(changeDTO);
            TempData["success"] = result;
            return RedirectToAction("Index");
        }
    }
}
