using ContactsApp.Shared.Attributes;
using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using ContactsApp.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Services
{
    [AutoBind]
    public class GroupsService : BaseCrudService<GroupDto, IGroupRepository>, IGroupsService
    {
        public GroupsService(IGroupRepository repository) : base(repository)
        {

        }
    }
}
