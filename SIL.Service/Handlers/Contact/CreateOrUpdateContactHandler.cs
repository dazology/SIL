using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Service.Commands.Contact;
using SIL.CommadProcessor;




namespace SIL.Service.Handlers.Contact
{
    public class CreateOrUpdateContactHandler : ICommandHandler<CreateOrUpdateContactCommand>
    {
        private IContactRepository _contactRepository;
        private IUnitOfWork _unitOfWork;

        public CreateOrUpdateContactHandler(IContactRepository contactRpository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRpository;
            _unitOfWork = unitOfWork; 
        }

        public ICommandResult Execute(CreateOrUpdateContactCommand command)
        {
            var contact = new SIL.Domain.Contact
            {
                ContactId = command.ContactId,
                CustomerId = command.CustomerId,
                Name = command.Name,
                IsPrimary = command.IsPrimary,
                IsSecondary = command.IsSecondary,
                EmailAddress = command.EmailAddress,
            };

            if (contact.ContactId == 0)
            {
                _contactRepository.Add(contact);
            }
            else
            {
                _contactRepository.Update(contact);
            }

            _unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}
