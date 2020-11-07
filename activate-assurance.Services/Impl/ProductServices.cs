using activate_assurance.DataAccess.Data.Repository;
using activate_assurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace activate_assurance.Services.Impl
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository productRepository;

        public ProductServices(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> addAsync(Product entity)
        {
            return await productRepository.addAsync(entity);
        }

        public List<Product> findAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> findAllAsync()
        {
            return await productRepository.getAllAsync();
        }

        public Product findById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> findByIdAsync(int id)
        {
            return await productRepository.getByIdAsync(id);
        }

        public async Task<Product> updateAsync(int id, Product entity)
        {
            // validacion de parametros 
            return await productRepository.updateAsync(id, entity);
        }
    }
}
