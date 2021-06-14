using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SalesMebProject.Models.ViewModels {
    public class SellerViewModel {
        public Seller Seller { get; set; }
        public ICollection<Departament> Departaments { get; set; }
        public List<Departament> Departament { get; internal set; }
    }
}
