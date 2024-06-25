using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Services.Contracts
{
    public interface IGroupsService : IBaseCrudService<ContactsDto, IGroupRepository>
    {
    }
}
