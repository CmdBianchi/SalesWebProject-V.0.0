using SalesMebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SalesMebProject.Services {
    public class DepartmentService {
        private readonly SalesMebProjectContext _context;
        public DepartmentService(SalesMebProjectContext context) {
            _context = context;
        }

        public async Task<List<Departament>> FindAllAsync() {
            return await _context.Departament.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
