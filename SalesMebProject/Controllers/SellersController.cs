using Microsoft.AspNetCore.Mvc;
using SalesMebProject.Models;
using SalesMebProject.Services;
using SalesMebProject.Models.ViewModels;
using System.Collections.Generic;
using SalesMebProject.Services.Execptions;
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
        public IActionResult Delete(int? id) {
            if (id == null) {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
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
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null) {
                return NotFound();
            }
            List<Departament> departments = _departmentService.FindAll();
            SellerViewModel viewModel = new SellerViewModel { Seller = obj, Departament = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller) {
            if (id != seller.Id) {
                return BadRequest();
            }
            try { 
            _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException) {
                return NotFound();
            }
            catch (DbCocurrencyException) {
                return BadRequest();
            }
        }
    }
}
