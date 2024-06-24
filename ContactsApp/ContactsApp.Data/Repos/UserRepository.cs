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
using ContactsApp.Shared.Security;

namespace ContactsApp.Data.Repos
{
    [AutoBind]
    public class UserRepository : BaseRepository<User, UserDto>, IUserRepository
    {
        public UserRepository(ContactsAppWebContext context, IMapper mapper) : base(context, mapper)
        {

        }

		public async Task<bool> CanUserLoginAsync(string username, string password)
		{
			var hashedPassword = (await this.GetByUsernameAsync(username))?.Password;
			return PasswordHasher.VerifyPassword(password, hashedPassword);
		}
		public async Task<UserDto> GetByUsernameAsync(string username)
		{
			return MapToModel(await _dbSet.FirstOrDefaultAsync(u => u.Username == username));
		}
	}
}
