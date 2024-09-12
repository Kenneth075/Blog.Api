using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.DeleteBlog
{
    public class DeleteRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
