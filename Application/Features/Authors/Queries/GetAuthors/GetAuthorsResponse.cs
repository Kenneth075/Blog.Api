using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsResponse : BaseResponse
    {
        public List<AuthorDto> Authors { get; set; }
    }
}
