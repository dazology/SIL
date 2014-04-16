using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Service.Commands.Contact;

namespace SIL.Service.Handlers.Contact
{
    public class DeleteContactHandler : ICommandHandler<DeleteContactCommand>
    {
        private IContactRepository contactRepository;
        private IUnitOfWork unitOfWork;

        public DeleteContactHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            this.contactRepository = contactRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteContactCommand command)
        {
            var category = contactRepository.GetById(command.ContacId);
            contactRepository.Delete(category);
            unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}
