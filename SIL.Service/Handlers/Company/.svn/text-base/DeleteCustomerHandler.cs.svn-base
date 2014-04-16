using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Service.Commands.Company;

namespace SIL.Service.Handlers.Company
{
    class DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private ICompanyRepository customerRepository;
        private IUnitOfWork unitOfWork;

        public DeleteCustomerHandler(ICompanyRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(DeleteCustomerCommand command)
        {
            var category = customerRepository.GetById(command.CustomerId);
            customerRepository.Delete(category);
            unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}
