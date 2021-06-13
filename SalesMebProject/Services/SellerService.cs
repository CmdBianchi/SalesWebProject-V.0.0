using SalesMebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SalesMebProject.Services {
    public class SellerService {
        private readonly SalesMebProjectContext _context;
        public SellerService(SalesMebProjectContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }
    }
}
