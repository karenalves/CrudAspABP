using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiTutorial.ClientServices.Dtos;

namespace WikiTutorial.ClientServices
{
    public interface IClientAppService : IApplicationService
    {
        Task<CreateClientOutput> CreateClient(CreateClientInput input);

        Task<UpdateClientOutput> UpdateClient(UpdateClientInput input);

        Task<GetClientByIdOutput> GetByIdClient(long id);

        Task<GeAlltClientsOutput> GetAllClient();

        Task DeleteClient(long id);

    }
}
