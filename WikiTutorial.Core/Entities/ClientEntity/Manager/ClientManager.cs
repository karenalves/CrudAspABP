using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiTutorial.Entities.ClientEntity.Manager
{
    public class ClientManager : IClientManager , IDomainService
    {
        private IRepository<Client, long> _clientRepository;

        public ClientManager(IRepository<Client, long> clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<long> CreateClient(Client client)
        {
            return await _clientRepository.InsertAndGetIdAsync(client); 
        }

        public async Task Delete(long id)
        {
            await _clientRepository.DeleteAsync(id);
        }

        public async Task<List<Client>> GetAllClient()
        {
            return await _clientRepository.GetAllListAsync();
        }

        public async Task<Client> GetByIdClient(long id)
        {
            return await _clientRepository.GetAsync(id);
        }

        public async Task<Client> UpdateClient(Client client)
        {
            return await _clientRepository.UpdateAsync(client);
        }
    }
}
