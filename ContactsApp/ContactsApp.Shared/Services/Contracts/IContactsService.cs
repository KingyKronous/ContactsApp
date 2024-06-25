using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Services.Contracts
{
    public interface IContactsService : IBaseCrudService<ContactsDto, IContactRepository>
    {
        Task<IEnumerable<ContactsDto>> GetWithPaginationAsync(int pageSize, int pageNumber, string searchName, string searchPhone, string searchEmail);
    }
}
