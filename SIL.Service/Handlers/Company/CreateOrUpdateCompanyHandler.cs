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
    public class CreateOrUpdateCompanyHandler : ICommandHandler<CreateOrUpdateCompanyCommand>
    {

         private readonly ICompanyRepository companyRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateOrUpdateCompanyHandler(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            this.companyRepository = companyRepository;
            this.unitOfWork = unitOfWork;
        }

        public ICommandResult Execute(CreateOrUpdateCompanyCommand command)
        {
            var company = new SIL.Domain.Customer
            {
                CustomerId = command.CustomerId,               
              //  ContactId = command.ContactId,
                Name = command.Name,
                Address1 = command.Address1,
                Address2 = command.Address2,
                City = command.City,
                PostCode = command.PostCode,
                TelNo = command.TelNo,
                FaxNo = command.FaxNo,

            };

            if (company.CustomerId == 0)
                companyRepository.Add(company);
            else
                companyRepository.Update(company);
            
            unitOfWork.Commit();

            return new CommandResult(true);
        }
    }
}
