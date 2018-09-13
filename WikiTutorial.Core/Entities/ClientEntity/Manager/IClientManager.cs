using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiTutorial.Entities.ClientEntity.Manager
{
    public interface IClientManager
    {
        Task<long> CreateClient(Client client);

        Task<Client> UpdateClient(Client client);

        Task<Client> GetByIdClient(long id);

        Task<List<Client>> GetAllClient();

        Task Delete(long id);

    }
}
