using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientes_rest_api.Models;

namespace clientes_rest_api.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> CreateCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        Task DeleteCliente(int id);

        Task<bool> SaveChangesAsync();

    }
}