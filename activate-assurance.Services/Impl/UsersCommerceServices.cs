using activate_assurance.DataAccess.Data.Repository;
using activate_assurance.Models;
using activate_assurance.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace activate_assurance.Services.Impl
{
    public class UsersCommerceServices : IUsersCommerceServices
    {
        private readonly IUsersCommerceRepository usersCommerceRepository;
        private readonly IAssuranceRepository assuranceRepository;
        public UsersCommerceServices(IUsersCommerceRepository commerceRepository, IAssuranceRepository assuranceRepository)
        {
            this.usersCommerceRepository = commerceRepository;
            this.assuranceRepository = assuranceRepository;
        }

        public async Task<UsersCommerce> addAsync(UsersCommerce entity)
        {
            return await usersCommerceRepository.addAsync(entity);
        }

        public Task<ActionResult<AuthenticationDTO>> authenticate(UserLoginDTO userLogin)
        {
            return usersCommerceRepository.authenticate((UsersCommerce) userLogin);
        }

        public List<UsersCommerce> findAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsersCommerce>> findAllAsync()
        {
            // Pending: Eager loading othe relations
            return await usersCommerceRepository.getAllAsync(includeProperties: "commerce");
        }

        public UsersCommerce findById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UsersCommerce>> addMassiveAsync(List<UsersCommerce> entities)
        {
            return await usersCommerceRepository.addMassiveAsync(entities);
        }

        public async Task<UsersCommerce> findByIdAsync(int id)
        {
            return await usersCommerceRepository.getByIdAsync(id);
        }

        public async Task<ActionResult<ProfileUserCommerceDTO>> findProfileUsersCommerce(int usersCommerceId)
        {
            string[] relations = { "commerce" };
            ProfileUserCommerceDTO profileUser =  (ProfileUserCommerceDTO) await usersCommerceRepository.getFirstOrDefaultAsync(includeProperties: relations,
                                                                            filter: user => user.usersCommerceId == usersCommerceId
                                                                            );

            profileUser.countAssurancesActivated = await assuranceRepository.countAsync(ass => ass.usersCommerceActivateId == usersCommerceId && ass.usersCommerceClaimId== null);
            profileUser.countAssurancesClaim = await assuranceRepository.countAsync(ass => ass.usersCommerceClaimId == usersCommerceId);
            profileUser.countClientsRegister = new Random().Next(0, 5); // modificar el valor obtenido
            return profileUser;
        }

        public async Task<UsersCommerce> updateAsync(int id, UsersCommerce entity)
        {
            return await usersCommerceRepository.updateAsync(id, entity);
        }
    }
}
