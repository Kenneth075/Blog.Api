using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authors.Commands.CreateAuthor
{
    public class CreateAuthorRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
