using KMBrigadeiria.Data;
using KMBrigadeiria.Models.Entities;
using KMBrigadeiria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KMBrigadeiria.Repositories
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(KMContext context) : base(context)
        {
        
        }

    }
}
