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
    public class ContactsService : BaseCrudService<ContactDto, IContactRepository>, IContactsService
    {
        public ContactsService(IContactRepository repository) : base(repository)
        {

        }
        public virtual Task<IEnumerable<ContactDto>> GetWithPaginationAsync(int pageSize, int pageNumber, string searchName, string searchPhone, string searchEmail)
            => this._repository.GetWithPaginationAsync(pageSize, pageNumber, searchName, searchPhone, searchEmail);
    }
}
