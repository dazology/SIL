using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Service.Commands.Release;

namespace SIL.Service.Handlers.Release
{
    class CreateOrUpdateReleaseHandler : ICommandHandler<CreateOrUpdateReleaseCommand>
    {
        private readonly IReleaseRepository _releaseRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateOrUpdateReleaseHandler(IReleaseRepository releaseRepository, IUnitOfWork unitOfWork)
        {
            this._releaseRepository = releaseRepository;
            this.unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(CreateOrUpdateReleaseCommand command)
        {
            var rh = new SIL.Domain.Release
            {
                ReleaseId = command.ReleaseId ,    
                WebsiteId = command.WebsiteId,
                ReleaseTypeId = command.ReleaseTypeId,
                DevDate = command.DevDate,
                LiveDate = command.LiveDate,
                StagingDate = command.StagingDate,
                ReleaseDescription1 = command.ReleaseDescription1,
                ReleaseDescription2 = command.ReleaseDescription2,
                ReleaseDescription3 = command.ReleaseDescription3,
                BuildVersionNo = command.BuildVersionNo,
                DbVersionNo = command.DbVersionNo,
                Build = command.Build,
                Script = command.Script,
                DB = command.DB,
                Content = command.Content,
                Notes = command.Notes,
                ReleaseStatus = command.Statuses.ToString(),
                CreatedDate = DateTime.Now,
            };

            if (rh.ReleaseId == 0)
                _releaseRepository.Add(rh);
            else
                _releaseRepository.Update(rh);
            
            unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}
