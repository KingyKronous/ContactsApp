using AutoMapper;
using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using ContactsApp.Shared.Services.Contracts;
using ContactsApp.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace ContactsApp.Web.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "User, Admin")]
    public class GroupController : BaseCrudController<GroupDto, IGroupRepository, IGroupsService, GroupEditVM, GroupDetailsVM>
    {
        public GroupController(IGroupsService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
