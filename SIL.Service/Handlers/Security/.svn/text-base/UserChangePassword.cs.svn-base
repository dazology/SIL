using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor.Command;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Domain;
using SIL.Service.Commands.Security;
using SIL.Core.Common;

namespace SIL.Service.Handlers.Security
{
    public class UserChangePassword : IValidationHandler<ChangePasswordCommand>
    {
         private readonly IUserRepository userRepository;

         public UserChangePassword(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
         public IEnumerable<ValidationResult> Validate(ChangePasswordCommand command)
        {
            User user = userRepository.GetById(command.UserId);
            var encoded = Md5Encrypt.Md5EncryptPassword(command.OldPassword);      

           if (!user.PasswordHash.Equals(encoded))
            {
                yield return new ValidationResult("OldPassword", "Your password does not match");
            }
        }
    }
}
