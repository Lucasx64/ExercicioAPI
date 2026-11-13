using PizzariaAPI.Interfaces;
using PizzariaAPI.Contexts;
using PizzariaAPI.Models;


namespace PizzariaAPI.Repositories
{
    public class ClienteRepository
    {
        private readonly PizzariaContext _context;

        ClienteRepository(PizzariaContext context)
        {
            _context = context;
        }
    }
}
