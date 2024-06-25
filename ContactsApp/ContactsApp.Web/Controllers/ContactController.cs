using AutoMapper;
using ContactsApp.Shared;
using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using ContactsApp.Shared.Services.Contracts;
using ContactsApp.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ContactsApp.Web.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "User, Admin")]
    public class ContactController : BaseCrudController<ContactsDto, IContactRepository, IContactsService, ContactEditVM, ContactDetailsVM>
    {
        protected readonly IGroupsService _groupsService;
        public ContactController(IContactsService service, IMapper mapper, IGroupsService groupsService) : base(service, mapper)
        {
            this._groupsService = groupsService;
        }

        protected override async Task<ContactEditVM> PrePopulateVMAsync(ContactEditVM editVM)
        {
            editVM.GroupList = (await _groupsService.GetAllAsync())
                .Select(x => new SelectListItem($"{x.Name}", x.Id.ToString()));
            return editVM;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pageSize = DefaultPageSize,
            int pageNumber = DefaultPageNumber, string searchName = "", string searchPhone = "", string searchEmail = "")
        {
            if (pageSize <= 0 ||
                pageSize > MaxPageSize ||
                pageNumber <= 0)
            {
                return BadRequest(Constants.InvalidPagination);
            }

            var models = await this._service.GetWithPaginationAsync(pageSize, pageNumber, searchName, searchPhone, searchEmail);
            

            var mappedModels = _mapper.Map<IEnumerable<ContactDetailsVM>>(models);

            return View(nameof(List), mappedModels);
        }

        [HttpGet]
        public async Task<IActionResult> ExportList(int pageSize = DefaultPageSize,
            int pageNumber = DefaultPageNumber, string searchName = "", string searchPhone = "", string searchEmail = "")
        {
            var models = await this._service.GetWithPaginationAsync(pageSize, pageNumber, searchName, searchPhone, searchEmail);
            var exportlist = JsonConvert.SerializeObject(models.ToList());
            ViewBag.ExportList = exportlist;

            var mappedModels = _mapper.Map<IEnumerable<ContactDetailsVM>>(models);

            return View(nameof(List), mappedModels);
        }
    }
}
