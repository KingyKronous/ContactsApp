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
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Data.Repos
{
    [AutoBind]
    public class ContactRepository : BaseRepository<Contact, ContactDto>, IContactRepository
    {
        public ContactRepository(ContactsAppWebContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<IEnumerable<ContactDto>> GetWithPaginationAsync(int pageSize, int pageNumber, string searchName, string searchPhone, string searchEmail)
        {
            var paginatedRecords = await _dbSet
                .Where(c => c.Name.Contains(searchName) && c.Phone.Contains(searchPhone) && c.Email.Contains(searchEmail))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return MapToEnumerableOfModel(paginatedRecords);
        }
    }
}
