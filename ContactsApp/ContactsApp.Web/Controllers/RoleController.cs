using AutoMapper;
using ContactsApp.Shared.Dtos;
using ContactsApp.Shared.Repos.Contracts;
using ContactsApp.Shared.Services.Contracts;
using ContactsApp.Web.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace ContactsApp.Web.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme, Roles = "Admin")]
    public class RoleController : BaseCrudController<RoleDto, IRoleRepository, IRolesService, RoleEditVM, RoleDetailsVM>
    {
        public RoleController(IRolesService service, IMapper mapper) : base(service, mapper)
        {

        }
    }
}
