using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesMebProject.Models;

namespace SalesMebProject.Data {
    public class SalesMebProjectContext : DbContext {
        public SalesMebProjectContext(DbContextOptions<SalesMebProjectContext> options)
            : base(options) {
        }

        public DbSet<SalesMebProject.Models.Departament> Departament { get; set; }
    }
}
