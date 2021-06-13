using Microsoft.AspNetCore.Mvc;
using SalesMebProject.Models;
using SalesMebProject.Services;
using SalesMebProject.Models.ViewModels;
namespace SalesMebProject.Controllers {
    public class SellersController : Controller {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
        public SellersController(SellerService sellerService, DepartmentService departmentService) {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index() {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create() {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerViewModel { Departaments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller) {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
