using PizzariaAPI.Models;
using PizzariaAPI.Interfaces;

namespace PizzariaAPI.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> ListarTodos();

    }
}
