using SalesMebProject.Controllers;
using SalesMebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SalesMebProject.Services {
    public class SellerService {
        private readonly SalesMebProjectContext _context;
        public SellerService(SalesMebProjectContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj) {
            _context.Add(obj);
            _context.SaveChanges();
        }
        public Seller FindById(int id) {
            return _context.Seller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id) {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
