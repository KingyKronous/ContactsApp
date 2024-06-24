using ContactsApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Repos.Contracts
{
    public interface IContactRepository : IBaseRepository<ContactDto>
    {
        Task<IEnumerable<ContactDto>> GetWithPaginationAsync(int pageSize, int pageNumber, string searchName, string searchPhone, string searchEmail);
    }
}
