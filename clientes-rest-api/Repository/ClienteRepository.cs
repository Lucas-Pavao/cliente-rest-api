using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientes_rest_api.Data;
using clientes_rest_api.Models;
using Microsoft.EntityFrameworkCore;

namespace clientes_rest_api.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteDbContext _context;
        public ClienteRepository(ClienteDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CreateCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            return cliente;
        }

        public async Task DeleteCliente(int id)
        {
            var cliente = await GetClienteById(id);
            _context.Clientes.Remove(cliente);
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public void UpdateCliente(Cliente cliente)
        {
            _context.Update(cliente);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}