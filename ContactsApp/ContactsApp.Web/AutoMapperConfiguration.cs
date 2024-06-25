using AutoMapper;
using ContactsApp.Data.Entities;
using ContactsApp.Shared.Dtos;
using ContactsApp.Web.ViewModels;

namespace ContactsApp.Web
{
    internal class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Group, ContactsDto>().ReverseMap();
            CreateMap<ContactsDto, GroupEditVM>().ReverseMap();
            CreateMap<ContactsDto, GroupDetailsVM>().ReverseMap();
			CreateMap<Role, RoleDto>().ReverseMap();
			CreateMap<RoleDto, RoleEditVM>().ReverseMap();
			CreateMap<RoleDto, RoleDetailsVM>().ReverseMap();
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<UserDto, UserEditVM>().ReverseMap();
			CreateMap<UserDto, UserDetailsVM>().ReverseMap();
            CreateMap<Contact, ContactsDto>().ReverseMap();
            CreateMap<ContactsDto, ContactEditVM>().ReverseMap();
            CreateMap<ContactsDto, ContactDetailsVM>().ReverseMap();
            CreateMap<LoginDto, LoginVM>().ReverseMap();
            CreateMap<RegisterVM, UserDto>().ReverseMap();
		}
    }
}
