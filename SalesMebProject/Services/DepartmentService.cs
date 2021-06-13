using SalesMebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SalesMebProject.Services {
    public class DepartmentService {
        private readonly SalesMebProjectContext _context;
        public DepartmentService(SalesMebProjectContext context) {
            _context = context;
        }

        public List<Departament> FindAll() {
            return _context.Departament.OrderBy(x => x.Name).ToList();
        }
    }
}
