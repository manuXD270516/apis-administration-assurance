using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace activate_assurance.Services.Impl
{
    public interface IServicesTemplate<T> where T: class
    {
        List<T> findAll();
        T findById(int id);


        Task<List<T>> findAllAsync();
        Task<T> findByIdAsync(int id);
        Task<T> addAsync(T entity);
        Task<T> updateAsync(int id, T entity);
    }
}
