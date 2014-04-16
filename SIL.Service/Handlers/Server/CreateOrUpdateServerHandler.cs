using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.DataLayer.Repository;
using SIL.Service.Commands.Server;

namespace SIL.Service.Handlers.Server
{
   public class CreateOrUpdateServerHandler : ICommandHandler<CreateOrUpdateServerCommand>
    {
       private readonly IServerRepository _serverRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrUpdateServerHandler(IServerRepository serverRepository, IUnitOfWork unitOfWork)
        {
            this._serverRepository = serverRepository;
            this._unitOfWork = unitOfWork;

        }

        public ICommandResult Execute(CreateOrUpdateServerCommand command)
        {
             var server = new SIL.Domain.Server
            {
                ServerId = command.ServerId,
                FriendlyName = command.FriendlyName,
               HostName = command.HostName,
               IISVersionNo = command.IISVersionNo,
               Description = command.Description,         
      
            };

             if (server.ServerId == 0)
                 _serverRepository.Add(server);
            else
                 _serverRepository.Update(server);
            
            _unitOfWork.Commit();

            return new CommandResult(true);
        }

        public ICommandResult Execute(CreateOrUpdateServerHandler command)
        {
            throw new NotImplementedException();
        }
    }
}
