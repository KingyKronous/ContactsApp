using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Services.Contracts
{
    public interface IUsersService : IBaseCrudService<UserDto, IUserRepository>
    {
		public Task<bool> CanUserLoginAsync(string username, string password);
		public Task<UserDto> GetByUsernameAsync(string username);
	}
}
