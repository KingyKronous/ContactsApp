using AutoMapper;
using ContactsApp.Data.Entities;
using ContactsApp.Shared.Attributes;
using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using ContactsApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Data.Repos
{
    [AutoBind]
    public class RoleRepository : BaseRepository<Role, RoleDto>, IRoleRepository
    {
        public RoleRepository(ContactsAppWebContext context, IMapper mapper) : base(context, mapper)
        {

        }

		public async Task<RoleDto> GetByNameIfExistsAsync(string name)
		{
			return MapToModel(await _dbSet.FirstOrDefaultAsync(u => u.Name == name));
		}
	}
}
