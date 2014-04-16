using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using SIL.Web.ViewModels;
using SIL.Service.Commands.Website;
using SIL.Service.Commands.Company;
using SIL.Service.Commands.Release;
using SIL.Service.Commands.Server;
using SIL.Service.Commands.Contact;
using SIL.Service.Commands.Ip;
using SIL.Domain;
using SIL.Service.Commands.ReleaseType;
using SIL.Service.Commands.Checklist;
using SIL.Service.Commands.CustomChecks;
using SIL.Service.Commands.Security;

namespace SIL.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<WebsiteViewModel, CreateOrUpdateWebsiteCommand>();
            Mapper.CreateMap<CustomerViewModel, CreateOrUpdateCompanyCommand>();
            Mapper.CreateMap<ReleaseViewModel, CreateOrUpdateReleaseCommand>();
            Mapper.CreateMap<ContactViewModel, CreateOrUpdateContactCommand>();
            Mapper.CreateMap<ServerViewModel, CreateOrUpdateServerCommand>();
            Mapper.CreateMap<IpViewModel, CreateOrUpdateIpCommand>();
            Mapper.CreateMap<ReleaseTypeViewModel, CreateOrUpdateReleaseTypeCommand>();
            Mapper.CreateMap<ChecklistViewModel, CreateOrUpdateChecklistCommand>();
            Mapper.CreateMap<CustomCheckViewModel, CreateOrUpdateCustomCheckCommand>();
            Mapper.CreateMap<UserViewModel, UserRegisterCommand>(); 
        }
    }
}
