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
using SIL.Service.Commands.Security;

namespace SIL.Service.Handlers.Security
{
    public class UserRegisterHandler: ICommandHandler<UserRegisterCommand>
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UserRegisterHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICommandResult Execute(UserRegisterCommand command)
        {
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password,
                RoleId = command.RoleId,
                DateCreated=DateTime.Now,
                LastLoginTime=DateTime.Now,
                Activated = command.Activated
            };
            userRepository.Add(user);
            unitOfWork.Commit();
            return new CommandResult(true);
        }
    }
}
