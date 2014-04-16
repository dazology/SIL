using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repository;
using SIL.Service.Commands.Website;
using SIL.Domain;
using SIL.CommadProcessor;

namespace SIL.Service.Handlers.Website
{
    public class CreateOrUpdateWebsiteHandler : ICommandHandler<CreateOrUpdateWebsiteCommand>
    {
        private readonly IWebsiteRepository websiteRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateOrUpdateWebsiteHandler(IWebsiteRepository websiteRepository, IUnitOfWork unitOfWork)
        {
            this.websiteRepository = websiteRepository;
            this.unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(CreateOrUpdateWebsiteCommand command)
        {
            var website = new SIL.Domain.Website
            {
                WebsiteId = command.WebsiteId,
               CustomerId = command.CustomerId,
                IpId = command.IpId,
                SiteName = command.SiteName,
                WebsitePath = command.WebsitePath,
                WebsiteFolder =command.WebsiteFolder,
                DatabaseName = command.DatabaseName,
                Version = command.Version,
                URL = command.URL,
                IsActive = command.IsActive,
                DomainControl = command.DomainControl,
                SupportUsername = command.SupportUsername,
                SupportPasswordHash = command.SupportPasswordHash,
                Comments = command.Comments,
                Pingdom = command.Pingdom
            };

            if (website.WebsiteId == 0)
                websiteRepository.Add(website);
            else
                websiteRepository.Update(website);
            
            unitOfWork.Commit();

            return new CommandResult(true);
        }

    }
}
