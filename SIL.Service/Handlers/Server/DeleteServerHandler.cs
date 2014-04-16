using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Service.Commands.Server;

namespace SIL.Service.Handlers.Server
{
    public class DeleteServerHandler : ICommandHandler<DeleteServerCommand>
    {
        private IServerRepository serverRepository;
        private IUnitOfWork unitOfWork;

        public DeleteServerHandler(IServerRepository serverRepository, IUnitOfWork unitOfWork)
        {
            this.serverRepository = serverRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteServerCommand command)
        {
            var server = serverRepository.GetById(command.ServerId);
            serverRepository.Delete(server);
            unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}
