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
    public class RolesService : BaseCrudService<RoleDto, IRoleRepository>, IRolesService
    {
        public RolesService(IRoleRepository repository) : base(repository)
        {

        }

		public async Task<RoleDto> GetByNameIfExistsAsync(string name)
		{
			return await _repository.GetByNameIfExistsAsync(name);
		}
	}
}
