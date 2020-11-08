using activate_assurance.DataAccess.Data.Repository;
using activate_assurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace activate_assurance.Services.Impl
{
    public class CommerceServices : ICommerceServices
    {
        private readonly ICommerceRepository commerceRepository;

        public CommerceServices(ICommerceRepository commerceRepository)
        {
            this.commerceRepository = commerceRepository;
        }

        public async Task<Commerce> addAsync(Commerce entity)
        {
            return await commerceRepository.addAsync(entity);
        }

        public List<Commerce> findAll()
        {
            throw new NotImplementedException();    
        }

        public async Task<List<Commerce>> findAllAsync()
        {
            string[] relations = { "usersCommerce" };
            return await commerceRepository.getAllAsync(includeProperties: relations);
        }

        public Commerce findById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Commerce> findByIdAsync(int id)
        {
            return await commerceRepository.getByIdAsync(id);
        }

        public async Task<Commerce> updateAsync(int id, Commerce entity)
        {
            // validacion de parametros 
            return await commerceRepository.updateAsync(id, entity);
        }
    }
}
