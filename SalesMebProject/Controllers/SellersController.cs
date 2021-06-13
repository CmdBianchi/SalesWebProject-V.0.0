using Microsoft.AspNetCore.Mvc;
using SalesMebProject.Services;
namespace SalesMebProject.Controllers {
    public class SellersController : Controller {
        private readonly SellerService _sellerService;
        public SellersController(SellerService sellerService) {
            _sellerService = sellerService;
        }
        public IActionResult Index() {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create() {
            return View();
        }
    }
}
