﻿using FootballStatistics.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatistics.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<User>
    {
        public string Email { get;  set; }
        public string Password { get;  set; }
    }
}
