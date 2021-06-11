using Microsoft.AspNetCore.Mvc;
namespace SalesMebProject.Controllers {
    public class SellersController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
