using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Domain;
using SIL.Service.Commands.Ip;

namespace SIL.Service.Handlers.Ip
{
  public class CreateOrUpdateIpHandler : ICommandHandler<CreateOrUpdateIpCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIpRepository _ipRepository;

        public CreateOrUpdateIpHandler(IUnitOfWork unitOfWork, IIpRepository ipRepository)
        {
            this._unitOfWork = unitOfWork;
            this._ipRepository = ipRepository;
        }

        public ICommandResult Execute(CreateOrUpdateIpCommand command)
        {
           var ip = new IP
            {
                IpId = command.IpId,
                InternalIPAddress = command.InternalIPAddress,
                ExternalIPAddress = command.ExternalIPAddress,
                IISIPAddress = command.IISIPAddress,
                SSL = command.SSL,
                ServerId = command.ServerId,
                Location = command.Location,
                Comments = command.Comments
            };

           if (ip.IpId == 0)
               _ipRepository.Add(ip);
           else
               _ipRepository.Update(ip);

            _unitOfWork.Commit();  

           return new CommandResult(true);

        }
    }
}
