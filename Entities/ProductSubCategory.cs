using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKARTAPI.Entities
{
    public class ProductSubCategory
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; }
        public string ImageUrl { get; set; }

        public int ProductCategoryId { get; set; }  
        public char UsedBy { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
