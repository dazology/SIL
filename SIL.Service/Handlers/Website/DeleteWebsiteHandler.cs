using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repository;
using SIL.Service.Commands.Website;

namespace SIL.Service.Handlers.Website
{
    public class DeleteWebsiteHandler : ICommandHandler<DeleteWebsiteCommand>
    {
        private readonly IWebsiteRepository websiteRepository;
        private readonly IUnitOfWork unitOfWork;

        public DeleteWebsiteHandler(IWebsiteRepository websiteRepository, IUnitOfWork unitOfWork)
        {
            this.websiteRepository = websiteRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteWebsiteCommand command)
        {
            var category = websiteRepository.GetById(command.WebsiteId);
            websiteRepository.Delete(category);
            unitOfWork.Commit();
            return new CommandResult(true);
        }
    }
}
