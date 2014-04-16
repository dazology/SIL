using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIL.CommadProcessor;
using SIL.CommadProcessor.Command;
using SIL.DataLayer;
using SIL.DataLayer.Repositories.Interfaces;
using SIL.Service.Commands.Checklist;

namespace SIL.Service.Handlers.Checklist
{
    public class CreateOrUpdateChecklistHandler : ICommandHandler<CreateOrUpdateChecklistCommand>
    {
        private readonly IChecklistRepository _checklistRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public CreateOrUpdateChecklistHandler(IChecklistRepository repo, IUnitOfWork uow)
        {
            this._checklistRepository = repo;
            this._UnitOfWork = uow;
        }

        public ICommandResult Execute(CreateOrUpdateChecklistCommand command)
        {
            var checklist = new SIL.Domain.ChecklistQuestion
            {
                ChecklistQuestionId = command.ChecklistId,
                OrderNo = command.QuestionNo,
                Question = command.Question,
                QuestionFieldType = command.QuestionFieldOptions.ToString(),


            };

            if (checklist.ChecklistQuestionId == 0)
                _checklistRepository.Add(checklist);
            else
                _checklistRepository.Update(checklist);

            _UnitOfWork.Commit();

            return new CommandResult(true);

        }

    }
}
