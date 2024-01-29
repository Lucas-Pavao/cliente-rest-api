using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using clientes_rest_api.Models;
using clientes_rest_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace clientes_rest_api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCliente()
        {
            try
            {
                // Tenta obter a lista de Clientes
                var Clientes = await _repository.GetClientes();
                // Verifica se há Clientes na lista e retorna a resposta apropriada
                return Clientes.Any() ? Ok(Clientes) : NoContent();
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            try
            {
                // Tenta obter um Cliente pelo ID
                var Cliente = await _repository.GetClienteById(id);
                // Verifica se o Cliente foi encontrado e retorna a resposta apropriada
                return Cliente != null ? Ok(Cliente) : NotFound($"Cliente com ID {id} não encontrado");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente Cliente)
        {
            try
            {
                // Adiciona um novo Cliente
                _repository.CreateCliente(Cliente);
                // Verifica se a operação foi bem-sucedida e retorna a resposta apropriada
                return await _repository.SaveChangesAsync() ? Ok("Cliente adicionado com sucesso") : BadRequest("Falha ao adicionar o Cliente");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Cliente Cliente)
        {
            try
            {
                // Verifica se o ID informado é o mesmo do Cliente
                if (id != Cliente.Id)
                    return BadRequest($"Não foi possível atualizar o Cliente com ID {id}");

                // Atualiza o Cliente
                _repository.UpdateCliente(Cliente);
                // Verifica se a operação foi bem-sucedida e retorna a resposta apropriada
                return await _repository.SaveChangesAsync() ? Ok("Cliente atualizado com sucesso") : BadRequest("Falha ao atualizar o Cliente");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Tenta obter o Cliente pelo ID
                var Cliente = await _repository.GetClienteById(id);
                // Verifica se o Cliente foi encontrado
                if (Cliente == null)
                    return NotFound($"Cliente com ID {id} não encontrado");

                // Remove o Cliente do repositório
                _repository.DeleteCliente(Cliente.Id);
                // Verifica se a operação foi bem-sucedida e retorna a resposta apropriada
                return await _repository.SaveChangesAsync() ? Ok("Cliente removido com sucesso") : BadRequest("Falha ao remover o Cliente");
            }
            catch (Exception ex)
            {
                // Em caso de exceção, retorna uma resposta de erro interno do servidor
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }

        }
    }
}