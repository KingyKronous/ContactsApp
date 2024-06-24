using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Services.Contracts
{
    public interface IContactsService : IBaseCrudService<ContactDto, IContactRepository>
    {
        Task<IEnumerable<ContactDto>> GetWithPaginationAsync(int pageSize, int pageNumber, string searchName, string searchPhone, string searchEmail);
    }
}
