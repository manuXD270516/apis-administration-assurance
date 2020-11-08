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
        public UsersCommerceServices(IUsersCommerceRepository commerceRepository)
        {
            this.usersCommerceRepository = commerceRepository;
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

        public async Task<UsersCommerce> findByIdAsync(int id)
        {
            return await usersCommerceRepository.getByIdAsync(id);
        }

        public async Task<UsersCommerce> updateAsync(int id, UsersCommerce entity)
        {
            return await usersCommerceRepository.updateAsync(id, entity);
        }
    }
}
