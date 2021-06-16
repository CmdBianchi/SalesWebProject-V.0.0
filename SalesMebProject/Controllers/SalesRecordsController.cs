using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SalesMebProject.Controllers {
    public class SalesRecordsController : Controller {
        public IActionResult Index() {
            return View();
        }
        public IActionResult SimplesSearch() {
            return View();
        }
        public IActionResult GroupSearch() {
            return View();
        }
    }
}
