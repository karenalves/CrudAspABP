using Abp.AutoMapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiTutorial.ClientServices.Dtos;
using WikiTutorial.Entities.ClientEntity;
using WikiTutorial.Entities.ClientEntity.Manager;

namespace WikiTutorial.ClientServices
{
    public class ClientAppService : IClientAppService
    {
        public ClientManager _clientManager;
        public ClientAppService(ClientManager clientManager)
        {
            this._clientManager = clientManager;
        }

        public List<Client> Client { get; private set; }

        public async Task<CreateClientOutput> CreateClient(CreateClientInput input)
        {
            var cliente = input.MapTo<Client>();
            var createdClienteId = await _clientManager.CreateClient(cliente);

            return new CreateClientOutput
            {
                Id = createdClienteId
            };
        }

        public async Task DeleteClient(long id)
        {
            await _clientManager.Delete(id);
        }

        public async Task<GeAlltClientsOutput> GetAllClient()
        {
            var cliente = await _clientManager.GetAllClient();

            return new GeAlltClientsOutput
            {
                Client = Mapper.Map<List<GetClient>>(cliente)
            };
        }

        public async Task<GetClientByIdOutput> GetByIdClient(long id)
        {
            return (await _clientManager.GetByIdClient(id)).MapTo<GetClientByIdOutput>();
        }

        public async Task<UpdateClientOutput> UpdateClient(UpdateClientInput input)
        {
            var client = input.MapTo<Client>();

            return (await _clientManager.UpdateClient(client)).MapTo<UpdateClientOutput>();
        }
    }
}
