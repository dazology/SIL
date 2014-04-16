﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIL.CommadProcessor.Command
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        ICommandResult Execute(TCommand command);
    }
}
