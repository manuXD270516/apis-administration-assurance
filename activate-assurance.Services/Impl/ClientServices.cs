using activate_assurance.DataAccess.Data.Repository;
using activate_assurance.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace activate_assurance.Services.Impl
{
    public class ClientServices : IClientServices
    {
        private readonly IClientRepository clientRepository;
        public ClientServices(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<Client> addAsync(Client entity)
        {
            return await clientRepository.addAsync(entity);
        }

        public List<Client> findAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Client>> findAllAsync()
        {
            return await clientRepository.getAllAsync(includeProperties: "activateAssurances");
        }

        public Client findById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> findByIdAsync(int id)
        {
            return await clientRepository.getByIdAsync(id);
        }

        public async Task<Client> updateAsync(int id, Client entity)
        {
            return await clientRepository.updateAsync(id, entity);
        }
    }
}
