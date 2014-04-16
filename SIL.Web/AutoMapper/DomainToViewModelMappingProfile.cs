using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using SIL.Domain;
using SIL.Web.ViewModels;

namespace SIL.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Website, WebsiteViewModel>();
            Mapper.CreateMap<Customer, CustomerViewModel>();
            Mapper.CreateMap<Release, ReleaseViewModel>();
            Mapper.CreateMap<Contact, ContactViewModel>(); 
            Mapper.CreateMap<Server, ServerViewModel>();
            Mapper.CreateMap<IP, IpViewModel>();
            Mapper.CreateMap<ReleaseType, ReleaseTypeViewModel>();
            Mapper.CreateMap<ChecklistQuestion, ChecklistViewModel>();
            Mapper.CreateMap<CustomChecklist, CustomCheckViewModel>();
          //  Mapper.CreateMap<WebsiteGroupList, WebsiteGroupViewModel>();
            Mapper.CreateMap<User, UserViewModel>();
        }   
    }
}
