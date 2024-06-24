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
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<GroupDto, GroupEditVM>().ReverseMap();
            CreateMap<GroupDto, GroupDetailsVM>().ReverseMap();
			CreateMap<Role, RoleDto>().ReverseMap();
			CreateMap<RoleDto, RoleEditVM>().ReverseMap();
			CreateMap<RoleDto, RoleDetailsVM>().ReverseMap();
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<UserDto, UserEditVM>().ReverseMap();
			CreateMap<UserDto, UserDetailsVM>().ReverseMap();
            CreateMap<Contact, ContactDto>().ReverseMap();
            CreateMap<ContactDto, ContactEditVM>().ReverseMap();
            CreateMap<ContactDto, ContactDetailsVM>().ReverseMap();
            CreateMap<LoginDto, LoginVM>().ReverseMap();
            CreateMap<RegisterVM, UserDto>().ReverseMap();
		}
    }
}
