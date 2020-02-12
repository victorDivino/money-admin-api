﻿using MoneyAdmin.Domain.Core.Commands;
using System;

namespace MoneyAdmin.Domain.Commands
{
    public class CreateAccountCommand : CommandBase
    {
        public CreateAccountCommand()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }

        public string Name { get; set; }

        public decimal InitialValue { get; set; }
    }
}
