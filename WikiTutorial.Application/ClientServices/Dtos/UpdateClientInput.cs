using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiTutorial.ClientServices.Dtos
{
    public class UpdateClientInput :EntityDto<long>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
    }
}
