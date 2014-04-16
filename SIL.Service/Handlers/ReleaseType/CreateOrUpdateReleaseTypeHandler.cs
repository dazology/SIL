using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Service.Commands.ReleaseType;

namespace SIL.Service.Handlers.ReleaseType
{
    public class CreateOrUpdateReleaseTypeHandler : ICommandHandler<CreateOrUpdateReleaseTypeCommand>
    {
        private readonly IReleaseTypeRepository _releaseTypeRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrUpdateReleaseTypeHandler(IReleaseTypeRepository repo, IUnitOfWork unitOfWork)
        {
            this._releaseTypeRepo = repo;
            this._unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(CreateOrUpdateReleaseTypeCommand command)
        {
            var rt = new SIL.Domain.ReleaseType
            {
                ReleaseTypeId = command.ReleaseTypeId,
                Name = command.Name,
            };

            if (rt.ReleaseTypeId == 0)
                _releaseTypeRepo.Add(rt);
            else
                _releaseTypeRepo.Update(rt);
            
            _unitOfWork.Commit();

            return new CommandResult(true);

        }
    }
}
