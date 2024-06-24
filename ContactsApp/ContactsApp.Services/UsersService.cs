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
    public class UsersService : BaseCrudService<UserDto, IUserRepository>, IUsersService
    {
        public UsersService(IUserRepository repository) : base(repository)
        {

        }

		public async Task<bool> CanUserLoginAsync(string username, string password)

		{
			return await _repository.CanUserLoginAsync(username, password);
		}
		public async Task<UserDto> GetByUsernameAsync(string username)
		{
			return await _repository.GetByUsernameAsync(username);
		}
	}
}
