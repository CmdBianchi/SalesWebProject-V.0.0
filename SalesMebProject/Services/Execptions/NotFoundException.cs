using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SalesMebProject.Services.Execptions {
    public class NotFoundException : ApplicationException {
        public NotFoundException(string message) : base(message) {

        }
    }
}
