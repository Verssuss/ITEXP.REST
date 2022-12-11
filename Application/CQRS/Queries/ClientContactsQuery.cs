﻿using Application.CQRS.Responses;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Queries
{
    public class ClientContactsQuery : IRequest<Result<List<ClientContactsResponse>>>
    {

    }
}