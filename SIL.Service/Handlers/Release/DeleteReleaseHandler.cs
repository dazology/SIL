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
    public class DeleteReleaseHandler : ICommandHandler<DeleteReleaseCommand>
    {
        private IReleaseRepository _releaseRepository;
        private IUnitOfWork unitOfWork;

        public DeleteReleaseHandler(IReleaseRepository releaseRepository, IUnitOfWork unitOfWork)
        {
            this._releaseRepository = releaseRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteReleaseCommand command)
        {
            var ip = _releaseRepository.GetById(command.ReleaseHistoryId);
            _releaseRepository.Delete(ip);
            unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}
