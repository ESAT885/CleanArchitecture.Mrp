using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Mrp.Domain.Models.Entities.Base;

namespace CleanArchitecture.Mrp.Domain.Models.Entities
{
    public class Product: BaseEntity
    {
       
        public string Name { get;  set; }
        public string Code { get;  set; }
        public int StockQuantity { get;  set; }
    }
}
