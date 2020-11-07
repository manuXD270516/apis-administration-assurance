using System;
using System.Collections.Generic;
using System.Text;

namespace activate_assurance.DataAccess.Data.Repository.Impl
{
    public class UnitOfWork: IUnitOfWork
    {

        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            // inicializar los repositorios asociados con sus dbcontext respectivamente
            clientRepository = new ClientRepository(dbContext);
            productRepository = new ProductRepository(dbContext);
            assuranceRepository = new AssuranceRepository(dbContext);
            commerceRepository = new CommerceRepository(dbContext);
            usersCommerceRepository = new UsersCommerceRepository(dbContext);
        }

        public IClientRepository clientRepository { get; private set; }

        public IProductRepository productRepository { get; private set; }

        public IAssuranceRepository assuranceRepository { get; private set; }

        public ICommerceRepository commerceRepository { get; private set; }

        public IUsersCommerceRepository usersCommerceRepository { get; private set; }


        public void Dispose()
        {
            dbContext.Dispose();
        }

        // actualizar este proceso para que sea de tipo función en futuras iteraciones
        public void save()
        {
            dbContext.SaveChanges();
        }
    }
}
