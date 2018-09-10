using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiTutorial.Entities.ProductEntity;

namespace WikiTutorial.Entities.Manager
{
    public interface IProductManager
    {
        Task<long> Create(Product produto);
        Task<long> Update(Product produto);
        Task Delete(long id);
        Task<Product> GetById(long id);
        Task<List<Product>> GetAllList();
    }
}
