﻿namespace PeterSoft.SonarQube.Connector.Infrastructure.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}