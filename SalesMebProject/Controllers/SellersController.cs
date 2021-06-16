using Microsoft.AspNetCore.Mvc;
using SalesMebProject.Models;
using SalesMebProject.Services;
using SalesMebProject.Models.ViewModels;
using System.Collections.Generic;
using SalesMebProject.Services.Execptions;
using System.Diagnostics;

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
            if (!ModelState.IsValid) {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerViewModel { Seller = seller, Departament = departments };
                return View(viewModel);
            }
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id) {
            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }
        public IActionResult Details(int? id) {
            if (id == null) {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
            }
            return View(obj);
        }
        public IActionResult Edit(int? id) {

            if (id == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null) {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            List<Departament> departments = _departmentService.FindAll();
            SellerViewModel viewModel = new SellerViewModel { Seller = obj, Departament = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) {
            if (!ModelState.IsValid) {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerViewModel { Seller = seller, Departament = departments };
                return View(viewModel);
            }
            if (id != seller.Id) {
                return RedirectToAction(nameof(Error), new { message = "Id is mismatch" });
            }
            try { 
            _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e) {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }

        }
        public IActionResult Error(string message) {
            var viewModel = new ErrorViewModel {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
