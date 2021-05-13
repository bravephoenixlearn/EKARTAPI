using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKARTAPI.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl{ get; set; }

        public List<ProductSubCategory> ProductSubCategories { get; set; }
    }
}
