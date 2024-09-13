using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorReponse : BaseResponse
    {
        public AuthorDto Author { get; set; }
    }
}
