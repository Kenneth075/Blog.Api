using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsByNameQuery : IRequest<GetAuthorsResponse>
    {
        public string Name { get; set; }
    }
}
