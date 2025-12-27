using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Mrp.Application.DTOs.Products
{
    public class CreateProductDto
    {
       
        public string Name { get;  set; }
        public string Code { get;  set; }
        public int StockQuantity { get;  set; }
    }
}
