using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesMebProject.Services;
using SalesWebMvc.Services;
namespace SalesMebProject.Controllers {
    public class SalesRecordsController : Controller {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService) {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index() {
            return View();
        }
        public async Task<IActionResult> SimplesSearch(DateTime? minDate, DateTime? maxDate) {
            if (!minDate.HasValue) {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue) {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        public IActionResult GroupSearch() {
            return View();
        }
    }
}
