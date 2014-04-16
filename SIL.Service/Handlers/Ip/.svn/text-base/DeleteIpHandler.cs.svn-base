using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Service.Commands.Ip;

namespace SIL.Service.Handlers.Ip
{
    public class DeleteIpHandler : ICommandHandler<DeleteIpCommand>
    {
        private IIpRepository _ipRepository;
        private IUnitOfWork unitOfWork;

        public DeleteIpHandler(IIpRepository ipRepository, IUnitOfWork unitOfWork)
        {
            this._ipRepository = ipRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteIpCommand command)
        {
            var ip = _ipRepository.GetById(command.IpId);
            _ipRepository.Delete(ip);
            unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}
