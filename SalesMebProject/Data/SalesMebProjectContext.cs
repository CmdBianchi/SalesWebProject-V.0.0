using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMebProject.Models;

namespace SalesMebProject.Models {
    public class SalesMebProjectContext : DbContext {
        public SalesMebProjectContext(DbContextOptions<SalesMebProjectContext> options)
            : base(options) {
        }

        public DbSet<Departament> Departament { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
