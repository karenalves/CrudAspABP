using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiTutorial.ProductServices.Dtos
{
    public class GetAllProductsOutput
    {
        public List<GetAllProductsItem> Products { get; set; }
    }
}
