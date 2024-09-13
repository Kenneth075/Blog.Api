﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<CreateAuthorReponse>
    {
        public CreateAuthorRequestDto CreateAuthorRequestDto { get; set; }
    }
}
