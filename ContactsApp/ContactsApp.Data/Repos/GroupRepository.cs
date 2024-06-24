using AutoMapper;
using ContactsApp.Data.Entities;
using ContactsApp.Shared.Attributes;
using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using ContactsApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Data.Repos
{
    [AutoBind]
    public class GroupRepository : BaseRepository<Group, GroupDto>, IGroupRepository
    {
        public GroupRepository(ContactsAppWebContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
