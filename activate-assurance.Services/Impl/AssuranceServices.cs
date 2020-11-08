using activate_assurance.DataAccess.Data.Repository;
using activate_assurance.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace activate_assurance.Services.Impl
{
    public class AssuranceServices : IAssuranceServices
    {
        private readonly IAssuranceRepository assuranceRepository;
        public AssuranceServices(IAssuranceRepository assuranceRepository)
        {
            this.assuranceRepository = assuranceRepository;
        }

        public async Task<Assurance> addAsync(Assurance entity)
        {
            return await assuranceRepository.addAsync(entity);
        }

        public List<Assurance> findAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Assurance>> findAllAsync()
        {
            string[] relations = { "product", "client", "usersCommerceActivate", "usersCommerceClaim" };
            return await assuranceRepository.getAllAsync(includeProperties: relations);
        }

        public Assurance findById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Assurance> findByIdAsync(int id)
        {
            return await assuranceRepository.getByIdAsync(id);
        }

        public async Task<Assurance> updateAsync(int id, Assurance entity)
        {
            return await assuranceRepository.updateAsync(id, entity);
        }
    }
}
