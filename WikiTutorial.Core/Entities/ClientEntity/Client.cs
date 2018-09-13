using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiTutorial.Entities.ClientEntity
{
    public class Client : FullAuditedEntity<long>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string  Cpf { get; set; }

        public Client()
        {
            this.CreationTime = DateTime.Now;
        }

        public Client (string name, string lastname, string cpf)
        {
            this.CreationTime = DateTime.Now;
            this.Name = name;
            this.LastName = lastname;
            this.Cpf = cpf;
        }
    }
}
