using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiTutorial.Entities.ProductEntity;

namespace WikiTutorial.Entities.Manager
{
    public class ProductManager : IDomainService, IProductManager
    {
        private IRepository<Product, long> _productRepository;

        public ProductManager(IRepository<Product, long> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<long> Create(Product produto)
        {
            return await _productRepository.InsertAndGetIdAsync(produto);
        }

        public async Task Delete(long id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<Product>> GetAllList()
        {
            return await _productRepository.GetAllListAsync();
        }

        public async Task<Product> GetById(long id)
        {
            return await _productRepository.GetAsync(id);
        }

        public async Task<Product> Update(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }
    }
}
