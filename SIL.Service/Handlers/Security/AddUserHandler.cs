using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Domain;
using SIL.Service.Commands.Security;


namespace SIL.Service.Handlers.Security
{
    public class AddUserHandler : IValidationHandler<UserRegisterCommand>
    {
           private readonly IUserRepository userRepository;
           public AddUserHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
         public IEnumerable<ValidationResult> Validate(UserRegisterCommand command)
        {
            User isUserExists = null;
            isUserExists = userRepository.Get(c => c.Email == command.Email);

            if (isUserExists != null)
            {
                yield return new ValidationResult("EMail", "Email Already Exists");
            }
        }
    }
}
