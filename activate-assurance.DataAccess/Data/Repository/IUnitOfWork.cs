using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace activate_assurance.DataAccess.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IClientRepository clientRepository { get; }

        public IProductRepository productRepository{ get; }

        public IAssuranceRepository assuranceRepository { get; }

        public ICommerceRepository commerceRepository { get;  }

        public IUsersCommerceRepository usersCommerceRepository { get; }

    }
}
